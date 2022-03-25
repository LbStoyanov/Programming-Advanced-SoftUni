using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            cupsCapacity.Reverse();
            var bottlesWithWater = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            Stack<int> bottles = new Stack<int>(bottlesWithWater);
            Stack<int> cups = new Stack<int>(cupsCapacity);
            int wastedWater = 0;
            

            while (true)
            {
                var currentBottle = bottles.Peek();
                var currentCup = cups.Peek();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                    cups.Pop();
                    bottles.Pop();
                }
                else
                {
                    
                    int modifiedCup = currentCup - currentBottle;
                    bottles.Pop();
                    cups.Pop();
                    cups.Push(modifiedCup);
                    wastedWater = 0;
                }

                if (bottles.Count == 0 || cups.Count == 0)
                {
                    break;
                }
            }

            if (cups.Count > 0)
            {
                var listOfCupsLeft = new List<int>();
                while (cups.Count > 0)
                {
                    listOfCupsLeft.Add(cups.Pop());
                }
                Console.WriteLine($"Cups: {string.Join(" ",listOfCupsLeft)}");
            }
            else if(bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {bottles.Count}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
