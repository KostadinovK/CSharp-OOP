using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Mouse(string name, double weight, string living) : base(name, weight, living)
    {
        WeightPerPiece = 0.1;
        FoodTypes = new List<string>{"Fruit", "Vegetable"};
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }
}
