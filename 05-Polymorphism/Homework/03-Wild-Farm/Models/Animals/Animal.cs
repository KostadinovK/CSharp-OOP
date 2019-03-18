using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal : ISoundProducable, IEatable
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public abstract double WeightPerPiece { get; set; }
    public abstract List<string> FoodTypes { get; set; }

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
        FoodEaten = 0;
    }

    public abstract string ProduceSound();

    public virtual void Eat(Food food)
    {
        if (!FoodTypes.Contains(food.GetType().Name))
        {
            throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
        }

        Weight += WeightPerPiece * food.Quantity;
        FoodEaten += food.Quantity;
    }
}
