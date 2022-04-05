using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueElements = new HashSet<string>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    uniqueElements.Add(input[j]);
                }
            }

            foreach (var item in uniqueElements.OrderBy(x =>x))
            {
                Console.Write(item + " ");
            }
        }
    }
}
