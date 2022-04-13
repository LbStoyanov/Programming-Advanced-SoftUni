using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int linesOfEngines = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            for (int i = 0; i < linesOfEngines; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int power = int.Parse(input[1]);

            }

            

            int linesOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesOfCars; i++)
            {
                string[] input = Console.ReadLine().Split();

                
            }

        }
    }
}
