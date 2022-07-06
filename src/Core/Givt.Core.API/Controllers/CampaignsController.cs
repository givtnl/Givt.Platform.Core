using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Givt.Core.API.Controllers
{
    //[ApiController]
    //[ApiVersion("2.0")]
    //[Route("api/medium")] // compatibility with Givt Online Checkout / Point of Giving frontend
    //[Route("api/[controller]")]
    public class CampaignController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CampaignController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

    
    }
}