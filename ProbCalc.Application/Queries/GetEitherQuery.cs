using MediatR;

namespace ProbCalc.Application.Queries
{
    public record GetEitherQuery : IRequest<float>
    {
        public float A { get; init; }
        public float B { get; init; }
    }

    public class GetEitherQueryHandler : IRequestHandler<GetEitherQuery, float>
    {
        public Task<float> Handle(GetEitherQuery query, CancellationToken cancellationToken)
        {
            return Task.FromResult(default(float));
        }
    }
}
