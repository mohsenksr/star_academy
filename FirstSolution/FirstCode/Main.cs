namespace FirstCode;

public class Main
{
    private readonly StudentWorker _studentWorker;

    public Main(StudentWorker studentWorker)
    {
        _studentWorker = studentWorker;
    }

    public void Execute()
    {
        Console.WriteLine(_studentWorker.GetTopStudents(3));
    }
}