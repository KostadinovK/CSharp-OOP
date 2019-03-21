using System;

[Author("Pesho")]
public class Program
{
    [Author("Gosho")]
    public static void Main()
    {
        Tracker tracker = new Tracker();

        tracker.PrintMethodsByAuthor();
    }
}
