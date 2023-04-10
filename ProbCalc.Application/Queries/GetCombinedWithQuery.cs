using MediatR;

namespace ProbCalc.Application.Queries
{
    public record GetCombinedWithQuery : IRequest<float>
    {
        public float A { get; init; }
        public float B { get; init; }
    }

    public class GetCombinedWithQueryHandler : IRequestHandler<GetCombinedWithQuery, float>
    {
        public Task<float> Handle(GetCombinedWithQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(default(float));
        }
    }
}
