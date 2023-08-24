using FirstCode.Models;
using Newtonsoft.Json;

namespace FirstCode;

public class Utils : IUtils
{
    private readonly ICalculator _calculator;

    public Utils(ICalculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    public List<T> GetModelListFromJsonFile<T>(string filePath){
        List<T> items = new();

        using (StreamReader r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<List<T>>(json);
        }
        return items;
    }

    public List<Student> MapGradesToStudents(List<Grade> grades, List<Student> students){
        foreach  (Grade grade in grades)
        {
            foreach (Student student in students)
            {
                if (student.StudentNumber == grade.StudentNumber)
                {
                    student.Grades.Add(grade);
                    break;
                }
            }
        }

        return students;
    }
    
    public double AverageGrade(Student student)
    {
        return _calculator.Average(student.Grades.Select(o => o.Score).ToList());
    }
}