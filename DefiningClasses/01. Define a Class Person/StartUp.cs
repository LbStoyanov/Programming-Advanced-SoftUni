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

            Family family = new Family();

            

            for (int i = 0; i < n; i++)
            {
                string[] intput = Console.ReadLine().Split();

                string name = intput[0];
                int age = int.Parse(intput[1]);
                Person person = new Person(name,age);
                family.AddMember(person);
            }



            var sortedPeople = family.People.FindAll(x => x.Age > 30).OrderBy(x => x.Name);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

          

           
            
        }
    }
}
