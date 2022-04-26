using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string personInformation;

            while ((personInformation = Console.ReadLine()) != "END")
            {
                string[] splittedInformation = personInformation.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = splittedInformation[0];
                int age = int.Parse(splittedInformation[1]);
                string town = splittedInformation[2];
                Person person = new Person(name, age, town);
                persons.Add(person);

            }

            int n = int.Parse(Console.ReadLine());

            Person personToCompare = persons[n - 1];

            int equals = 0;
            int diff = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    equals++;
                }
                else
                {
                    diff++;
                }
            }

            if (equals == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {diff} {persons.Count}");
            }
        }
    }
}
