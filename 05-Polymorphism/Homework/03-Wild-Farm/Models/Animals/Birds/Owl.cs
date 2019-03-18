using System;
using System.Collections.Generic;
using System.Text;


public class Owl : Bird
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
    {
        WeightPerPiece = 0.25;
        FoodTypes = new List<string>{"Meat"};
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}
