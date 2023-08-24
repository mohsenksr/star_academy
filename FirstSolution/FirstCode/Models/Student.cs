namespace FirstCode.Models;


public class Student
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? StudentNumber { get; set; }
    public List<Grade> Grades { get; set; } = new List<Grade>();
    
}