using System;
using System.Text.Json;
using Newtonsoft.Json;

namespace HelloWorld
{
    public class Grade
    {
        public int? StudentNumber { get; set; }
        public string? Lesson { get; set; }
        public float? Score { get; set; }
    }

    public class Student
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? StudentNumber { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();

        public float AverageGrade()
        {
            if (Grades.Count == 0)
                return 0;
            float sumScores = 0;
            for (int i = 0; i < Grades.Count; i++)
            {
                sumScores += Grades[i].Score ?? 0;
            }
            return sumScores / Grades.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students;
            List<Grade> grades;

            using (StreamReader r = new StreamReader("files/students.json"))
            {
                string json = r.ReadToEnd();
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }

            using (StreamReader r = new StreamReader("files/grades.json"))
            {
                string json = r.ReadToEnd();
                grades = JsonConvert.DeserializeObject<List<Grade>>(json);
            }

            for (int i = 0; i < grades.Count; i++)
            {
                for (int j = 0; j < students.Count; j++)
                {
                    if (students[j].StudentNumber == grades[i].StudentNumber)
                    {
                        students[j].Grades.Add(grades[i]);
                        break;
                    }
                }
            }

            List<Student> sortedStudents = students.OrderBy(o => - o.AverageGrade()).ToList();

            for (int i = 0; i < 3; i++) {
                Console.WriteLine($"{sortedStudents[i].FirstName} {sortedStudents[i].LastName}: {sortedStudents[i].AverageGrade()}");
             }

        }
    }
}
