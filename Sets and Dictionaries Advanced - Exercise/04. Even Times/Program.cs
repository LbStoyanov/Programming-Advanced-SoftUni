using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {

            var numbersAndCount = new Dictionary<int, int>();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var number = int.Parse(Console.ReadLine());
                if (numbersAndCount.ContainsKey(number))
                {
                    numbersAndCount[number]++;
                }
                else
                {
                    numbersAndCount.Add(number, 1);
                }
            }

            var evenTimesNumber = numbersAndCount.First(kvp => kvp.Value % 2 == 0).Key;

            Console.WriteLine(evenTimesNumber);

            //HashSet<int> uniqueElements = new HashSet<int>();

            //int countOfIntegers = int.Parse(Console.ReadLine());

            //for (int i = 0; i < countOfIntegers; i++)
            //{
            //    int currentElement = int.Parse(Console.ReadLine());

            //    if (uniqueElements.Contains(currentElement))
            //    {
            //        Console.WriteLine(currentElement);
            //        return;
            //    }

            //    uniqueElements.Add(currentElement);
            //}
        }
    }
}
