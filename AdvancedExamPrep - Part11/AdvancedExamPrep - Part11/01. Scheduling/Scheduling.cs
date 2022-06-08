using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Scheduling
    {
        static void Main(string[] args)
        {
            int[] tasksInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> tasks = new Stack<int>(tasksInput);

            int[] threadsInput  = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> threads = new Queue<int>(threadsInput );

            int taskToKill = int.Parse(Console.ReadLine());

            bool isTaskToKillFinished = false;

            while (true)
            {
                var currentTask = tasks.Peek();
                var currnetThread = threads.Peek();

                if (currnetThread >= currentTask)
                {
                    if (currentTask == taskToKill)
                    {
                        Console.WriteLine($"Thread with value {currnetThread} killed task {taskToKill}");
                        break;
                    }
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    if (currentTask == taskToKill)
                    {
                        Console.WriteLine($"Thread with value {currnetThread} killed task {taskToKill}");
                        break;
                    }
                    threads.Dequeue();
                }

            }

            while (threads.Count > 0)
            {
                Console.Write(threads.Dequeue() + " ");
            }
        }
    }
}
