using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] specificIntegers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int elementsToEnqueue = specificIntegers[0];
            int elementsToDequeue = specificIntegers[1];
            int elementToSearch = specificIntegers[2];

            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            if (integers.Length < elementsToEnqueue)
            {
                elementsToEnqueue = integers.Length;
            }

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                var currentElement = integers[i];
                queue.Enqueue(currentElement);
            }

            if (queue.Count < elementsToDequeue)
            {
                elementsToDequeue = queue.Count;
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
