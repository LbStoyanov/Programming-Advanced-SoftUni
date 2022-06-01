using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<HashSet<int>, int> returnSmallestNum = set => set.Min();

            var numbers = Console.ReadLine().Split().Select(int.Parse).ToHashSet();

            Console.WriteLine(returnSmallestNum(numbers));
        }
    }
}
