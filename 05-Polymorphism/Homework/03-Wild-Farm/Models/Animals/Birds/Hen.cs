using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        WeightPerPiece = 0.35;
        FoodTypes = new List<string>{"Vegetable", "Fruit", "Seeds", "Meat"};
    }

    

    public override string ProduceSound()
    {
        return "Cluck";
    }
}
