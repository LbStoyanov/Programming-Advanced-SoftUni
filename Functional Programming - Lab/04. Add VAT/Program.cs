using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //decimal[] prices = Console.ReadLine().Split(", ").Select(decimal.Parse).ToArray();

            List<decimal> prices = Console.ReadLine().Split(", ").Select(decimal.Parse).ToList();

            Func<decimal, decimal> vatAdder = x => x + x * 0.20m;

            //prices = prices.Select(x => x + x * 0.20m).ToList();

            prices = prices.Select(vatAdder).ToList();

            prices.ForEach(x => Console.WriteLine($"{x:f2}"));

            //foreach (var item in prices)
            //{
            //    Console.WriteLine($"{item:f2}");
            //}
        }
    }
}
