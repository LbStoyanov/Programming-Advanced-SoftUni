using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name,int capacity,double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int  Capacity { get; set; }

        public double LandingStrip  { get; set; }

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if ((drone.Name == null || drone.Name == string.Empty) || 
                (drone.Brand == null || drone.Brand == string.Empty) ||
                (drone.Range < 5 || drone.Range > 15))
            {
                return "Invalid drone.";
            }

            if (Capacity == 0)
            {
                return "Airfield is full.";
            }

            Capacity--;

            Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(x=>x.Name == name))
            {
                Drone droneForRemove = Drones.FirstOrDefault(x => x.Name == name);

                Drones.Remove(droneForRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int removedDrones = 0;

            if (Drones.Exists(x=>x.Brand == brand))
            {
                removedDrones = Drones.Where(x => x.Brand == brand).Count();
                Drones.RemoveAll(x=>x.Brand == brand);
                return removedDrones;
            }

            return 0;
        }
        public Drone FlyDrone(string name)
        {
            if (Drones.Exists(x=>x.Name == name))
            {
                Drones.FirstOrDefault(x=>x.Name == name).Available = false;
                return Drones.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> dronesWhichGoesFly = new List<Drone>();

            foreach (var item in Drones)
            {
                if (item.Range >= range)
                {
                    dronesWhichGoesFly.Add(item);
                    item.Available = false;
                }
                
            }
            return dronesWhichGoesFly;
            //return Drones.Where(x => x.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var item in Drones.Where(x=>x.Available == true))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
