using System;
using System.Collections.Generic;
using System.Text;

public class Knife : Weapon
{
    public Knife(Rarity rarity, string name) : base(rarity, name)
    {
        MinDamage = 3 * rarity.DamageMultiple;
        MaxDamage = 4 * rarity.DamageMultiple;
        Sockets = new Gem[2];
    }
}
