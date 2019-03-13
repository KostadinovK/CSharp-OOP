using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<IBirthable> birthables = new List<IBirthable>();

        string line = Console.ReadLine();

        while (line != "End")
        {
            string[] tokens = line.Split().ToArray();

            if (tokens[0] == "Citizen")
            {
                IBirthable citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                birthables.Add(citizen);
            }else if (tokens[0] == "Pet")
            {
                IBirthable pet = new Pet(tokens[1], tokens[2]);
                birthables.Add(pet);
            }

            line = Console.ReadLine();
        }

        int year = int.Parse(Console.ReadLine());

        birthables = birthables.Where(x => x.Birthyear == year).ToList();
        Console.WriteLine(string.Join('\n', birthables.Select(x => x.Birthdate)));
    }
}
