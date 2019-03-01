using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    public Dough Dough
    {
        get => dough;
        set { dough = value; }
    }

    public int ToppingsNumber
    {
        get => toppings.Count;
    }

    public double TotalCalories
    {
        get => CalculateCalories();
    }

    public Pizza(string name)
    {
        Name = name;
        toppings = new List<Topping>();
    }

    public void AddTopping(Topping t)
    {
        toppings.Add(t);
        if (ToppingsNumber > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    private double CalculateCalories()
    {
        double doughCaloriesPerGram = dough.CaloriesPerGram;
        double doughWeight = dough.Weight;

        double toppingsTotalCalories = 0;
        foreach (var topping in toppings)
        {
            double weight = topping.Weight;
            toppingsTotalCalories += topping.CaloriesPerGram * weight;
        }

        return doughCaloriesPerGram * dough.Weight + toppingsTotalCalories;
    }

    public override string ToString()
    {
        return $"{Name} - {TotalCalories:f2} Calories.";
    }
}

