﻿using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInformation = Console.ReadLine().Split(' ');

                string model = carInformation[0];
                double fuelAmount = double.Parse(carInformation[1]);
                double fuelConsumption = double.Parse(carInformation[2]);

                Car car = new Car(model,fuelAmount,fuelConsumption);
                cars.Add(car);

            }

            string commands;

            while ((commands = Console.ReadLine()) != "End")
            {
                string[] currentCarTripInfo = commands.Split(' ');

                string carModel = currentCarTripInfo[0];
                int amountOfKm = int.Parse(currentCarTripInfo[1]);


            }
        }
    }
}
