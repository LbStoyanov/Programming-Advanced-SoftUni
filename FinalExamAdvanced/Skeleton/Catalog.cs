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
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }
        public int Count
            => this.Renovators.Count;

        public List<Renovator> Renovators { get;  set; }

        public string Name{ get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) && string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.NeededRenovators == 0)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            
           
            this.NeededRenovators--;

            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (this.Renovators.Any(x => x.Name == name))
            {
                Renovator renovatorForRemove = this.Renovators.FirstOrDefault(x => x.Name == name);
                this.Renovators.Remove(renovatorForRemove);
                this.NeededRenovators++;
                return true;
            }
          
            return false;
        }

        public 	int RemoveRenovatorBySpecialty(string type)
        {
            if (this.Renovators.Any(x => x.Type == type))
            {
                int removedRenovators = this.Renovators.FindAll(x => x.Type == type).Count();

                this.Renovators.RemoveAll(x => x.Type == type);
                this.NeededRenovators += removedRenovators;
                
                return removedRenovators;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            if (this.Renovators.Any(x => x.Name == name))
            {
                Renovator renovator = this.Renovators.FirstOrDefault(x => x.Name == name);
                renovator!.Hired = true;
                return renovator;
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return this.Renovators.FindAll(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            var notHiredRenovators = this.Renovators.FindAll((x) => x.Hired != true).ToList();

            result.AppendLine($"Renovators available for Project {this.Project}:");

            foreach (var renovator in notHiredRenovators)
            {
                result.AppendLine(renovator.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
