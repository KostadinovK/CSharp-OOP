using System;
using System.Collections.Generic;
using System.Text;


public interface IEatable
{
    double WeightPerPiece { get; set; }
    List<string> FoodTypes { get; set; }

    void Eat(Food food);
}
