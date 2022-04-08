using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var persons = new Dictionary<string, int>();

            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                string name = input[0];

                int currentAge = int.Parse(input[1]);

                if (!persons.ContainsKey(name))
                {
                    persons.Add(name, currentAge);
                }
     
            }

            string condition = Console.ReadLine();

            int age = int.Parse(Console.ReadLine());

            string[] format = Console.ReadLine().Split(" ").ToArray();

            if (condition == "younger")
            {
                IsYounger(persons,format,age);
            }
            else
            {
                IsOlder(persons, format, age);
            }
        }

        private static void IsOlder(Dictionary<string, int> persons, string[] format, int age)
        {
            if (format.Length == 1)
            {
                if (format[0] == "name")
                {
                    foreach (var person in persons)
                    {
                        if (person.Value > age)
                        {
                            Console.WriteLine(person.Key);
                        }
                    }
                }
                else
                {
                    foreach (var person in persons)
                    {
                        if (person.Value >= age)
                        {
                            Console.WriteLine(person.Value);
                        }
                    }
                }
            }
            else
            {
                foreach (var person in persons)
                {
                    if (person.Value >= age)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
            }
        }

        private static void IsYounger(Dictionary<string, int> persons, string[] format,int age)
        {
            if (format.Length == 1)
            {
                if (format[0] == "name")
                {
                    foreach (var person in persons)
                    {
                        if (person.Value < age)
                        {
                            Console.WriteLine(person.Key);
                        }
                    }
                }
                else
                {
                    foreach (var person in persons)
                    {
                        if (person.Value <= age)
                        {
                            Console.WriteLine(person.Value);
                        }
                    }
                }
            }
            else
            {
                foreach (var person in persons)
                {
                    if (person.Value <= age)
                    {
                        Console.WriteLine($"{person.Key} - {person.Value}");
                    }
                }
            }
        }
    }
}
