using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }
        
        public List<Car> Participants { get; set; }
        public int Count 
            => Participants.Count;

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate) 
                && this.Capacity > 0
                && car.HorsePower <= this.MaxHorsePower)
            {
                Participants.Add(car);
                Capacity--;
            }
        }
        public bool Remove(string licensePLate)
        {
            if (Participants.Any(x => x.LicensePlate == licensePLate))
            {
                Car carToBeRemoved = Participants.FirstOrDefault(x => x.LicensePlate == licensePLate);
                Participants.Remove(carToBeRemoved);
                return true;
            }

            return false;
        }
        public  Car FindParticipant(string licensePlate)
        {
            if (Participants.Any(x => x.LicensePlate == licensePlate))
            {
                Car carToReturn = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);

                return carToReturn;
            }

            return null;
        }
        public Car GetMostPowerfulCar()
        {
            if (Participants.Count == 0)
            {
                return null;
            }

            var orderedParticipantsByHoresPower = Participants.OrderBy(x => x.HorsePower);

            Car mostPowerfulCar = orderedParticipantsByHoresPower.FirstOrDefault();

            return mostPowerfulCar;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var participant in Participants)
            {
                sb.AppendLine($"Make: {participant.Make}");
                sb.AppendLine($"Model: {participant.Model}");
                sb.AppendLine($"License Plate: {participant.LicensePlate}");
                sb.AppendLine($"Horse Power: {participant.HorsePower}");
                sb.AppendLine($"Weight: {participant.Weight}");
            }

            return sb.ToString();
        }
    }
}
