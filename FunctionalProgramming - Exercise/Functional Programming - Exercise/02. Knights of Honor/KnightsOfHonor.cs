using System;
using System.Linq;

namespace KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> printNameByAddingNewWordInfront = name => Console.WriteLine($"Sir {name}"); 

            var nameCollection = Console.ReadLine().Split().ToList();

            foreach (var name in nameCollection)
            {
                printNameByAddingNewWordInfront(name);
            }
        }
    }
}
