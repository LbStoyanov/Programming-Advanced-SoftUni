using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    internal class PredicateParty
    {
        static void Main(string[] args)
        {
            var personsList = Console.ReadLine().Split().ToList();
            var personsGoingToTheParty = new List<string>();

            Func<string, string> doubleThePerson = name => name + ", " + name;

            string commands;

            while ((commands = Console.ReadLine()) != "Party!")
            {
                string[] splittedCommand = commands.Split();
                string mainCommand = splittedCommand[0];
                string lettersForSearch = splittedCommand[2];

                if (mainCommand == "Remove")
                {
                    if (splittedCommand[1] == "StartsWith")
                    {
                        personsList.RemoveAll(x => x.StartsWith(lettersForSearch));
                    }
                    else if (splittedCommand[1] == "EndsWith")
                    {
                        personsList.RemoveAll(x => x.EndsWith(lettersForSearch));
                    }
                }
                if (mainCommand == "Double")
                {
                    if (splittedCommand[1] == "StartsWith")
                    {
                        string[] personsToBeDoubled = personsList.FindAll(x => x.StartsWith(lettersForSearch)).ToArray();

                        for (int i = 0; i < personsToBeDoubled.Length; i++)
                        {
                            personsList.Add(doubleThePerson(personsToBeDoubled[i]));
                        }
                    }
                    else if (splittedCommand[1] == "EndsWith")
                    {
                        string[] personsToBeDoubled = personsList.FindAll(x => x.EndsWith(lettersForSearch)).ToArray();

                        for (int i = 0; i < personsToBeDoubled.Length; i++)
                        {
                            personsList.Add(doubleThePerson(personsToBeDoubled[i]));
                        }
                    }
                    else
                    {
                        int lenghtToBeCompared = int.Parse(splittedCommand[2]);

                        string[] personsToBeDoubled = personsList.FindAll(x => x.Length == lenghtToBeCompared).ToArray();

                        for (int i = 0; i < personsToBeDoubled.Length; i++)
                        {
                            personsList.Add(doubleThePerson(personsToBeDoubled[i]));
                        }
                    }
                }

            }


            if (personsList.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            Console.Write(string.Join(", ",personsList));
            Console.WriteLine(" are going to the party!");
        }
    }
}
