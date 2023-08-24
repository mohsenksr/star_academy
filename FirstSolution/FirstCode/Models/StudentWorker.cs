using FirstCode;
using FirstCode.Models;
using Microsoft.Extensions.Hosting;

namespace FirstCode;

public class StudentWorker
{
    private readonly IUtils _utils;

    public StudentWorker(IUtils utils)
    {
        _utils = utils ?? throw new ArgumentNullException(nameof(utils));
    }

    public String GetTopStudents(int number)
    {
        List<Student> students = _utils.GetModelListFromJsonFile<Student>("files/students.json");
        List<Grade> grades = _utils.GetModelListFromJsonFile<Grade>("files/grades.json");

        students = _utils.MapGradesToStudents(grades, students);
        
        List<Student> sortedStudents = students.OrderBy(o => - _utils.AverageGrade(o)).ToList();

        String topStudents = "";
        foreach (var student in sortedStudents.Take(number)) {
            topStudents += $"{student.FirstName} {student.LastName}: {_utils.AverageGrade(student)}\n";
        }

        return topStudents;
    }
}