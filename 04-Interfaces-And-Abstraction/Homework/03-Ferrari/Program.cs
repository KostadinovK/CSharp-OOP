using System;

public class Program
{
    public static void Main()
    {
        string driver = Console.ReadLine();

        Ferrari f = new Ferrari(driver);

        Console.WriteLine(f);
    }
}

