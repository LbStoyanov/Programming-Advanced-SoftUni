using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < numberOfNames; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            uniqueNames.ToList().ForEach(uniqueName => Console.WriteLine(uniqueName));

            
            //Console.WriteLine(string.Join("\n",uniqueNames));
        }
    }
}
 