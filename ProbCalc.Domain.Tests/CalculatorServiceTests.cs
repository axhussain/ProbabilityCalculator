using ProbCalc.Domain.Services;
using FluentAssertions;

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
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(0.5f, -0.5f)]
        [InlineData(1.1f, 0.25f)]
        public void CombinedWith_GivenAnInvalidInput_ShouldThrow(float pA, float pB)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act and Assert
            sut.Invoking(x => x.CombinedWith(pA, pB))
               .Should()
               .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0.5f, 0.5f, 0.75f)]
        public void Either_GivenTwoValidInputs_ShouldReturnProbabilityOfEither(float pA, float pB, float expected)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act
            var actual = sut.Either(pA, pB);

            //Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData(0.5f, -0.5f)]
        [InlineData(1.1f, 0.25f)]
        public void Either_GivenAnInvalidInput_ShouldThrow(float pA, float pB)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act and Assert
            sut.Invoking(x => x.Either(pA, pB))
               .Should()
               .Throw<ArgumentOutOfRangeException>();
        }
    }
}
