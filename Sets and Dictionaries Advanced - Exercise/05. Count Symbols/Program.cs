using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var occurences = new Dictionary<char, int>();



            for (int i = 0; i < text.Length; i++)
            {
                char currentChar = text[i];

                if (!occurences.ContainsKey(currentChar))
                {
                    occurences.Add(currentChar, 0);
                }

                occurences[currentChar]++;

            }

            foreach (var item in occurences.OrderBy(x => x.Key))
            {
                char currentChar = item.Key;
                int timesOfOccurence = item.Value;

                Console.WriteLine($"{currentChar}: {timesOfOccurence} time/s");
            }
        }
    }
}
