using System;
using System.Collections.Generic;
using System.Linq;

namespace Task._01
{
    internal class StartUp
    {
        private const int Cortado = 50;
        private const int Espresso = 75;
        private const int Capuccino = 100;
        private const int Americano = 150;
        private const int Latte = 200;
        static void Main(string[] args)
        {
            Dictionary<string, int> coffeCatalog = new Dictionary<string, int>
            {
                {"Cortado",0},
                {"Espresso",0},
                {"Capuccino",0},
                {"Americano",0},
                {"Latte",0},

            };
            
            int[] coffeeInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> coffeeQuantity = new Queue<int>(coffeeInput);

            int[] milkInput = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> milkQuantity = new Stack<int>(milkInput);

           
            

            while (coffeeQuantity.Count != 0 && milkQuantity.Count != 0)
            {
                var currentCoffeeQuantity = coffeeQuantity.Peek();
                var currentMilkQuantity = milkQuantity.Peek();

                
                var sum = currentCoffeeQuantity + currentMilkQuantity;

                if (sum == Cortado)
                {
                    coffeCatalog["Cortado"]++;
                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else if (sum == Espresso)
                {
                    coffeCatalog["Espresso"]++;
                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else if (sum == Capuccino)
                {
                    coffeCatalog["Capuccino"]++;
                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else if (sum == Americano)
                {
                    coffeCatalog["Americano"]++;
                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else if (sum == Latte)
                {
                    coffeCatalog["Latte"]++;
                    coffeeQuantity.Dequeue();
                    milkQuantity.Pop();
                }
                else
                {
                    coffeeQuantity.Dequeue();
                    var decreasedMilk = milkQuantity.Pop() - 5;
                    milkQuantity.Push(decreasedMilk);
                }
            }

            if (milkQuantity.Count > 0 || coffeeQuantity.Count > 0)
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            if (coffeeQuantity.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffeeQuantity)}");
            }

            if (milkQuantity.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", milkQuantity)}");
            }

            var orderedCofeeCatalog = coffeCatalog.OrderBy(x => x.Value).ThenByDescending(x => x.Key);

            foreach (var drink in orderedCofeeCatalog)
            {
                if (drink.Value > 0)
                {
                    Console.WriteLine($"{drink.Key}: {drink.Value}");
                }
                
            }
        }
    }
}
