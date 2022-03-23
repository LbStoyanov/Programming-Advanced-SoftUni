using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            int push = 1;
            int delete = 2;
            int printMax = 3;
            

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] currentCommand = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                int currentQuary = currentCommand[0];
                

                if (currentQuary == push)
                {
                    int elementToPush = currentCommand[1];
                    stack.Push(elementToPush);
                }
                else if (currentQuary == delete)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (currentQuary == printMax)
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Max());
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    Console.WriteLine(stack.Min());
                }
            }
            
            while (stack.Count > 0)
            {
                if (stack.Count == 1)
                {
                    Console.Write(stack.Pop());
                }
                else
                {
                    Console.Write(stack.Pop() + ", ");
                }
            }
        }
    }
}
