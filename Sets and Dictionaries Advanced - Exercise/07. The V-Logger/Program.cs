using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> vLoggers = new Dictionary<string, List<string>>();

            Dictionary<string, int[]> numberOfFollowersDicr = new Dictionary<string, int[]>();

            string vloggerInput = Console.ReadLine();

            while (vloggerInput != "Statistics")
            {
                string[] splittedInput = vloggerInput.Split(' ');
                string userName = splittedInput[0];
                string command = splittedInput[1];

                if (command.ToLower() == "joined")
                {
                    if (!vLoggers.ContainsKey(userName))
                    {
                        vLoggers[userName] = new List<string>();
                        numberOfFollowersDicr[userName] = new int[2];
                    }
                }
                else if (command.ToLower() == "followed")
                {
                    string userToFollow = splittedInput[2];
                    if (vLoggers.ContainsKey(userName) && vLoggers.ContainsKey(userToFollow))
                    {
                        if (!vLoggers[userToFollow].Contains(userName) && userName != userToFollow)
                        {
                            vLoggers[userToFollow].Add(userName);
                            numberOfFollowersDicr[userToFollow][0]++;
                            numberOfFollowersDicr[userName][1]++;
                        }
                    }
                }

                vloggerInput = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vLoggers.Count} vloggers in its logs.");

            Dictionary<string, int[]> orderedUserAndFollowers = numberOfFollowersDicr.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Value[1]).ToDictionary(x => x.Key, x => x.Value);

            int raiting = 1;
            string userToBeRemoved = "";

            foreach (var vlogger in orderedUserAndFollowers)
            {
                userToBeRemoved = vlogger.Key;
                Console.WriteLine($"{raiting}. {userToBeRemoved} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
                raiting++;

                if (vLoggers[vlogger.Key].Count > 0)
                {
                    foreach (var follower in vLoggers[vlogger.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                break;
            }

            orderedUserAndFollowers.Remove(userToBeRemoved);

            foreach (var kvp in orderedUserAndFollowers)
            {
                Console.WriteLine($"{raiting}. {kvp.Key} : {kvp.Value[0]} followers, {kvp.Value[1]} following");
                raiting++;
            }


        }
    }
}
