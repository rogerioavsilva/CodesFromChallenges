using CodeSignalLibrary;
using Xunit;

namespace CodeSignalXUnitTest.Intro
{
    public class RainsOfReasonTest
    {
        [Fact]
        public void EvenDigitsOnlyTest1()
        {
            //Arrange
            var input = 248622;
            //Act
            bool isEven = RainsOfReason.EvenDigitsOnly(input);
            //Assert
            Assert.True(isEven);

        }

        [Theory]
        [InlineData(true, 248622)]
        [InlineData(false, 642386)]
        public void EvenDigitsOnlyTest2(bool expected, int input) =>
            Assert.Equal(expected, RainsOfReason.EvenDigitsOnly(input));

    }
}