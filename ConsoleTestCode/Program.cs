using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestCode
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(VariableName("var_1__Int"));
        }

        public static bool VariableName(string variableName)
        {

            int minusOne = 47, ten = 58, underSocre = 95, a = 97, z = 122, A = 65, Z = 90;

            var isValid = false;
            var firstChar = Convert.ToInt16(variableName[0]);


            if (firstChar > minusOne && firstChar < ten)
                return false;

            foreach (int character in variableName)
            {
                var number = Convert.ToInt16(character);

                isValid = ((number == underSocre)
                            || (number >= a && number <= z)
                            || (number >= A && number <= Z)
                            || (number > minusOne && number < ten));

                var val1 = number == underSocre;
                var val2 = (number >= a && number <= z);
                var val3 = (number >= A && number <= Z);
                var val4 = (number > minusOne && number < ten);

                Console.WriteLine($"{character} {Convert.ToInt16(character)} [{isValid}]  val 1: {val1} val 2: {val2} val 3: {val3} val 4: {val4}");

                if (!isValid)
                    return false;


            }

            return isValid;
        }

    }
}
