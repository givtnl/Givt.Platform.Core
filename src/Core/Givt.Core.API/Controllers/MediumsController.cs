using AutoMapper;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.CQR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Givt.Core.API.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/[controller]")]
public class MediumsController : Controller
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public MediumsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Check whether a medium exists in the database (backwards compatibility)
    /// </summary>
    /// <param name="request">Request json</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Exists</returns>
    /// <response code="200">found</response>
    /// <response code="400">malformed data</response>
    /// <response code="404">not found</response>
    [HttpHead("/api/medium")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckForExistence(
        [FromQuery] MediumCheckRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var query = _mapper.Map<MediumExistQuery>(request);
            var response = await _mediator.Send(query, cancellationToken);
            if (response)
                return Ok();
            return NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }
    /// <summary>
    /// Check whether a medium exists in the database
    /// </summary>
    /// <param name="code">Medium ID or code</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Exists</returns>
    /// <response code="200">found</response>
    /// <response code="400">malformed data</response>
    /// <response code="404">not found</response>
    [HttpHead("{code}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CheckForExistence(
        string code,
        CancellationToken cancellationToken)
    {
        try
        {
            var request = new MediumCheckRequest { Code = code };
            var query = _mapper.Map<MediumExistQuery>(request);
            var response = await _mediator.Send(query, cancellationToken);
            if (response)
                return Ok();
            return NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }
    /// <summary>
    /// Get information and texts for a Campaign, based on a Medium ID or code (backwards compatibility)
    /// </summary>
    /// <param name="request">Request json</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Information on the medium</returns>
    /// <response code="200">information on the medium</response>
    /// <response code="400">malformed data</response>
    /// <response code="404">not found</response>
    [HttpGet("/api/medium")]// .../mediums?Code=namespace.instance&Language="en-GB"
    [ProducesResponseType(typeof(MediumTextsGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCampaignInfo(
        [FromQuery] MediumTextsGetRequest request,
        CancellationToken cancellationToken)
    {
        var query = _mapper.Map<CampaignTextGetByMediumQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);
        var result = _mapper.Map<MediumTextsGetResponse>(response);
        return Ok(result);
    }

    /// <summary>
    /// Get information and texts for a Campaign, based on a Medium ID or code
    /// </summary>
    /// <param name="code">Medium ID or code</param>
    /// <param name="language">Optional Accept-Language header from a browser client, or a language code or culture ID. This value selects the best matching texts for a Campaign</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Information on the medium</returns>
    /// <response code="200">information on the medium</response>
    /// <response code="400">malformed data</response>
    /// <response code="404">not found</response>
    [HttpGet("{code}/campaign")]
    [ProducesResponseType(typeof(MediumTextsGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCampaignInfo(
        [FromRoute] string code,
        [FromHeader(Name = "Accept-Language")] string language,
        CancellationToken cancellationToken)
    {
        var request = new MediumTextsGetRequest()
        {
            Code = code,
            Language = language
        };
        var query = _mapper.Map<CampaignTextGetByMediumQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);
        var result = _mapper.Map<MediumTextsGetResponse>(response);
        return Ok(result);
    }

    /// <summary>
    /// Get relational data for a Campaign, based on a Medium ID or code
    /// </summary>
    /// <param name="code">Medium ID or code</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{code}/campaign/data")]
    [ProducesResponseType(typeof(MediumGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCampaignPaymentData(
        [FromRoute] string code,
        CancellationToken cancellationToken)
    {
        var request = new MediumGetRequest()
        {
            Code = code
        };
        var query = _mapper.Map<CampaignGetByMediumQuery>(request);
        var response = await _mediator.Send(query, cancellationToken);
        var result = _mapper.Map<MediumGetResponse>(response);
        return Ok(result);
    }

}