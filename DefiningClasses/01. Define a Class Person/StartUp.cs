using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] intput = Console.ReadLine().Split();

                string name = intput[0];
                int age = int.Parse(intput[1]);
                Person person = new Person(name,age);

                if (age > 30)
                {
                    persons.Add(person);
                }
            }

            var orderedList = persons.OrderBy(x =>x.Name).ToList();

            foreach (var item in orderedList)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
            
        }
    }
}
