using FirstCode;
using FirstCode.Models;
using FluentAssertions;
using NSubstitute;

namespace FirstTest;

public class StudentWorkerTest
{
    private readonly IUtils Utils;
    private readonly StudentWorker _studentWorker;

    public StudentWorkerTest()
    {
        Utils = Substitute.For<IUtils>();
        _studentWorker = new StudentWorker(Utils);
    }

    [Fact(DisplayName = "Test get top students")]
    public void TestTopStudent()
    {
        // Arrange
        List<Student> students = new List<Student>()
        {
            new Student { StudentNumber = 1, FirstName = "Ali", LastName = "Alavi" },
            new Student { StudentNumber = 2, FirstName = "Mahdi", LastName = "Mahdavi" },
            new Student { StudentNumber = 3, FirstName = "Mostafa", LastName = "Mostafavi" },
            new Student { StudentNumber = 4, FirstName = "Yahya", LastName = "Yahyavi" },
        };

        List<Grade> grades = new List<Grade>() {};

        Utils.GetModelListFromJsonFile<Student>(default).ReturnsForAnyArgs(students);
        Utils.GetModelListFromJsonFile<Grade>(default).ReturnsForAnyArgs(grades);
        Utils.MapGradesToStudents(default, default).ReturnsForAnyArgs(students);
        Utils.AverageGrade(students[0]).Returns(15.43);
        Utils.AverageGrade(students[1]).Returns(16.43);
        Utils.AverageGrade(students[2]).Returns(17.43);
        Utils.AverageGrade(students[3]).Returns(18.43);

        // Act
        String topThreeStudents = _studentWorker.GetTopStudents(3);
        
        // Assert
        String topThreeStudentsExpectedValue = $"{students[3].FirstName} {students[3].LastName}: {18.43}\n" +
                                 $"{students[2].FirstName} {students[2].LastName}: {17.43}\n" +
                                 $"{students[1].FirstName} {students[1].LastName}: {16.43}\n";

        topThreeStudents.Should().Be(topThreeStudentsExpectedValue);
    }
}