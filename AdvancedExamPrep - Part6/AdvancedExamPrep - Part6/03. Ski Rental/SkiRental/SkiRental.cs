using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Ski>();
        }

        public int Count
            => this.Data.Count;

        public List<Ski> Data { get; set; }
      
        

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (this.Capacity > 0)
            {
                Capacity--;
                this.Data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski skiToRemove = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (skiToRemove != null)
            {
                this.Data.Remove(skiToRemove);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (this.Data.Count == 0)
            {
                return null;
            }

            int newestYear = 0;

            foreach (var ski in Data)
            {
                if (ski.Year > newestYear)
                {
                    newestYear = ski.Year;
                }
            }
            Ski newestSki = Data.FirstOrDefault(x => x.Year == newestYear);

            return newestSki;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            Ski skiToReturn = Data.FirstOrDefault(x=>x.Manufacturer == manufacturer && x.Model == model);

            if (skiToReturn == null)
            {
                return null;
            }

            return skiToReturn;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}: ");

            foreach (var ski in Data)
            {
                sb.AppendLine($"{ski.Manufacturer} - {ski.Model} – {ski.Year}");
            }

            return sb.ToString();
        }
    }
}
