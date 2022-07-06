using AutoMapper;
using Givt.Core.API.Models;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.CQR;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Givt.Core.API.Controllers
{
    [Route("api/[controller]")]
    [Route("api/medium")] // singular
    public class MediumsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public MediumsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Check whether a medium exists in the database
        /// </summary>
        /// <param name="request">Request json</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Exists</returns>
        /// <response code="200">found</response>
        /// <response code="400">malformed data</response>
        /// <response code="404">not found</response>
        [HttpHead]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckForExistence([FromQuery] MediumCheckRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _mapper.Map<MediumExistQuery>(request);
                var model = await _mediator.Send(query, cancellationToken);
                if (model)
                    return Ok();
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Get information on a Campaign based on a MediumID
        /// </summary>
        /// <param name="request">Request json</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Information on the medium</returns>
        /// <response code="200">information on the medium</response>
        /// <response code="400">malformed data</response>
        /// <response code="404">not found</response>
        [HttpGet] // .../mediums?Code=namespace.instance&Language="en-GB"
        [ProducesResponseType(typeof(MediumTextsGetResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCampaignInfo([FromQuery] MediumTextsGetRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CampaignTextGetByMediumQuery>(request);
            var response = await _mediator.Send(query, cancellationToken);
            var result = _mapper.Map<MediumTextsGetResponse>(response);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet] // .../mediums?Code=namespace.instance
        [ProducesResponseType(typeof(MediumGetResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCampaignPaymentData([FromQuery] MediumGetRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CampaignGetByMediumQuery>(request);
            var response = await _mediator.Send(query, cancellationToken);
            var result = _mapper.Map<MediumGetResponse>(response);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("mediums/{id}/campaign")]
        [ProducesResponseType(typeof(CampaignInfoModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Campaign([FromQuery] MediumTextsGetRequest request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<CampaignGetByMediumQuery>(request);
            var response = await _mediator.Send(query, cancellationToken);
            var result = _mapper.Map<CampaignInfoModel>(response);
            return Ok(result);
        }
    }
}