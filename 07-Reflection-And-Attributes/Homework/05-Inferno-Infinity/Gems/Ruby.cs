using System;
using System.Collections.Generic;
using System.Text;


public class Ruby : Gem
{
    public Ruby(Clarity clarity) : base(clarity)
    {
        Strength += 7;
        Agility += 2;
        Vitality += 5;
    }
}
