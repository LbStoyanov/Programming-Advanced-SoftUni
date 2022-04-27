using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bakery = new Dictionary<string, int>
            {
                {"Muffin",0 },
                {"Baguette",0 },
                {"Bagel",0 },
                {"Croissant",0 }
            };
            double[] waterInput = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Queue<double> water = AddWater(waterInput);

            double[] flourInput = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            Stack<double> flour = AddFlour(flourInput);

            while (water.Count > 0 && flour.Count > 0)
            {
                var currentWaterQuantity = water.Peek();
                var currentFlourQuantity = flour.Peek();

                double currenWatertRatio = CalculateWaterRatio(currentWaterQuantity, currentFlourQuantity);

                if (currenWatertRatio == 20)
                {
                    Bake(water,flour);
                    bakery["Bagel"]++;
                }
                else if (currenWatertRatio == 30)
                {
                    Bake(water, flour);
                    bakery["Baguette"]++;
                }
                else if (currenWatertRatio == 40)
                {
                    Bake(water, flour);
                    bakery["Muffin"]++;
                }
                else 
                {
                    BakeCroissant(water, flour);
                    bakery["Croissant"]++;
                }

            }

            var orderedBakery = bakery.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();

            foreach (var product in orderedBakery)
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.Write("Water left: ");
                var waterLeft = water.ToList();
                Console.WriteLine(String.Join(", ",waterLeft));
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.Write("Flour left: ");
                var flourLeft = flour.ToList();
                Console.WriteLine(String.Join(", ",flour));
            }
            
        }

        private static void BakeCroissant(Queue<double> water, Stack<double> flour)
        {
            //flour.Pop();
            double remainingFlour = flour.Pop() - water.Peek();
            water.Dequeue();
            if (remainingFlour > 0)
            {
                flour.Push(remainingFlour);
            }
            
        }

        private static void Bake(Queue<double> water, Stack<double> flour)
        {
            water.Dequeue();
            flour.Pop();
        }

        private static double CalculateWaterRatio(double currentWaterQuantity, double currentFlourQuantity)
        {
            double totalRatio = currentWaterQuantity + currentFlourQuantity;

            double finalCombinationOfIngredients = (currentWaterQuantity * 100) / totalRatio;

            return finalCombinationOfIngredients;
        }

        private static Stack<double> AddFlour(double[] waterInput)
        {
            Stack<double> flourStack = new Stack<double>();

            for (int i = 0; i < waterInput.Length; i++)
            {
                flourStack.Push(waterInput[i]);
            }
            
            return flourStack;
        }

        public static Queue<double> AddWater(double[] waterInput)
        {
            Queue<double> queue = new Queue<double>();

            for (int i = 0; i < waterInput.Length; i++)
            {
                queue.Enqueue(waterInput[i]);
            }

            return queue;
        }
    }
}
