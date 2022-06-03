using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class TriFunction
    {
        static void Main(string[] args)
        {
            int numberN = int.Parse(Console.ReadLine());

            List<string> people = Console.ReadLine().Split().ToList();

            foreach (var person in people)
            {
                int currentPersonValue = CalculateCharsSum(person);

                if (currentPersonValue >= numberN)
                {
                    Console.WriteLine(person);
                    break;
                }
            }

        }

        public static int CalculateCharsSum(string person)
        {
            int result = 0;

            for (int j = 0; j < person.Length; j++)
            {
                var currentChar = person[j];

                result += Convert.ToInt32(currentChar);
            }

            return result;
        }
    }
}
