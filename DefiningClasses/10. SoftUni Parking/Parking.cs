using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.Capacity = capacity;
            this.Cars = new List<Car>();
        }

        public List<Car> Cars { get; set; }
        public int Capacity { get;  set; }
        public int Count 
            => Cars.Count;

        public string AddCar(Car car)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.Cars.Count() >= this.Capacity)
            {
                return $"Parking is full!";
            }

            this.Cars.Add(car);
            Capacity--;

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                Car carForRemove = this.Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
                this.Cars.Remove(carForRemove);
                Capacity++;
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return Cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNum in RegistrationNumbers)
            {
                if (this.Cars.Any(x => x.RegistrationNumber == regNum))
                {
                    this.Cars.Remove(Cars.First(x => x.RegistrationNumber == regNum));
                }
            }
        }


    }
}
