using Adesso.Api.Travel.Commands;
using Adesso.Travel.Library.Dtos;
using Adesso.Travel.Library.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Adesso.Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TravelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TravelResearchQuery command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TravelCreateCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("publish")]
        public async Task<IActionResult> Put([FromBody] TravelPublishCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("drop")]
        public async Task<IActionResult> Put([FromBody] TravelDropPublishCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }

        [HttpPut]
        [Route("join")]
        public async Task<IActionResult> Put([FromBody] TravelJoinCommand command)
        {
            var model = await _mediator.Send(command);
            return Ok(model);
        }
    }
}
