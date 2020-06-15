using System;

namespace CodeSignalLibrary
{
    public class RainsOfReason
    {
        public static bool EvenDigitsOnly(in int input)
        {
            var numbers = input.ToString();

            foreach (var num in numbers)
                if ((int)num % 2 != 0)
                    return false;

            return true;
        }
    }
}
