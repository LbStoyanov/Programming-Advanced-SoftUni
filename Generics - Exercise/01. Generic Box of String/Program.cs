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
                string stringValue = Console.ReadLine();

                box.Items.Add(stringValue);
            }

            Console.WriteLine(box);
        }
    }
}
