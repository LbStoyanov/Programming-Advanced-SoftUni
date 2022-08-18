using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        public int Count
            => Renovators.Count;

        public List<Renovator> Renovators { get; set; }

        public string Name{ get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (Renovators.Count > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate < 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator);

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovatorForRemove = Renovators.FirstOrDefault(x => x.Name == name);
                Renovators.Remove(renovatorForRemove);
                return true;
            }
          
            return false;
        }

        public 	int RemoveRenovatorBySpecialty(string type)
        {
            if (Renovators.Any(x => x.Type == type))
            {
                int removedRenovators = Renovators.Where(x => x.Type == type).Count();

                Renovators.RemoveAll(x => x.Type == type);
                
                return removedRenovators;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = Renovators.FirstOrDefault(x => x.Name == name);
                renovator.Hired = true;
                return renovator;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.FindAll(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            var notHiredRenovators = Renovators.Where((x) => !x.Hired).ToList();

            result.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in notHiredRenovators)
            {
                result.AppendLine(renovator.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
