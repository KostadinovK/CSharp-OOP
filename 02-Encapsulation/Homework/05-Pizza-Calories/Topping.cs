using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private const int BaseCaloriesPerGram = 2;
    private const int MinGrams = 1;
    private const int MaxGrams = 50;

    private string type;
    private double weight;
    private double caloriesModifier;

    private string Type
    {
        get => type;
        set
        {
            if (value != "Meat" && value != "Veggies" && value != "Cheese" && value != "Sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            type = value;
        }
    }

    public double Weight
    {
        get => weight;
        private set
        {
            if (value < MinGrams || value > MaxGrams)
            {
                throw new ArgumentException($"{Type} weight should be in the range[{MinGrams}..{MaxGrams}].");
            }

            weight = value;
        }
    }

    public double CaloriesPerGram
    {
        get => caloriesModifier * BaseCaloriesPerGram;
    }

    public Topping(string type, double weight)
    {
        Type = type;
        Weight = weight;

        switch (type)
        {
            case "Meat":
                caloriesModifier = 1.2;
                break;
            case "Veggies":
                caloriesModifier = 0.8;
                break;
            case "Cheese":
                caloriesModifier = 1.1;
                break;
            case "Sauce":
                caloriesModifier = 0.9;
                break;
        }
    }
}
