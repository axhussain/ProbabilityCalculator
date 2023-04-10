using Application.Services;
using Domain.Services;
using EnsureThat;
using MediatR;

namespace Application.Queries
{
    public sealed record GetCombinedWithQuery : IRequest<float>
    {
        public GetCombinedWithQuery(float pA, float pB)
        {
            EnsureArg.IsInRange(value: pA, min: 0, max: 1, paramName: nameof(pA));
            EnsureArg.IsInRange(value: pB, min: 0, max: 1, paramName: nameof(pB));

            A = pA;
            B = pB;
        }

        public float A { get; }
        public float B { get; }
    }

    public class GetCombinedWithQueryHandler : IRequestHandler<GetCombinedWithQuery, float>
    {
        private readonly ILoggingService _log;
        private readonly ICalculatorService _calculator;

        public GetCombinedWithQueryHandler(ILoggingService log, ICalculatorService calculator)
        {
            _log = log;
            _calculator = calculator;
        }

        public Task<float> Handle(GetCombinedWithQuery query, CancellationToken cancellationToken)
        {
            var result = _calculator.CombinedWith(query.A, query.B);

            _log.Write($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} {query.GetType().Name} for P({query.A}) and P({query.B}) = {result}");

            return Task.FromResult(result);
        }
    }
}
