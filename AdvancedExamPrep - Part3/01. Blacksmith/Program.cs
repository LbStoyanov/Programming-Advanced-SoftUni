using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>();

            int[] steelInput =  Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            AddSteel(steel, steelInput);

            Stack<int> carbon = new Stack<int>();

            int[] carbonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            AddCarbon(carbon, carbonInput);

            
            var forgedSwords = new Dictionary<string, List<int>>
            {
                {"Gladius",new List<int>{ 70,0} },
                {"Shamshir",new List<int>{ 80,0} },
                {"Katana",new List<int>{ 90,0} },
                {"Sabre",new List<int>{110,0 } },
                {"Broadsword",new List<int>{ 150,0} },
            };
            

            while (steel.Count > 0 && carbon.Count > 0)
            {
                ForgSwords(steel, carbon,forgedSwords);
            }

            PrintResult(forgedSwords,steel,carbon);

        }
        public static void PrintResult(Dictionary<string, List<int>> forgedSwords, Queue<int> steel, Stack<int> carbon, int totalNumberOfSwords =0)
        {
            foreach (var sword in forgedSwords)
            {
                if (forgedSwords[sword.Key][1] > 0)
                {
                    totalNumberOfSwords += forgedSwords[sword.Key][1];
                }

            }
            if (totalNumberOfSwords > 0)
            {
                Console.WriteLine($"You have forged {totalNumberOfSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                var steelLeft = steel.ToList();
                Console.WriteLine($"Steel left: {string.Join(", ", steelLeft)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                var carbonLeft = carbon.ToList();
                Console.WriteLine($"Carbon left: {string.Join(", ", carbonLeft)}");
            }

            foreach (var item in forgedSwords.OrderBy(x => x.Key))
            {
                if (forgedSwords[item.Key][1] > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value[1]}");
                }
                
            }
        }

        private static void ForgSwords(Queue<int> steel, Stack<int> carbon, Dictionary<string, List<int>> forgedSwords)
        {
            var currentSteelQuantity = steel.Peek();
            var currentCarbonQuantity = carbon.Peek();

            var obtainedResourceQuantity = currentSteelQuantity + currentCarbonQuantity;

            if (!forgedSwords.Any(x => x.Value[0] == obtainedResourceQuantity))
            {
                steel.Dequeue();
                int incriesedCarbonValeue = carbon.Pop() + 5;
                carbon.Push(incriesedCarbonValeue);

            }
            else
            {
                if (obtainedResourceQuantity == forgedSwords["Gladius"][0])
                {
                    forgedSwords["Gladius"][1]++;
                    
                }
                else if (obtainedResourceQuantity == forgedSwords["Shamshir"][0])
                {
                    forgedSwords["Shamshir"][1]++;
                }
                else if (obtainedResourceQuantity == forgedSwords["Katana"][0])
                {
                    forgedSwords["Katana"][1]++;
                }
                else if (obtainedResourceQuantity == forgedSwords["Sabre"][0])
                {
                    forgedSwords["Sabre"][1]++;
                }
                else if (obtainedResourceQuantity == forgedSwords["Broadsword"][0])
                {
                    forgedSwords["Broadsword"][1]++;
                }

                steel.Dequeue();
                carbon.Pop();
            }
        }

        private static void AddCarbon(Stack<int> carbon, int[] carbonInput)
        {
            for (int i = 0; i < carbonInput.Length; i++)
            {
                var currentElement = carbonInput[i];

                carbon.Push(currentElement);
            }
        }

        private static void AddSteel(Queue<int> steel, int[] steelInput)
        {
            for (int i = 0; i < steelInput.Length; i++)
            {
                var currentElement = steelInput[i];

                steel.Enqueue(currentElement);
            }
        }
    }
}
