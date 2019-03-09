using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] studentInfo = Console.ReadLine().Split().ToArray();
        string[] workerInfo = Console.ReadLine().Split().ToArray();

        try
        {
            Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
            Worker worker = new Worker(workerInfo[0], workerInfo[1], double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
