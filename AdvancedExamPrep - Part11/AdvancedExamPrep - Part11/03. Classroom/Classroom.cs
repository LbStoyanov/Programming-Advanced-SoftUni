using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public List<Student> Students { get; set; }

        public int Capacity { get; set; }
        public int Count
            => Students.Count;

        public string RegisterStudent(Student student)
        {
            if (Capacity > 0)
            {
                Students.Add(student);
                Capacity--;
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {

            if (Students.Any(s => s.FirstName == firstName && s.LastName ==lastName))
            {
                Student studentForRemove = Students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
                Students.Remove(studentForRemove);

                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            if (Students.Any(s => s.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in Students.FindAll(x => x.Subject == subject))
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return Students.Count();
        }

        public Student GetStudent(string firstName, string lastName)
        {
            if (Students.Any(s =>s.FirstName == firstName && s.LastName == lastName))
            {
                return Students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
            }

            return null;
        }


    }
}
