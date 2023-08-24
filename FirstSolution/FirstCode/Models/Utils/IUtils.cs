using FirstCode.Models;

namespace FirstCode;

public interface IUtils
{
    public List<T> GetModelListFromJsonFile<T>(string filePath);
    public List<Student> MapGradesToStudents(List<Grade> grades, List<Student> students);
    public double AverageGrade(Student student);
}