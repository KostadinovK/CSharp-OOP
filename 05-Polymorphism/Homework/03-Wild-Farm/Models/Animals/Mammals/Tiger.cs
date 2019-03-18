using System;
using System.Collections.Generic;
using System.Text;


public class Tiger : Feline
{
    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
    {
        WeightPerPiece = 1.0;
        FoodTypes = new List<string>{"Meat"};
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }
}
