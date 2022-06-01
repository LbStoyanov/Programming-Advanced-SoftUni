using System;
using System.Collections.Generic;

namespace FindEvensOrOdds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            string[] range = Console.ReadLine().Split(' ');

            int lowerBound = int.Parse(range[0]);  
            int upperBound = int.Parse(range[1]);  

            string type = Console.ReadLine();

            List<int> numbers = new List<int>();

            for (int i = lowerBound ; i <= upperBound; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> predicate = null;

            if (type == "even")
            {
                predicate = number => number % 2 == 0;
            }
            else if (type == "odd")
            {
                predicate = number => number % 2 != 0;
            }

            Console.WriteLine(String.Join(" ", numbers.FindAll(predicate)));
        }
    }
}
