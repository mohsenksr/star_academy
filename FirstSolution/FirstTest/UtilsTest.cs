using FirstCode;
using FirstCode.Models;
using FluentAssertions;
using NSubstitute;

namespace FirstTest;

public class UtilsTest
{
    private readonly ICalculator _calculator;
    private readonly Utils _utils;

    public UtilsTest()
    {
        _calculator = Substitute.For<ICalculator>();
        _utils = new Utils(_calculator);
    }
    
    [Fact(DisplayName = "Test simple mapping grades to students")]
    public void TestMappingGradesToStudents()
    {
        // Arrange
        List<Student> students = new List<Student>()
        {
            new Student {StudentNumber = 1, FirstName = "Ali", LastName = "Alavi"},
            new Student {StudentNumber = 2, FirstName = "Mahdi", LastName = "Mahdavi"},
            new Student {StudentNumber = 3, FirstName = "Mostafa", LastName = "Mostafavi"},
            new Student {StudentNumber = 4, FirstName = "Yahya", LastName = "Yahyavi"},
        };

        List<Grade> grades = new List<Grade>()
        {
            new Grade { StudentNumber = 1, Lesson = "AP", Score = 18.2 },
            new Grade { StudentNumber = 2, Lesson = "AP", Score = 16.2 },
            new Grade { StudentNumber = 3, Lesson = "AP", Score = 14.2 },
            new Grade { StudentNumber = 4, Lesson = "AP", Score = 12.2 },
            new Grade { StudentNumber = 1, Lesson = "DA", Score = 17.2 },
            new Grade { StudentNumber = 2, Lesson = "DA", Score = 15.2 },
            new Grade { StudentNumber = 3, Lesson = "DA", Score = 13.2 },
            new Grade { StudentNumber = 4, Lesson = "DA", Score = 11.2 },
        };
        
        // Act
        students = _utils.MapGradesToStudents(grades, students);

        // Assert
        students[2].Grades.Count.Should().Be(2);

        students[2].Grades.Should().BeEquivalentTo(new List<Grade>(){ grades[2], grades[6] });
    }
    
    [Fact(DisplayName = "Test average of grades mocking Calculator")]
    public void TestStudentAverageGrade()
    {
        // Arrange
        _calculator.Average(default).ReturnsForAnyArgs(15.43);
        
        // Act
        double studentAverageGrade = _utils.AverageGrade(new Student());
        
        // Assert
        Assert.Equal(15.43, studentAverageGrade);
    }
}