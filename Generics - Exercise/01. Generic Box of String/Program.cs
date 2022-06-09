using System;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();

            int integerValue = int.Parse(Console.ReadLine());

            for (int i = 0; i < integerValue; i++)
            {
                string input = Console.ReadLine();

                box.Items.Add(input);
            }

            Console.WriteLine(box);
        }
    }
}
