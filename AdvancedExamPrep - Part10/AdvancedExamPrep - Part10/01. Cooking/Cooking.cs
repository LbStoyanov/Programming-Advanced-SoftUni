using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    internal class Cooking
    {
        static void Main(string[] args)
        {
            const int Bread = 25;
            const int Cake = 50;
            const int Pastry = 75;
            const int FruitPie = 100;

            var bakedProducts = new Dictionary<string, int>
            {
                {"Bread",0 },
                {"Cake",0 },
                {"Pastry",0 },
                {"Fruit Pie",0 },
            };

            int[] liquidsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> liquids = new Queue<int>(liquidsInput);

            int[] ingredientsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> ingredients = new Stack<int>(ingredientsInput);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                var currentLiquid = liquids.Peek();
                var currentIngredient = ingredients.Peek();

                var obtainedValueByMixing = currentLiquid + currentIngredient;

                if (obtainedValueByMixing == Bread)
                {
                    bakedProducts["Bread"]++;
                    ingredients.Pop();
                }
                else if (obtainedValueByMixing == Cake)
                {
                    bakedProducts["Cake"]++;
                    ingredients.Pop();
                }
                else if (obtainedValueByMixing == Pastry)
                {
                    bakedProducts["Pastry"]++;
                    ingredients.Pop();
                }
                else if (obtainedValueByMixing == FruitPie)
                {
                    bakedProducts["Fruit Pie"]++;
                    ingredients.Pop();
                }
                else
                {
                    int increasedValueOfIngredient = ingredients.Peek() + 3;
                    ingredients.Pop();
                    ingredients.Push(increasedValueOfIngredient);
                }

                liquids.Dequeue();

            }

            if (bakedProducts.All(x => x.Value > 0))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count > 0)
            {
                var leftLiquieds = liquids.ToList();
                Console.WriteLine($"Liquids left: {string.Join(", ",leftLiquieds)}");
               
            }
            else
            {
                Console.WriteLine($"Liquids left: none");
            }

            if (ingredients.Count > 0)
            {
                var leftIngredients = ingredients.ToList();
                Console.WriteLine($"Ingredients left: {string.Join(", ", leftIngredients)}");

            }
            else
            {
                Console.WriteLine($"Ingredients left: none");
            }

            var orderedProducts = bakedProducts.OrderBy(x => x.Key);

            foreach (var product in orderedProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

        }
    }
}
