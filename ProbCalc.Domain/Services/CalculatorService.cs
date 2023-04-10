namespace ProbCalc.Domain.Services
{
    public class CalculatorService
    {
        public CalculatorService()
        {
        }

        public float CombinedWith(float pA, float pB)
        {
            ValidateProbability(pA);
            ValidateProbability(pB);

            var result = pA * pB;
            return result;
        }        

        public float Either(float pA, float pB)
        {
            ValidateProbability(pA);
            ValidateProbability(pB);

            var result = pA + pB - pA * pB;
            return result;
        }

        private static void ValidateProbability(float probability)
        {
            if (probability < 0 || probability > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(probability), "Probabilities must be within 0-1, inclusive.");
            }
        }
    }
}