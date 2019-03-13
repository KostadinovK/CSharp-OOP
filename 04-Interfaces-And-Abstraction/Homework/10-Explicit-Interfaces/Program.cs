using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        List<Citizen> citizens = new List<Citizen>();

        string line = Console.ReadLine();

        while (line != "End")
        {
            string[] info = line.Split().ToArray();
            string name = info[0];
            string country = info[1];
            int age = int.Parse(info[2]);

            Citizen citizen = new Citizen(name, country, age);
            citizens.Add(citizen);

            line = Console.ReadLine();
        }

        foreach (var citizen in citizens)
        {
            IPerson person = citizen;
            Console.WriteLine(person.GetName());

            IResident resident = citizen;
            Console.WriteLine(resident.GetName());
        }
    }
}
