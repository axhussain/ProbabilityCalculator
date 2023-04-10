namespace ProbCalc.Domain.Services
{
    public interface ICalculatorService
    {
        float CombinedWith(float pA, float pB);
        float Either(float pA, float pB);
    }
}