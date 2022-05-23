using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        public Car(string make, string model, string licensePlate, int horesePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HoresePower = horesePower;
            Weight = weight;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nLicense Plate: {this.LicensePlate}\nHorse Power: {this
                .HorsePower}\nWeight: {this.Weight}";
        }
    }
}
