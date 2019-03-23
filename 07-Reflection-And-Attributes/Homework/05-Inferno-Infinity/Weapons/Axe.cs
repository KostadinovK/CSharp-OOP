using System;
using System.Collections.Generic;
using System.Text;

public class Axe : Weapon
{

    public Axe(Rarity rarity, string name) : base(rarity, name)
    {
        MinDamage = 5 * rarity.DamageMultiple;
        MaxDamage = 10 * rarity.DamageMultiple;
        Sockets = new Gem[4];
    }


}
