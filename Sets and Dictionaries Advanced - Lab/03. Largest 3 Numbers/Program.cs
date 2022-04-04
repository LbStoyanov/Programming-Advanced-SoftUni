using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] sortedIntegers = integers.OrderByDescending(n => n).Take(3).ToArray();

            Console.WriteLine(String.Join(" ",sortedIntegers));
        }
    }
}
