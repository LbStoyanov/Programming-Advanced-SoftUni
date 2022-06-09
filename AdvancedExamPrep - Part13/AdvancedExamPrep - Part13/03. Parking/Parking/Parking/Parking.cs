using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capasity)
        {
            Type = type;
            Capacity = capasity;
            Cars = new List<Car>(); 
        }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
            => Cars.Count;

        public void Add(Car car)
        {
            if (this.Capacity > 0)
            {
                this.Cars.Add(car);
                this.Capacity--;
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            if (Cars.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                Car carForRemove = Cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
                Cars.Remove(carForRemove);
                return true;
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (Cars.Count > 0)
            {
                return Cars.OrderByDescending(c => c.Year).First();
            }
            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (Cars.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return Cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            }

            return null;
        }

        public string GetStatistics()
        {
            if (Cars.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"The cars are parked in {this.Type}:");

                foreach (var car in Cars)
                {
                    sb.AppendLine(car.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return "";
        }

    }
}
