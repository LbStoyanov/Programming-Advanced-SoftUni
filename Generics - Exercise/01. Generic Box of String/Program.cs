using System;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            int integerValue = int.Parse(Console.ReadLine());

            for (int i = 0; i < integerValue; i++)
            {
                int intValue = int.Parse(Console.ReadLine());

                box.Items.Add(intValue);
            }

            Console.WriteLine(box);
        }
    }
}
