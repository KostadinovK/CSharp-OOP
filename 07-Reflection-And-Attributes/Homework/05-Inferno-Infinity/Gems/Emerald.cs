using System;
using System.Collections.Generic;
using System.Text;


public class Emerald : Gem
{
    public Emerald(Clarity clarity) : base(clarity)
    {
        Strength += 1;
        Agility += 4;
        Vitality += 9;
    }
}
