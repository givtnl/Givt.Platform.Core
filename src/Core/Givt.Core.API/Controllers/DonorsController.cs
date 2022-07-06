using Givt.Core.API.Auth;
using Givt.Core.Domain.Entities;
using Givt.Core.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Givt.Core.API.Controllers;

[ApiController]
[ApiVersion("2.0")]
//[Route("api/[controller]")]
[Route("v{version:apiVersion}/[controller]")]
public class DonorsController : Controller
{
    private readonly IMediator _mediator;

    public DonorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// List Donors
    /// </summary>
    /// <param name="request">Filter and pagination</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A page of data on Donors</returns>
    /// <response code="200">OK</response>
    /// <response code="404">Not found</response>
    [HttpGet()]
    [AuthorizeResource(GivtRoles = GivtRole.GivtAdmin | GivtRole.GivtOperator)]
    //[ProducesResponseType(typeof(ListDonorResponse), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> ListDonors(
        //[FromQuery] ListDonorRequest request,
        CancellationToken cancellationToken)
    {
        //var query = _mapper.Map<ListDonorsQuery>(request);
        //var model = await _mediator.Send(query, cancellationToken);
        //var response = _mapper.Map<ListDonorResponse>(model);
        //return Ok(response);
        return NoContent();
    }

    /// <summary>
    /// Create a new Donor
    /// </summary>
    /// <param name="request">Donor information</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The updated Donor data</returns>
    /// <response code="201">Created</response>
    [HttpPost()]
    //[ProducesResponseType(typeof(CreateDonorResponse), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> CreateDonor(
        //[FromQuery] CreateDonorRequest request,
        CancellationToken cancellationToken)
    {
        //var query = _mapper.Map<CreateDonorCommand>(request);
        //var model = await _mediator.Send(query, cancellationToken);
        //var response = _mapper.Map<CreateDonorResponse>(model);
        //return CreatedAtRoute(
        //    nameof(ReadDonor),
        //    new
        //    {
        //        DonorId = response.DonorId
        //    },
        //    response);
        return NoContent();
    }

    /// <summary>
    /// Read Donor
    /// </summary>
    /// <param name="DonorId">Donor ID</param>
    /// <param name="cancellationToken"></param>        
    /// <returns>The Donor data</returns>
    [HttpGet("{DonorId:Guid}", Name = nameof(ReadDonor))]
    //[ProducesResponseType(typeof(GetDonorResponse), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> ReadDonor(
        [FromRoute] Guid DonorId,
        CancellationToken cancellationToken)
    {
        //var request = new GetDonorRequest
        //{
        //    DonorId = DonorId
        //};
        //var query = _mapper.Map<ReadDonorQuery>(request);
        //var model = await _mediator.Send(query, cancellationToken);
        //var response = _mapper.Map<GetDonorResponse>(model);
        //return Ok(response);
        return NoContent();
    }

    /// <summary>
    /// Update Donor
    /// </summary>
    /// <param name="DonorId">Donor Identifier</param>
    /// <param name="request">Donor data</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The updated Donor data</returns>
    /// <response code="200">OK</response>
    /// <response code="409">Concurrent update conflict</response>
    [HttpPut("{DonorId:Guid}")]
    //[ProducesResponseType(typeof(UpdateDonorResponse), StatusCodes.Status200OK, "application/json")]
    public async Task<IActionResult> UpdateDonor(
        [FromRoute] Guid DonorId,
        //[FromBody] UpdateDonorRequest request,
        CancellationToken cancellationToken)
    {
        //var command = new UpdateDonorCommand
        //{
        //    DonorId = DonorId
        //};
        //_mapper.Map(request, command);
        //var model = await _mediator.Send(command, cancellationToken);
        //var response = _mapper.Map<UpdateDonorResponse>(model);
        //return Ok(response);
        return NoContent();
    }

    //  Delete is not (yet) needed

}
