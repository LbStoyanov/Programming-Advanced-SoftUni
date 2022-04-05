using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberOfElements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int firstSetElements = numberOfElements[0];//3
            int secondSetElements = numberOfElements[1];//4
            int totalElements = firstSetElements + secondSetElements;

            for (int i = 0; i < totalElements; i++)
            {
                int currentElement = int.Parse(Console.ReadLine());


                if (i >= firstSetElements)
                {
                    secondSet.Add(currentElement);
                }
                else
                {
                    firstSet.Add(currentElement);
                }
            }

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }
    }
}
