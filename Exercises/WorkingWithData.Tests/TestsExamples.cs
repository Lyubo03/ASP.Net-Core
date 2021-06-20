namespace WorkingWithData.Tests
{
    using System;
    using Xunit;

    public class TestExamples
    {
        [Theory]
        [InlineData(2,10,1024)]
        [InlineData(5, 2, 25)]
        [InlineData(2, 5, 32)]

        public void TestMathPowShouldReturn1024WhenGiven2And10(int a, int exp, int expectedResult)
        {
            //Arrange
            //ACT
            var result = Math.Pow(a, exp);
            //ASSERT

            Assert.Equal(expectedResult, result);

            //if (result != 1024)
            //{
            //    throw new Exception("Not 1024");
            //}
        }

        [Fact]
        public void StringEqualsTest()
        {
            Assert.Contains("Lyubo", "Hello, Lyubo");
        }
    }
}