using Givt.Core.API.Models.Config;
using Givt.Core.API.Models.User;
using Givt.Core.Business.CQR.User.Authorisation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Givt.Core.API.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/[controller]")]
public class UserController : Controller
{
    private readonly IMediator _mediator;
    private readonly CryptographyConfig _config;
    private readonly ApiKeysConfig _apiKeys;

    public UserController(
        IMediator mediator, 
        CryptographyConfig config,
        ApiKeysConfig apiKeys)
    {
        _mediator = mediator;
        _config = config;
        _apiKeys = apiKeys; 
    }

    /// <summary>
    /// Endpoint called by external Authentication Provider to include Authorisation info 
    /// (roles on Legal Entities, i.e. Recipients and Donors) in Bearer token.
    /// </summary>
    /// <param name="email">Identification of the user</param>
    /// <returns>A signed data blob to be incorporated in a JWT Authentication Token</returns>
    [HttpGet("auth")]
    [ProducesResponseType(typeof(AuthorisationResponseModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuthorisation(string email)
    {
        // Query authorisations
        var query = new UserAuthorisationQuery { Email = email };
        var response = await _mediator.Send(query);

        // Pack data and sign
        var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response.Memberships, Formatting.None));
        var signature = SignData(data); // sign over binary data with private key, caller will be able to verify it with the public key

        // Send response
        return Ok(new AuthorisationResponseModel
        {
            // Do base64-encoded to ensure unaltered transport
            Data = Convert.ToBase64String(data),
            Signature = Convert.ToBase64String(signature)
        });
    }

    private byte[] SignData(byte[] data)
    {
        using var rsa = new RSACryptoServiceProvider();
        rsa.ImportRSAPrivateKey(new ReadOnlySpan<byte>(Convert.FromBase64String(_config.AuthorisationSigningKey)), out int bytesRead);
        return rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

}