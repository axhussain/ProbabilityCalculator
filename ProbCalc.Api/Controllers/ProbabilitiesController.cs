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
        public Task<float> CombinedWith([FromQuery] GetCombinedWithQuery query)
        {
            return Mediator.Send(query);
        }

        [HttpGet]
        [Route(nameof(Either))]
        public Task<float> Either([FromQuery] GetEitherQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
