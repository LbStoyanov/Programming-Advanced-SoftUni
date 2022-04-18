using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());

                box.Items.Add(input);
            }
            
            double elementToCompare = double.Parse(Console.ReadLine());

            int result = box.CompareElements(elementToCompare);
            Console.WriteLine(result);


        }
    }
}
