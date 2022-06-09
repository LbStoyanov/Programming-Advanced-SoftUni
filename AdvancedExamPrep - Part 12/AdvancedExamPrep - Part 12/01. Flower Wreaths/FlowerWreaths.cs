using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class FlowerWreaths
    {
        static void Main(string[] args)
        {
            const int requiredWreaths = 5;
            const int requiredValueForOneWreath = 15;


            int[] liliesInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(liliesInput);

            int[] rosesInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> roses = new Queue<int>(rosesInput);

            int craftedWreaths = 0;
            int storedLeftFlowers = 0;

            while (true)                                 //13, 11, 12, 14
            {
                var currentLilie = lilies.Peek();
                var currentRose = roses.Peek(); 

                int obtainedValue = currentLilie + currentRose;

                if (obtainedValue == requiredValueForOneWreath)
                {
                    craftedWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if(obtainedValue > requiredValueForOneWreath)
                {
                    int decreasedLilie = currentLilie - 2;
                    lilies.Pop();
                    lilies.Push(decreasedLilie);
                }
                else if (obtainedValue < requiredValueForOneWreath)
                {
                    storedLeftFlowers += obtainedValue;
                    lilies.Pop();
                    roses.Dequeue();
                }

                if (lilies.Count == 0 || roses.Count == 0)
                {
                    break;
                }

            }

            if (storedLeftFlowers >= requiredValueForOneWreath)
            {
                while (storedLeftFlowers >= requiredValueForOneWreath)
                {
                    craftedWreaths++;
                    storedLeftFlowers -= requiredValueForOneWreath;
                }
            }

            if (craftedWreaths >= requiredWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {craftedWreaths} wreaths!");
            }
            else
            {
                int wreathsNeeded = requiredWreaths - craftedWreaths;
                Console.WriteLine($"You didn't make it, you need {wreathsNeeded} wreaths more!");
            }
        }
    }
}
