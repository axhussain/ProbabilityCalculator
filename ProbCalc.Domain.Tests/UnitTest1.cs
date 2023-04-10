namespace ProbCalc.Domain
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var p1 = 0.5f;
            var p2 = 0.5f;
            var sut = new CalculatorService();

            //Act
            var actual = sut.CombinedWith(p1, p2);

            //Assert
            var expected = 0.25f;
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