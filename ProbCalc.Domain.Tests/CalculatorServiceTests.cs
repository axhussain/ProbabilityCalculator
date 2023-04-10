namespace ProbCalc.Domain
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(0.5f, 0.5f, 0.25f)]
        [InlineData(0.5f, 0.25f, 0.125f)]
        public void CombinedWith_GivenPoint5AndPoint5_ShouldReturnPoint25(float pA, float pB, float expected)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act
            var actual = sut.CombinedWith(pA, pB);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.5f, -0.5f)]
        [InlineData(1.1f, 0.25f)]
        public void CombinedWith_GivenAnInvalidInput_ShouldThrow(float pA, float pB)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.CombinedWith(pA, pB));
        }
    }

    public class CalculatorService
    {
        public CalculatorService()
        {
        }

        public float CombinedWith(float pA, float pB)
        {
            if (pA < 0 || pA > 1) 
            {
                throw new ArgumentOutOfRangeException(nameof(pA), "Probabilities must be within 0-1, inclusive.");
            }

            if (pB < 0 || pB > 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pA), "Probabilities must be within 0-1, inclusive.");
            }

            var result = pA * pB;
            return result;
        }
    }
}