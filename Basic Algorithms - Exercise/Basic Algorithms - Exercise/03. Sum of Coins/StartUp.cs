using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] coinsInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Array.Sort(coinsInput);
            Array.Reverse(coinsInput);

            SortedDictionary<int, int> coinsDict = new SortedDictionary<int, int>();

            int index = 0;

            int searchedNumber = int.Parse(Console.ReadLine());

            while (true)
            {
                int result = searchedNumber - coinsInput[index];
               
                
                if (result < 0 && searchedNumber > 0)
                {
                    index++;
                    continue;
                }

                if (!coinsDict.ContainsKey(coinsInput[index]))
                {
                    coinsDict.Add(coinsInput[index], 0);
                }

                coinsDict[coinsInput[index]]++;
                searchedNumber -= coinsInput[index];
                if (searchedNumber == 0)
                {
                    break;
                }
            }

            int coinsNeeded = coinsDict.Values.Sum();

            Console.WriteLine($"Number of coins to take: {coinsNeeded}");

            foreach (var coin in coinsDict.OrderByDescending(x =>x.Key))
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
    }
}
