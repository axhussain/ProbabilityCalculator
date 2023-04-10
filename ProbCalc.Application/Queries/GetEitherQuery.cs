using MediatR;
using ProbCalc.Application.Services;
using ProbCalc.Domain.Services;

namespace ProbCalc.Application.Queries
{
    public record GetEitherQuery : IRequest<float>
    {
        public float A { get; init; }
        public float B { get; init; }
    }

    public class GetEitherQueryHandler : IRequestHandler<GetEitherQuery, float>
    {
        private readonly ILoggingService _log;
        private readonly ICalculatorService _calculator;

        public GetEitherQueryHandler(ILoggingService log, ICalculatorService calculator)
        {
            _log = log;
            _calculator = calculator;
        }

        public Task<float> Handle(GetEitherQuery query, CancellationToken cancellationToken)
        {
            var result = _calculator.Either(query.A, query.B);

            _log.Write($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()} {query.GetType().Name} for P({query.A}) and P({query.B}) = {result}");

            return Task.FromResult(result);
        }
    }
}
