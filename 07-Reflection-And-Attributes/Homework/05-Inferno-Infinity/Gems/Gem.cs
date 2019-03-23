using System;
using System.Collections.Generic;
using System.Text;


public abstract class Gem : IGem
{
    public int Strength { get; set; }
    public int Vitality { get; set; }
    public int Agility { get; set; }
    public Clarity Clarity { get; set; }

    protected Gem(Clarity clarity)
    {
        Clarity = clarity;
        Strength += clarity.Bonus;
        Vitality += clarity.Bonus;
        Agility += clarity.Bonus;
    }
}
