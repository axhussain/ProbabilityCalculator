using ProbCalc.Domain.Services;

namespace ProbCalc.Domain
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(0.5f, 0.5f, 0.25f)]
        [InlineData(0.5f, 0.25f, 0.125f)]
        public void CombinedWith_GivenTwoValidInputs_ShouldReturnTheProduct(float pA, float pB, float expected)
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
}