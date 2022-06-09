using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    internal class Bombs
    {
        static void Main(string[] args)
        {
            const int DaturaRequieredValue = 40;
            const int CheryRequieredValue = 60;
            const int SmokeRequieredValue = 120;

            Dictionary<string, int> fabricatedBombsInfo = new Dictionary<string, int> 
            {
                {"Datura Bombs",0 },
                {"Cherry Bombs",0 },
                {"Smoke Decoy Bombs",0 },
            };

            int[] effectInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> bombEffects = new Queue<int>(effectInput);

            int[] casingInput = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> bombCasings = new Stack<int>(casingInput);

            while (bombEffects.Count> 0 && bombCasings.Count > 0)
            {
                var currentBombEffect = bombEffects.Peek();
                var currentBombCasing = bombCasings.Peek();

                int obtainedBombValue = currentBombEffect + currentBombCasing;

                if (obtainedBombValue == DaturaRequieredValue)
                {
                    fabricatedBombsInfo["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (obtainedBombValue == CheryRequieredValue)
                {
                    fabricatedBombsInfo["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (obtainedBombValue == SmokeRequieredValue)
                {
                    fabricatedBombsInfo["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    int decreasedValueOfBombCasing = bombCasings.Pop() - 5;
                    bombCasings.Push(decreasedValueOfBombCasing);
                }

                if (fabricatedBombsInfo.All(x => x.Value >= 3))
                {
                    break;
                }
            }


            if (fabricatedBombsInfo.All(x => x.Value >= 3))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffects.ToList())}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings.ToList())}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in fabricatedBombsInfo.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
