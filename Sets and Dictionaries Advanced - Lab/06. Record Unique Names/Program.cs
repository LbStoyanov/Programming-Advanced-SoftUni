using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string currentName = Console.ReadLine();
                uniqueNames.Add(currentName);
            }
            Console.WriteLine();
            Console.WriteLine(string.Join("\n",uniqueNames));
        }
    }
}
