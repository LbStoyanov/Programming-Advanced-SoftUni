using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            int rackCapacity = int.Parse(Console.ReadLine());

            for (int i = clothesInTheBox.Length - 1; i >= 0; i--)
            {
                var currentCloth = clothesInTheBox[i];
                stack.Push(currentCloth);
            }

            //for (int i = 0; i < clothesInTheBox.Length; i++)
            //{
            //    var currentCloth = clothesInTheBox[i];
            //    stack.Push(currentCloth);
            //}

            int racksUsed = 0;
            int clothesValueSum = 0;

            while (stack.Count > 0)
            {
                var currentCloth = stack.Peek();
                if (stack.Count == 1 && clothesValueSum + currentCloth > rackCapacity)
                {
                    racksUsed++;
                    stack.Pop();
                }
                if (stack.Count == 1 && clothesValueSum + currentCloth <= rackCapacity)
                {
                    stack.Pop();
                    continue;
                }
                if (clothesValueSum + currentCloth <= rackCapacity)
                {
                    clothesValueSum += currentCloth;
                    stack.Pop();
                }
                else
                {
                    racksUsed++;
                    clothesValueSum = 0;

                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
