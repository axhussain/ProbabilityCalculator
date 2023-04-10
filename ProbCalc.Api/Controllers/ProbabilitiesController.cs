using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProbCalc.Application.Queries;

namespace ProbCalc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProbabilitiesController : ApiControllerBase
    {
        [HttpGet]
        [Route(nameof(CombinedWith))]
        public Task<float> CombinedWith(
            [FromQuery] float pA, 
            [FromQuery] float pB)
        {
            return Mediator.Send(new GetCombinedWithQuery(pA, pB));
        }

        [HttpGet]
        [Route(nameof(Either))]
        public Task<float> Either(
            [FromQuery] float pA, 
            [FromQuery] float pB)
        {
            return Mediator.Send(new GetEitherQuery(pA, pB));
        }
    }
}
