using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitted = command.Split(", ");

                string direction = splitted[0];
                string carNumber = splitted[1];



                if (direction == "IN")
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                Environment.Exit(0);
            }

            foreach (var item in cars)
            {
                Console.WriteLine(item);
            }
        }
    }
}
