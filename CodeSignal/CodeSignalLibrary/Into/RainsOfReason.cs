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

        public static bool VariableName(string name)
        {
            int minusOne = 47, ten = 58, underSocre = 95, a = 97, z = 122, A = 65, Z = 90;
            var isValid = false;
            var firstChar = Convert.ToInt16(name[0]);


            if (firstChar > minusOne && firstChar < ten)
                return false;

            foreach (int character in name)
            {
                var number = Convert.ToInt16(character);

                isValid = ((number == underSocre)
                           || (number >= a && number <= z)
                           || (number >= A && number <= Z)
                           || (number > minusOne && number < ten));

                if (!isValid)
                    return false;

            }

            return isValid;
        }
    }
}
