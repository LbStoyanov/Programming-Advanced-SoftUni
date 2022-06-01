using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>,List<int>> func = list => list.Select(number => number += 1).ToList();

            //Action<int> action = null;
            string command;

            while ((command = Console.ReadLine()) != "end")
            {

                if (command == "add")
                {
                    func = list => list.Select(number => number += 1).ToList();
                }
                if (command == "multiply")
                {
                    func = list => list.Select(number => number *= 2).ToList();
                }
                if (command == "subtract")
                {
                    func = list => list.Select(number => number -= 1).ToList();
                }
                if (command == "print")
                {
                    Action<List<int>> action = num => Console.WriteLine(string.Join(" ", num));
                    action(numbers);
                    continue;
                }

                 numbers = func(numbers);
            }
        }
    }
}
