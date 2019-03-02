using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;

    public string Name {
        get => name;
        set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            name = value;
        }
    }

    private List<Topping> toppings;

    public Dough Dough { get; private set; }

    public int ToppingCount => toppings.Count;

    public double Calories => CalculateCalories();

    public Pizza(string name, Dough dough)
    {
        Name = name;
        Dough = dough;
        toppings = new List<Topping>();
    }

    private double CalculateCalories()
    {
        if (ToppingCount > 0)
        {
            return Dough.Calories + toppings.Select(x => x.Calories).Sum();
        }

        return Dough.Calories;

    }

    public void AddTopping(Topping t)
    {
        if (ToppingCount >= 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }

        toppings.Add(t);
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:f2} Calories.";
    }
}
