using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private const double BaseCaloriesModifier = 2;

    private Dictionary<string, double> validFlourTypes;
    private Dictionary<string, double> validBakingTechniques;

    private string flourType;

    public string FlourType {
        get => flourType; 
        private set
        {
            if (!validFlourTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flourType = value;
        }
    }

    private string bakingTechnique;

    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (!validBakingTechniques.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            bakingTechnique = value;
        }
    }

    private double weight;

    public double Weight {
        get => weight;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            weight = value;
        }
    }

    public double Calories => CalculateCalories();

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        validFlourTypes = new Dictionary<string, double>();
        validBakingTechniques = new Dictionary<string, double>();
        SeedFlourTypes();
        SeedBakingTechniques();

        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    private void SeedFlourTypes()
    {
        validFlourTypes.Add("white", 1.5);
        validFlourTypes.Add("wholegrain", 1.0);
    }

    private void SeedBakingTechniques()
    {
        validBakingTechniques.Add("crispy", 0.9);
        validBakingTechniques.Add("chewy", 1.1);
        validBakingTechniques.Add("homemade", 1.0);
    }

    private double CalculateCalories()
    {
        return Weight * BaseCaloriesModifier * validFlourTypes[FlourType.ToLower()] * validBakingTechniques[BakingTechnique.ToLower()];
    }
}

