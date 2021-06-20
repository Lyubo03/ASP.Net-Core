namespace WorkingWithData.Tests
{
    using System;
    using ValidationAttributes;
    using Xunit;

    public class BeforeCurrentYearAttributeTests
    {
        [Theory]
        [InlineData(1899,1900,false)]
        [InlineData(1900, 1900, true)]
        [InlineData(1900, 1901, false)]
        [InlineData(1900, 2021, false)]
        [InlineData(1900, int.MinValue, true)]
        [InlineData(1900, int.MaxValue, false)]
        [InlineData(1900, -1, true)]
        [InlineData(-1900, 2018, false)]
        [InlineData(0, 0, true)]

        public void IsValidShouldWorkCorrectly(int year, int afterYear, bool expected)
        {
            //Arrange
            var attribute = new BeforeCurrentYearAttribute(afterYear);

            //Act
            var result = attribute.IsValid(year);

            //Assert
            Assert.Equal(expected,result);
        }
        [Fact]
        public void IsValidShouldWithCurrentYearShouldReturnTrue()
        {
            //Arrange
            const int afterYear = 1900;
            var attribute = new BeforeCurrentYearAttribute(afterYear);

            //Act
            var result = attribute.IsValid(DateTime.UtcNow.Year);

            //Assert
            Assert.True(result);
        }
    }
}