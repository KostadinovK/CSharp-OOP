using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        List<IIdentifiable> cityEnters = new List<IIdentifiable>();

        string line = Console.ReadLine();

        while (line != "End")
        {
            string[] tokens = line.Split().ToArray();

            IIdentifiable enter = null;

            if (tokens.Length == 2)
            {
                enter = new Robot(tokens[0], tokens[1]);
            }
            else
            {
                enter = new Citizen(tokens[0], int.Parse(tokens[1]),tokens[2]);
            }

            cityEnters.Add(enter);

            line = Console.ReadLine();
        }

        string digits = Console.ReadLine();

        var toRemove = cityEnters.Where(x => x.Id.EndsWith(digits)).ToList();

        foreach (var entry in toRemove)
        {
            Console.WriteLine(entry.Id);
        }
    }
}
