using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wastedGramOfFoods = 0;

            int[] guestEatCapacityInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] platesInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> guestsEatingCapacity = new Queue<int>(guestEatCapacityInput);

            Stack<int> plates = new Stack<int>(platesInput);


            while (true)
            {
                int currentGuest = guestsEatingCapacity.Peek();
                int currentPlate = plates.Peek();

                if (currentGuest <= currentPlate)
                {
                    wastedGramOfFoods += currentPlate - currentGuest;
                    guestsEatingCapacity.Dequeue();
                    plates.Pop();
                    
                }
                else
                {
                    while (currentGuest > 0)
                    {
                        if (currentPlate > currentGuest)
                        {
                            wastedGramOfFoods += currentPlate - currentGuest;
                            currentGuest = 0;
                        }
                        else
                        {
                            currentGuest -= currentPlate;
                        }
                        plates.Pop();

                        if (plates.Count == 0)
                        {
                            break;
                        }

                        currentPlate = plates.Peek();
                    }
                    guestsEatingCapacity.Dequeue();
                }

                if (plates.Count == 0 || guestsEatingCapacity.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count > 0)
            {
                Console.Write($"Plates: ");
                while (plates.Count > 0)
                {
                    Console.Write(plates.Pop() + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.Write("Guests: ");
                while (guestsEatingCapacity.Count > 0)
                {
                    Console.Write(guestsEatingCapacity.Dequeue() + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Wasted grams of food: {wastedGramOfFoods}");
        }

    }
}
