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
            const int  SaladValue = 350;
            const int  SoupValue = 490;
            const int  PastaValue = 680;
            const int  SteakValue = 350;


            Queue meals = new Queue();

            Stack<int> calories = new Stack<int>();

            string[] mealsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            meals = AddMeals(mealsInput);

            int[] dailyCalories = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            calories = AddCalories(dailyCalories);


            while (meals.Count != 0 || calories.Count != 0)
            {
                var currentMeal = meals.Peek();//salad
                var currentCalories = calories.Peek();//1500

                DailyConsumption(calories, meals);
            }
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
