using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            var studentsGradesDict = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] currentStudentInformation = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string currentStudentName = currentStudentInformation[0];

                decimal currentStudentGrade =  decimal.Parse(currentStudentInformation[1]);

                if (!studentsGradesDict.ContainsKey(currentStudentName))
                {
                    studentsGradesDict.Add(currentStudentName, new List<decimal>());
                }

                studentsGradesDict[currentStudentName].Add(currentStudentGrade);
            }

            foreach (var item in studentsGradesDict)
             {
                var name = item.Key;

                var grades = item.Value;

                var average = item.Value.Average();

                Console.Write($"{name} -> ");

                foreach (var grade in grades)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
