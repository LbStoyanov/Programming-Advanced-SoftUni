using System;

namespace SoftUniParking
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car("Skoda", "Fabia", 65, "CC1856BG"); 

            Console.WriteLine(car.ToString());

            var parking = new Parking(5);

            Console.WriteLine(parking.AddCar(car));
        }
    }
}
