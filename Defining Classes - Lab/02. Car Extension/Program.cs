using _02._Car_Extension;
using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "vw";
            car.Model = "MK3";
            car.Year = 1992;
            car.FuelQuantity = 2000;
            car.FuelConsumption = 200;
            car.Drive(2);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
