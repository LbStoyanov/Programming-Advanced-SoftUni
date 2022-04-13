using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        List<Car> cars;
        int capacity;
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }

        public void AddCar(Car car)
        {
            bool isExist = false;
            foreach (var currCar in Cars)
            {
                if (currCar.RegistrationNumber == car.RegistrationNumber)
                {
                    Console.WriteLine("Car with that registration number, already exists!");
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                if (Cars.Count > Capacity)
                {
                    Console.WriteLine("Parking is full!");
                }
                else
                {
                    Console.WriteLine($"Successfully added new car {car.Make} {car.RegistrationNumber}");
                }
            }
        }
    }
}
