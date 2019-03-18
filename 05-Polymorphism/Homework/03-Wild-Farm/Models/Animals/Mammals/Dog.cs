using System;
using System.Collections.Generic;
using System.Text;


public class Dog : Mammal
{

    public override double WeightPerPiece { get; set; }
    public override List<string> FoodTypes { get; set; }

    public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
    {
        WeightPerPiece = 0.4;
        FoodTypes = new List<string>{"Meat"};
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }
}
