
using System.Text.RegularExpressions;

namespace LeetCodeUnitTest
{
    public class UnitTest1
    {

        //        Console.WriteLine(Teste(new String[]{ "flower","flow","flight" }));
        //		Console.WriteLine(Teste(new String[]{ "dog","racecar","car" }));
        //Console.WriteLine(Teste(new String[] { "" }));
        //Console.WriteLine(Teste(new String[] { "a" }));


        public static IEnumerable<object[]> LongestCommonTestData =>
        new List<object[]>
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

        [Theory]
        [MemberData(nameof(LongestCommonTestData))]
        public void LongestCommonPrefixTest(string[] strs, string expected)
        {
            Assert.Equal(expected, LongestCommonPrefix(strs));
        }

        private string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 2)
            {
                return strs[0];
            }

            string smaller = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                if (smaller.Length > strs[i].Length)
                {
                    smaller = strs[i];
                }
            }

            for (int i = 0; i < strs.Length; i++)
            {
                string current = strs[i];

                string key = "";

                for (int a = 0; a < smaller.Length; a++)
                {
                    if (current[a] == smaller[a])
                    {
                        key += current[a];
                    }
                    else
                    {
                        break;
                    }
                }

                smaller = key;
            }

            return smaller;
        }


        private string LongestCommonPrefix4(string[] strs)
        {
            if (strs.Length < 2)
            {
                return strs[0];
            }

            Dictionary<string, int> prefixs = new Dictionary<string, int>();

            string smaller = strs[0];

            for (int i = 1; i < strs.Length; i++)
            {
                if(smaller.Length > strs[i].Length)
                {
                    smaller = strs[i];
                }
            }

            for (int i = 0; i < strs.Length; i++)
            {
                string current = strs[i];

                string key = "";

                for (int a = 0; a < smaller.Length; a++)
                {
                    if (current[a] == smaller[a])
                    {
                        key += current[a];
                    }
                    else
                    {
                        break;
                    }
                }

                smaller = key;

                //if (!prefixs.TryGetValue(key, out var value))
                //{
                //    prefixs.Add(key, 1);
                //}
                //else
                //{
                //    prefixs[key]++;
                //}
            }

            //string matchkey = "";
            //int matchs = 0;

            //foreach (var item in prefixs)
            //{
            //    if (item.Key.Length > matchkey.Length &&
            //        item.Value >= matchs)
            //    {
            //        matchkey = item.Key;
            //        matchs = item.Value;
            //    }
            //}

            //if(matchs == strs.Length) 
            //{
            //    return matchkey;
            //}

            return smaller;
        }

        private string LongestCommonPrefix3(string[] strs)
        {
            Dictionary<string, int> prefixs = new Dictionary<string, int>();

            if (strs.Length < 2)
            {
                return strs[0];
            }

            string key = "", firstWord = strs[0];
            for (int i = 1; i < strs.Length; i++)
            {
                string currentWord = strs[i], wordRef = "";

                int count = 0;

                if (firstWord.Length <= currentWord.Length)
                {
                    wordRef = firstWord;
                    for (int l = 0; l < firstWord.Length; l++)
                    {
                        if (firstWord[l] == currentWord[l])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    wordRef = currentWord;
                    for (int l = 0; l < currentWord.Length; l++)
                    {
                        if (firstWord[l] == currentWord[l])
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                key = "";
                for (int a = 0; a < count; a++)
                {
                    key += wordRef[a];

                    if (!prefixs.TryGetValue(key, out var value))
                    {
                        prefixs.Add(key, 1);
                    }
                    else
                    {
                        prefixs[key]++;
                    }
                }

            }

            KeyValuePair<string, int> resultkey = new KeyValuePair<string, int>("", 0);

            foreach (var item in prefixs)
            {
                if (item.Key.Length > resultkey.Key.Length &&
                    item.Value >= resultkey.Value)
                {
                    resultkey = item;
                }
            }

            return resultkey.Key;
        }

        private string LongestCommonPrefixV1(string[] strs)
        {
            Dictionary<string, int> prefixs = new Dictionary<string, int>();

            if (strs.Length < 2)
            {
                return strs[0];
            }

            for (int i = 0; i < strs.Length; i++)
            {
                string current = strs[i];

                for (int j = 0; j < strs.Length; j++)
                {
                    string match = strs[j];
                    if (current == match)
                    {
                        continue;
                    }


                    int count = 0;
                    bool isMatchSmaller = current.Length <= match.Length;


                    if (isMatchSmaller)
                    {
                        for (int l = 0; l < current.Length; l++)
                        {
                            if (current[l] == match[l])
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int l = 0; l < match.Length; l++)
                        {
                            if (current[l] == match[l])
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    string key = "";
                    for (int a = 0; a < count; a++)
                    {
                        key += current[a];

                        if (!prefixs.TryGetValue(key, out var value))
                        {
                            prefixs.Add(key, 1);
                        }
                        else
                        {
                            prefixs[key]++;
                        }
                    }
                }
            }

            KeyValuePair<string, int> resultkey = new KeyValuePair<string, int>("", 0);

            foreach (var item in prefixs)
            {
                if (item.Key.Length > resultkey.Key.Length &&
                    item.Value >= resultkey.Value)
                {
                    resultkey = item;
                }
            }

            return resultkey.Key;
        }
    }
}
