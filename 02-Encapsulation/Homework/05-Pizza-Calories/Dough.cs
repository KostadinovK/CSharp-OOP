using System;
using System.Collections.Generic;
using System.Text;


public class Dough
{

    private const int BaseCaloriesPerGram = 2;
    private const int MinGrams = 1;
    private const int MaxGrams = 200;

    private string flourType;
    private string bakingTechnique;
    private double weight;
    private double flourCaloriesModifier;
    private double bakingCaloriesModifier;

    private double caloriesPerGram;

    private string FlourType {
        get => flourType;
        set {
            if (value != "White" && value != "Wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value;
        }
    }

    private string BakingTechnique {
        get => bakingTechnique;
        set {
            if (value != "Chewy" && value != "Crispy" && value != "Homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value;
        }
    }

    public double Weight {
        get => weight;
        private set {
            if (value < MinGrams || value > MaxGrams)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinGrams}..{MaxGrams}].");
            }

            weight = value;
        }
    }

    public double CaloriesPerGram {
        get => BaseCaloriesPerGram * flourCaloriesModifier * bakingCaloriesModifier;

    }

    public Dough(string type, string technique, double weight)
    {
        FlourType = type;
        BakingTechnique = technique;
        Weight = weight;

        switch (type)
        {
            case "White":
                flourCaloriesModifier = 1.5;
                break;
            case "Wholegrain":
                flourCaloriesModifier = 1.0;
                break;
        }

        switch (technique)
        {
            case "Chewy":
                bakingCaloriesModifier = 1.1;
                break;
            case "Crispy":
                bakingCaloriesModifier = 0.9;
                break;
            case "Homemade":
                bakingCaloriesModifier = 1.0;
                break;
        }

    }
}
