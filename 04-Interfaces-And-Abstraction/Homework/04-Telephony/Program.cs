using System;
using System.Linq;


public class Program
{
    public static void Main()
    {
        string[] phones = Console.ReadLine().Split().ToArray();
        string[] sites = Console.ReadLine().Split().ToArray();

        Smartphone smartphone = new Smartphone();

        foreach (var phone in phones)
        {
            Console.WriteLine(smartphone.Call(phone));
        }

        foreach (var site in sites)
        {
            Console.WriteLine(smartphone.Browse(site));
        }
    }
}
