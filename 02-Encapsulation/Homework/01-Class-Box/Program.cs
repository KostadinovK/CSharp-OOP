using System;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        Box box = new Box(length, width, height);

        Console.WriteLine($"Surface Area - {box.GetSurface():f2}");
        Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurface():f2}");
        Console.WriteLine($"Volume - {box.GetVolume():f2}");
    }
}
