
using LeetCodeUnitTest.Challenges;

namespace LeetCodeUnitTest
{
    public class EasyChallengeUnitTest
    {
        [Theory]
        [MemberData(nameof(LongestCommonInputs))]
        public void LongestCommonPrefixTest(string[] strs, string expected)
        {
            Assert.Equal(expected, EasyChallenges.LongestCommonPrefix(strs));
        }        
        
        [Theory]
        [MemberData(nameof(ValidParenthesesInputs))]
        public void ValidParenthesesTest(string strs, bool expected)
        {
            Assert.Equal(expected, EasyChallenges.ValidParentheses(strs));
        }

        #region Inputs
        public static IEnumerable<object[]> LongestCommonInputs => new List<object[]>
                                            {
                                                new object[] { new string[] { "flower", "flow", "flight" } , "fl" },
                                                new object[] { new string[] { "reflower", "flow", "flight" } , ""},
                                                new object[] { new string[] { "flower", "flower", "flower", "flower" } , "flower"},
                                                new object[] { new string[] { "dog", "racecar", "car" } , ""},
                                                new object[] { new string[] { "a", "a", "b" } , ""},
                                                new object[] { new string[] { "aca","cba" } , ""},
                                                new object[] { new string[] { "" }, "" }, // Empty array
                                                new object[] { new string[] { "a" }, "a" } // Empty array
                                            };

        public static IEnumerable<object[]> ValidParenthesesInputs => new List<object[]>
                                            {
                                                new object[] { "()", true },
                                                new object[] { "()[]{}", true },
                                                new object[] { "(]", false },
                                                new object[] { "([])", true },
                                            };


        #endregion
    }
}
