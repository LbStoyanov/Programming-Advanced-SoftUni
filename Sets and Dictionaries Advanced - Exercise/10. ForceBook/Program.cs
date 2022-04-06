using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forcesDict = new Dictionary<string, List<string>>();

            string input;
            char possibleCharDelimiter = '|';

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {

                string[] splittedInput;

                if (input.Contains(possibleCharDelimiter))
                {
                    splittedInput = input.Split(" | ",StringSplitOptions.RemoveEmptyEntries);

                    string forceSide = splittedInput[0];

                    string forceUser = splittedInput[1];

                    if (!forcesDict.ContainsKey(forceSide))
                    {
                        forcesDict.Add(forceSide, new List<string> { { forceUser } });
                    }
                    else
                    {
                        if (!forcesDict[forceSide].Contains(forceUser))
                        {
                            forcesDict[forceSide].Add(forceUser);
                        }
                    }
                }
                else
                {
                    splittedInput = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                    string forceUser = splittedInput[0];

                    string forceSide = splittedInput[1];

                    foreach (var side in forcesDict)//Light
                    {
                        var currentListOfUsers = side.Value;//List of user

                        foreach (var user in currentListOfUsers)// minavash prez vsichki uzseri
                        {
                            if (user == forceUser)
                            {
                                forcesDict[side.Key].Remove(forceUser);
                                break;
                            }
                        }
                    }

                    if (!forcesDict.ContainsKey(forceSide))
                    {
                        forcesDict.Add(forceSide, new List<string> ());
                    }
                    forcesDict[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");

                }
            }

            foreach (var side in forcesDict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                var currentForceSide = side.Key;
                var currentForceSideMembers = side.Value.Count;

                if (currentForceSideMembers == 0)
                {
                    continue;
                }

                Console.WriteLine($"Side: {currentForceSide}, Members: {currentForceSideMembers}");

                foreach (var member in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {member}");
                }

            }
        }
    }
}
