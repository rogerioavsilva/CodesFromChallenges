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


        [Theory]
        [InlineData(true, "var_1__Int")]
        [InlineData(false, "qq-q")]
        [InlineData(false, "2w2")]
        [InlineData(false, " variable")]
        [InlineData(false, "va[riable0")]
        [InlineData(true, "variable0")]
        public void VariableNameTest1(bool expected, string variableName) =>
            Assert.Equal(expected, RainsOfReason.VariableName(variableName));

    }
}