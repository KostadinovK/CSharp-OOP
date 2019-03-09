using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Gandalf
{
    public List<Food> Foods { get; private set; }

    public Mood Mood { get; private set; }

    public Gandalf(List<Food> foods, Mood mood)
    {
        Foods = foods;
        Mood = mood;
    }

    public override string ToString()
    {
        return Foods.Select(x => x.HappinessPoints).Sum() + "\n" + Mood;
    }
}

