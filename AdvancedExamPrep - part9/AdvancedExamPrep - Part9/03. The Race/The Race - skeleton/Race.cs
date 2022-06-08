using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Racer>();
        }

        public List<Racer> Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count 
            => data.Count;

        public void Add(Racer Racer)
        {
            if (this.Capacity > 0)
            {
                this.Data.Add(Racer);
                Capacity--;
            }
        }
        public bool Remove(string name)
        {
            if (this.Data.Any(r => r.Name == name))
            {
                Racer racerToRemove = this.Data.FirstOrDefault(r => r.Name == name);
                this.Data.Remove(racerToRemove);
                Capacity++;
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer oldestRacer = this.Data.OrderByDescending(r => r.Age).First();
            return oldestRacer;
        }

        public Racer GetRacer(string name)
        {
            return this.Data.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            Racer racerWithFastesCar = this.Data.OrderByDescending(r => r.Car.Speed).First();
            return racerWithFastesCar;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}");

            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
