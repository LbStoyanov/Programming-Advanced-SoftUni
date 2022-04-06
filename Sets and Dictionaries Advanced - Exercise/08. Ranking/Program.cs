using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUni
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var contestDictionary = new Dictionary<string, string>();

            while (command != "end of contests")
            {
                AddContest(command, contestDictionary);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            var userDictionary = new Dictionary<string, Dictionary<string, int>>();

            while (command != "end of submissions")
            {
                AddStudentInfoForContest(command, contestDictionary, userDictionary);

                command = Console.ReadLine();
            }

            PrintResult(userDictionary);
        }

        public static void AddContest(string command, Dictionary<string, string> contestDictionary)
        {
            var splittedComamndArrya = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
            var contest = splittedComamndArrya[0];
            var password = splittedComamndArrya[1];

            if (!contestDictionary.ContainsKey(contest))
            {
                contestDictionary.Add(contest, password);
            }
            else
            {
                contestDictionary[contest] = password;
            }
        }

        public static void AddStudentInfoForContest(string command, Dictionary<string, string> contestDictionary, Dictionary<string, Dictionary<string, int>> userDictionary)
        {
            var splittedComamndArrya = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
            var contest = splittedComamndArrya[0];
            var password = splittedComamndArrya[1];
            var username = splittedComamndArrya[2];
            var points = int.Parse(splittedComamndArrya[3]);

            if (contestDictionary.ContainsKey(contest) && contestDictionary[contest] == password)
            {
                if (!userDictionary.ContainsKey(username))
                {
                    var userContestDictionary = new Dictionary<string, int> { { contest, points } };

                    userDictionary.Add(username, userContestDictionary);
                }
                else
                {
                    if (!userDictionary[username].ContainsKey(contest))
                    {
                        userDictionary[username].Add(contest, points);
                    }
                    else
                    {
                        var oldPointForContest = userDictionary[username][contest];

                        if (points > oldPointForContest)
                        {
                            userDictionary[username][contest] = points;
                        }
                    }
                }
            }
        }

        public static void PrintResult(Dictionary<string, Dictionary<string, int>> userDictionary)
        {
            var best = userDictionary.OrderByDescending(x => x.Value.Sum(y => y.Value)).First();

            System.Console.WriteLine($"Best candidate is {best.Key} with total {best.Value.Sum(y => y.Value)} points.");
            System.Console.WriteLine("Ranking: ");

            foreach (var user in userDictionary.OrderBy(x => x.Key))
            {
                System.Console.WriteLine(user.Key);
                foreach (var userContest in user.Value.OrderByDescending(x => x.Value))
                {
                    System.Console.WriteLine($"#  {userContest.Key} -> {userContest.Value}");
                }
            }
        }
    }
}