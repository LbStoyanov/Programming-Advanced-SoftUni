using System;
using System.Collections.Generic;
using System.Linq;

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
                string[] carInformation = Console.ReadLine().Split();

                string model = carInformation[0];
                int engineSpeed = int.Parse(carInformation[1]);
                int enginePower = int.Parse(carInformation[2]);
                Engine engine = new Engine(engineSpeed,enginePower);

                int cargoWeight = int.Parse(carInformation[3]);
                string cargoType = carInformation[4];
                Cargo cargo = new Cargo(cargoType,cargoWeight);

                double tire1Pressure = double.Parse(carInformation[5]);
                int tire1Age = int.Parse(carInformation[6]);
                Tire firstTire = new Tire(tire1Age, tire1Pressure);

                double tire2Pressure = double.Parse(carInformation[6]);
                int tire2Age = int.Parse(carInformation[8]);
                Tire secondTire = new Tire(tire2Age, tire2Pressure);

                double tire3Pressure = double.Parse(carInformation[9]);
                int tire3Age = int.Parse(carInformation[10]);
                Tire thirdTire = new Tire(tire3Age, tire3Pressure);

                double tire4Pressure = double.Parse(carInformation[11]);
                int tire4Age = int.Parse(carInformation[12]);
                Tire fourtTire = new Tire(tire4Age, tire4Pressure);

                Tire[] tires = new Tire[]
                {
                    firstTire, secondTire, thirdTire, fourtTire,
                };

                Car car = new Car(model,engine,cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == command && car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == command && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}
