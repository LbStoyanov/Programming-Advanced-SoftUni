using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    public class Lootbox
    {
        static void Main(string[] args)
        {
            int[] firstBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondBoxInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Predicate<int> predicate = num => num % 2 == 0;

            Queue<int> firstBoxOfLoot = new Queue<int>(firstBoxInput);
            Stack<int> secondBoxOfLoot = new Stack<int>(secondBoxInput);

            int claimedItems = 0;

            while (firstBoxOfLoot.Count != 0 && secondBoxOfLoot.Count != 0)
            {
                var firstLoot = firstBoxOfLoot.Peek();
                var secondLoot = secondBoxOfLoot.Peek();

                int obtainedValue = firstLoot + secondLoot;

                bool isEven = predicate(obtainedValue);

                if (isEven)
                {
                    claimedItems += obtainedValue;
                    firstBoxOfLoot.Dequeue();
                    secondBoxOfLoot.Pop();
                }
                else
                {
                    firstBoxOfLoot.Enqueue(secondBoxOfLoot.Pop());
                }

            }

            if (firstBoxOfLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }


        }
    }
}
