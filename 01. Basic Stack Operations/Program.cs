using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] specificIntegers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int elementsToPush = specificIntegers[0];
            int elementsToPop = specificIntegers[1];
            int elementToSearch = specificIntegers[2];

            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();
            if (integers.Length < elementsToPush)
            {
                elementsToPush = integers.Length;
            }

            for (int i = 0; i < elementsToPush; i++)
            {
                var currentElement = integers[i];
                stack.Push(currentElement);
            }

            if (stack.Count < elementsToPop)
            {
                elementsToPop = stack.Count;
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
