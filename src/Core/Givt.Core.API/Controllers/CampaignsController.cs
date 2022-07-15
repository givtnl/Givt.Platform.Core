using AutoMapper;
using Givt.Common.Models;
using Givt.Core.API.Mappings;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.CQR;
using Givt.Core.Persistence.DbContexts;
using Givt.Platform.Common.Utils;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog.Sinks.Http.Logger;

namespace Givt.Core.API.Controllers
{
    //[ApiController]
    //[ApiVersion("2.0")]
    //[Route("api/medium")] // compatibility with Givt Online Checkout / Point of Giving frontend
    //[Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly ILog _log;
        private readonly CoreContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CampaignController(
            ILog log,
            CoreContext context,
            IMapper mapper,
            IMediator mediator)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Get all information about a Campaign
        /// </summary>
        /// <param name="code">MediumID, Guid, or Campaign ID</param>
        /// <param name="languages">Language(s) to select texts</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(CampaignModel), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("code")]
        public async Task<IActionResult> Get(
            [FromQuery] string code,
            [FromHeader(Name = "Accept-Language")] string languages,
            CancellationToken cancellationToken)
        {
            var request = new CampaignGetRequest { Code = code };
            var query = new CampaignGetQuery
            {
                IncludeFees = true,
                IncludeTexts = true,
                IncludePaymentProviders = true,
                IncludeGivtOffice = true,
            };
            _mapper.Map(request, query);
            var response = await _mediator.Send(query, cancellationToken);
            var languagesList = LanguageUtils.GetLanguages(languages, null);
            var result = _mapper.Map<CampaignModel>(response, opt => { opt.Items[ContextTag.Languages] = languagesList; });
            return Ok(result);

        }
    }
}