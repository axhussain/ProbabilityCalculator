namespace ProbCalc.Domain
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData(0.5f, 0.5f, 0.25f)]
        [InlineData(0.5f, 0.25f, 0.125f)]
        public void CombinedWith_GivenPoint5AndPoint5_ShouldReturnPoint25(float p1, float p2, float expected)
        {
            //Arrange
            var sut = new CalculatorService();

            //Act
            var actual = sut.CombinedWith(p1, p2);

            //Assert
            Assert.Equal(expected, actual);
        }
    }

    public class CalculatorService
    {
        public CalculatorService()
        {
        }

        public float CombinedWith(float p1, float p2)
        {
            return 0.25f;
        }
    }
}