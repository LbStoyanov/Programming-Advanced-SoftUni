using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string tiresInput;
            List<List<Tire>> tires = new List<List<Tire>>();

            while ((tiresInput = Console.ReadLine()) != "No more tires")
            {
                string[] splittetTires = tiresInput.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                var currentTireList = new List<Tire>();

                for (int i = 0; i < splittetTires.Length; i+=2)
                {
                    int year = int.Parse(splittetTires[i]);
                    double pressure = double.Parse(splittetTires[i + 1]);
                    Tire tire = new Tire(year, pressure);
                    currentTireList.Add(tire);
                }

                tires.Add(currentTireList);

            }

            string engineInput;
            List<Engine> engines = new List<Engine>();
            while ((engineInput = Console.ReadLine()) != "Engines done")
            {
                string[] splitterEngines = engineInput.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(splitterEngines[0]);
                decimal cubicCapacity = decimal.Parse(splitterEngines[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));


            }

            string finalCommand;

            List<Car> cars = new List<Car>();

            while ((finalCommand = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = finalCommand.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[5]);
                Engine engine = engines[engineIndex];
                List <Tire> currentTiresList = tires[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, currentTiresList);

                cars.Add(car);
            }

            cars =
                cars
                .FindAll(x => x.Year >= 2017 && x.Engine.HorsePower > 330 && x.Tires.Sum(x => x.Pressure) >= 9 && x.Tires.Sum(x => x.Pressure) <= 10);
            

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
