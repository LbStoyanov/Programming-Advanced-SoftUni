using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string[] words = text.Split(' ',StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isStartWithCapital = x => char.IsUpper(x[0]);

            Console.WriteLine(string.Join("\n", words.Where(x => isStartWithCapital(x))));
        }
    }
}
