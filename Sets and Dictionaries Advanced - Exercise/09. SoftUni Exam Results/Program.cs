using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participantsInTheContest = new Dictionary<string, int>();

            Dictionary<string, int> languagesAndNumerOfSubmitions = new Dictionary<string, int>();

            string command;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] input = command.Split('-');
                string userName = input[0];

                if (input[1] == "banned")
                {
                    participantsInTheContest.Remove(userName);
                    continue;
                }
                
                string language = input[1];
                int points = int.Parse(input[2]);

                if (!participantsInTheContest.ContainsKey(userName))
                {
                    participantsInTheContest.Add(userName, points);
                }
                else
                {
                    if (participantsInTheContest[userName] < points)
                    {
                        participantsInTheContest[userName] = points;
                    }
                }

                if (!languagesAndNumerOfSubmitions.ContainsKey(language))
                {
                    languagesAndNumerOfSubmitions.Add(language, 0);
                }

                languagesAndNumerOfSubmitions[language]++;

            }

            var orderedUsersDict = participantsInTheContest.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Results:");

            foreach (var participant in orderedUsersDict)
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            var orderedLanguageDict = languagesAndNumerOfSubmitions.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine("Submissions:");

            foreach (var language in orderedLanguageDict)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
