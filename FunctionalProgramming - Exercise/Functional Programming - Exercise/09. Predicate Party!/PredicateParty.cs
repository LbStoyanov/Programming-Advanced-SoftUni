using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string commands = Console.ReadLine();

            while (commands != "Party!")
            {
                Predicate<string> predicate = GetPredicate(commands);

                if (commands.StartsWith("Double"))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        string person = people[i];
                        if (predicate(person))
                        {
                            people.Insert(i + 1, person);
                            i++;
                        }
                    }
                }
                else if (commands.StartsWith("Remove"))
                {
                    people.RemoveAll(predicate);
                }

                commands = Console.ReadLine();
            }


            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            Console.Write(string.Join(", ",people));
            Console.WriteLine(" are going to the party!");
        }

        private static Predicate<string> GetPredicate(string commands)
        {
            string command2 = commands.Split()[1];
            string arg = commands.Split()[2];

            Predicate<string> predicate = null;

            if (command2 == "StartsWith")
            {
                predicate = name => name.StartsWith(arg);
            }
            else if (command2 == "EndsWith")
            {
                predicate = name => name.EndsWith(arg);
            }
            else if (command2 == "Length")
            {
                predicate = name => name.Length == int.Parse(arg);
            }

            return predicate;
        }
    }
}
