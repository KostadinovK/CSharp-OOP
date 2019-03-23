using System;
using System.Collections.Generic;
using System.Text;

public class Sword : Weapon
{
    public Sword(Rarity rarity, string name) : base(rarity, name)
    {
        MinDamage = 4 * rarity.DamageMultiple;
        MaxDamage = 6 * rarity.DamageMultiple;
        Sockets = new Gem[3];
    }
}
