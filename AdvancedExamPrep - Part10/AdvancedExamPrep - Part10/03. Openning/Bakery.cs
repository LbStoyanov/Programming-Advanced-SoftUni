using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;
        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Data = new List<Employee>();
        }
        public int Count 
            => Data.Count;

        public List<Employee> Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (Capacity > 0)
            {
                Data.Add(employee);
                Capacity--;
            }
        }

        public bool Remove(string name)
        {
            if (Data.Any(e => e.Name == name))
            {
                Employee employeeForRemove = Data.FirstOrDefault(e => e.Name == name);
                Data.Remove(employeeForRemove);
                Capacity++;
                return true;
            }


            return false;
        }
        public Employee GetOldestEmployee()
        {
            var oldestEmployee = Data.OrderByDescending(x => x.Age).First();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            return Data.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}: ");

            foreach (var item in Data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
