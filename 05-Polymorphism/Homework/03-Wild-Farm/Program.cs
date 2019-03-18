using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        List<Animal> animals = new List<Animal>();
        Animal currentAnimal = null;

        int lineCount = 0;
        string line = Console.ReadLine();

        while (line != "End")
        {
            if (lineCount == 0 || lineCount % 2 == 0)
            {
                string[] animalInfo = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Animal animal = AnimalFactory.GetAnimal(animalInfo[0], animalInfo.Skip(1).ToArray());
                Console.WriteLine(animal.ProduceSound());

                animals.Add(animal);
                currentAnimal = animal;
            }
            else
            {
                string[] foodInfo = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Food food = FoodFactory.GetFood(foodInfo[0], int.Parse(foodInfo[1]));

                try
                {
                    currentAnimal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            line = Console.ReadLine();
            lineCount++;
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}
