using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        string[] foodsNames = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        List<Food> foods = new List<Food>();

        for (int i = 0; i < foodsNames.Length; i++)
        {
            Food food = FoodFactory.CreateFood(foodsNames[i].ToLower());
            foods.Add(food);
        }

        Mood mood = MoodFactory.CreateMood(foods);

        Gandalf gandalf = new Gandalf(foods, mood);

        Console.WriteLine(gandalf);
    }
}
