using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {

        public Renovator(string name,string type,double rate,int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;
            this.Hired = false;
        }

        public string Name { get; set; }

        public string Type { get; set; }
        public double Rate { get; set; }

        public int Days { get; set; }

        public bool Hired { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"-Renovator: {this.Name}");
            result.AppendLine($"--Specialty: {this.Type}");
            result.AppendLine($"--Rate per day: {this.Rate} BGN");

            return result.ToString().TrimEnd();
        }
    }
}
