using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();

        string line = Console.ReadLine();

        if (line == "Beast!")
        {
            Environment.Exit(0);
        }

        string[] animalInfo = Console.ReadLine().Split().ToArray();

        while (true)
        {
            try
            {
                string type = line;
                Animal animal = AnimalFactory.Get(type, animalInfo);

                animals.Add(animal);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
     
            line = Console.ReadLine();

            if (line == "Beast!")
            {
                break;
            }

            animalInfo = Console.ReadLine().Split().ToArray();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}
