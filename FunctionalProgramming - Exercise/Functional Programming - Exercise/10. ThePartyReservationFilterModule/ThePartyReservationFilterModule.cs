using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    internal class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();
            List<string> filters = new List<string>();

            string command;

            while ((command = Console.ReadLine()) != "Print")
            {

                string[] splittedCommand = command.Split(";",StringSplitOptions.RemoveEmptyEntries);
                

                if (splittedCommand[0] == "Add filter")
                {
                    filters.Add(splittedCommand[1] + " " + splittedCommand[2]);
                }
                else if (splittedCommand[0] == "Remove filter")
                {
                    filters.Remove(splittedCommand[1] + " " + splittedCommand[2]);
                }
            }

            foreach (var filter in filters)
            {
                var commands = filter.Split(" ");

                if (commands[0] == "Starts")
                {
                    people = people.Where(p => !p.StartsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Ends")
                {
                    people = people.Where(p => !p.EndsWith(commands[2])).ToList();
                }
                else if (commands[0] == "Length")
                {
                    people = people.Where(p => p.Length != int.Parse(commands[1])).ToList();
                }
                else if (commands[0] == "Contains")
                {
                    people = people.Where(p => !p.Contains(commands[1])).ToList();
                }
            }

            if (people.Any())
            {
                Console.WriteLine(string.Join(" ", people));
            }
        }
    }
}
