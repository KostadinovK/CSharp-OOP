using System;
using System.Collections.Generic;
using System.Text;


public class Amethyst : Gem
{
    public Amethyst(Clarity clarity) : base(clarity)
    {
        Strength += 2;
        Agility += 8;
        Vitality += 4;
    }
}
