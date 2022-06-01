using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int divisibleNum = int.Parse(Console.ReadLine());

            Action<List<int>> reverseAction = list => list.Reverse();

            reverseAction(numbers);

            Func<List<int>, List<int>> removeFunc = list => list.FindAll(x => x % divisibleNum != 0).ToList();

            removeFunc(numbers).ForEach(x => Console.Write(x + " "));

            //Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
