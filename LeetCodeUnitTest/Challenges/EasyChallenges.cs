
namespace LeetCodeUnitTest.Challenges
{
    internal static class EasyChallenges
    {
        public static string LongestCommonPrefix(string[] strs)
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


        public static string LongestCommonPrefix4(string[] strs)
        {
            if (strs.Length < 2)
            {
                return strs[0];
            }

            Dictionary<string, int> prefixs = new Dictionary<string, int>();

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

        public static string LongestCommonPrefix3(string[] strs)
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

        public static string LongestCommonPrefixV1(string[] strs)
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

        internal static bool ValidParentheses(string s)
        {
            const char parenOpen = '(';
            const char parenClose = ')';
            const char bracketsOpen = '[';
            const char bracketsClose = ']';
            const char bracesOpen = '{';
            const char bracesClose = '}';

            if ((s[0] == parenClose ||
                s[0] == bracketsClose ||
                s[0] == bracesClose) ||
                (s[s.Length - 1] == parenOpen ||
                s[s.Length - 1] == bracketsOpen ||
                s[s.Length - 1] == bracesOpen))
            {
                return false;
            }


            Dictionary<char, int> token = new Dictionary<char, int>();
            token.Add(parenClose, 0);
            token.Add(parenOpen, 0);
            token.Add(bracketsOpen, 0);
            token.Add(bracketsClose, 0);
            token.Add(bracesOpen, 0);
            token.Add(bracesClose, 0);

            char last = ' ';
            foreach (char item in s)
            {
                switch (item)
                {
                    case parenClose:
                        if (last == bracketsOpen || last == bracesOpen)
                        {
                            return false;
                        }
                        break;
                    case bracketsClose:
                        if (last == parenOpen || last == bracesOpen)
                        {
                            return false;
                        }
                        break;
                    case bracesClose:
                        if (last == bracketsOpen || last == parenOpen)
                        {
                            return false;
                        }
                        break;
                    default:
                        break;
                }

                if (!token.TryAdd(item, 0))
                {
                    token[item]++;
                }

                last = item;
            }

            if (!(token[parenOpen] - (token[parenClose]) == 0))
            {
                return false;
            }

            if (!(token[bracketsOpen] - (token[bracketsClose]) == 0))
            {
                return false;
            }

            if (!(token[bracesOpen] - (token[bracesClose]) == 0))
            {
                return false;
            }


            return true;
        }
    }
}
