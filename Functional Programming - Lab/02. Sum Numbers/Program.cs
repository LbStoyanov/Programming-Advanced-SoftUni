using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string,int> parser = x => int.Parse(x);

            int[] numbers = Console.ReadLine().Split(", ").Select(parser).ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
            
        }
    }
}
