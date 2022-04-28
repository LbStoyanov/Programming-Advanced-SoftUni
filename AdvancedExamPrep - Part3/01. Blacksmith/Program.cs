using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        //public const int GladiusResourseNeeded = 70;
        //public const int ShamirResourseNeeded = 80;
        //public const int KatanaResourseNeeded = 90;
        //public const int SarbeResourseNeeded = 110;
        //public const int BroadswordResourseNeeded = 150;
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>();

            int[] steelInput =  Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            AddSteel(steel, steelInput);

            Stack<int> carbon = new Stack<int>();

            int[] carbonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            AddCarbon(carbon, carbonInput);

            //Check if there is already that kind of sword made!!!
            var forgedSwords = new Dictionary<string, List<int>>
            {
                {"Gladius",new List<int>{ 70,0} },
                {"Shamshir",new List<int>{ 80,0} },
                {"Katana",new List<int>{ 90,0} },
                {"Sabre",new List<int>{110,0 } },
                {"Broadsword",new List<int>{ 150,0} },
            };
            

            while (steel.Count > 0 || carbon.Count > 0)
            {
                ForgSwords(steel, carbon,forgedSwords);
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
