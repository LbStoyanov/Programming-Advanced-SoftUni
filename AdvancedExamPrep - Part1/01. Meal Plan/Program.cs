using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var ingredients = new Dictionary<string, int>
            {
                {"salad",350 },
                {"soup",490 },
                {"pasta",680 },
                {"steak",790 }
            };


            Queue meals = new Queue();

            Stack<int> calories = new Stack<int>();

            string[] mealsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            meals = AddMeals(mealsInput);

            int[] dailyCalories = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            calories = AddCalories(dailyCalories);

            int mealsCounter = 0;

            while (meals.Count != 0 && calories.Count != 0)
            {
                Consumption(meals, calories, ingredients);
                mealsCounter++;
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsCounter} meals.");

                var caloriesList = ExtractCaloriesLeft(calories);
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesList)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsCounter} meals.");

                var mealsList = ExtractMealsLeft(meals);
                Console.WriteLine($"Meals left: {string.Join(", ", mealsList)}.");
            }
        }
        public static List<string> ExtractMealsLeft(Queue meals)
        {
            var list = new List<string>();
            while (meals.Count != 0)
            {
                list.Add(meals.Dequeue().ToString());
            }

            return list;

        }

        public static List<int>  ExtractCaloriesLeft(Stack<int> calories)
        {
            var list = new List<int>();
            while (calories.Count != 0)
            {
                list.Add(calories.Pop());
            }

            return list;
            
        }

        public static void Consumption(Queue meals, Stack<int> calories, Dictionary<string, int> ingredients)
        {
            var currentMeal = meals.Peek().ToString();//salad
            var currentCalories = calories.Peek();
            int result = 0;
            

            result = currentCalories - ingredients[currentMeal];//1500 -1600

            if (result > 0)
            {
                calories.Pop();
                calories.Push(result);
            }
            else
            {
                
                calories.Pop();
                if (calories.Count > 0)
                {
                    int nextCalories = calories.Peek() + result;
                    calories.Pop();
                    calories.Push(nextCalories);
                }
            }
            meals.Dequeue();
        }

        private static Stack<int> AddCalories(int[] dailyCalories)
        {
            Stack<int> calories = new Stack<int>();

            for (int i = 0; i < dailyCalories.Length; i++)
            {
                calories.Push(dailyCalories[i]);
            }

            return calories;
        }

        private static Queue AddMeals(string[] mealsInput)
        {
            Queue meals = new Queue();

            for (int i = 0; i < mealsInput.Length; i++)
            {
                meals.Enqueue(mealsInput[i]);
            }

            return meals;
        }
    }
}
