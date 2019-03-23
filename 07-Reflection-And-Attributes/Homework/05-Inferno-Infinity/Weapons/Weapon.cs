using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public abstract class Weapon : IWeapon
{
    public string Name { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public Gem[] Sockets { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Vitality { get; set; }
    public IRarity Rarity { get; set; }
   

    protected Weapon(Rarity rarity, string name)
    {
        Rarity = rarity;
        Name = name;
        Strength = 0;
        Vitality = 0;
        Agility = 0;
       
    }

    public void AddGem(int index, Gem gem)
    {
        if (index < 0 || index >= Sockets.Length)
        {
            return;
        }

        if (Sockets[index] != null)
        {
            Strength -= Sockets[index].Strength;
            Vitality -= Sockets[index].Vitality;
            Agility -= Sockets[index].Agility;

            MinDamage -= 2 * Sockets[index].Strength;
            MaxDamage -= 3 * Sockets[index].Strength;
            MinDamage -= Sockets[index].Agility;
            MaxDamage -= 4 * Sockets[index].Agility;
        }

        Sockets[index] = gem;

        Strength += Sockets[index].Strength;
        Vitality += Sockets[index].Vitality;
        Agility += Sockets[index].Agility;

        MinDamage += 2 * Sockets[index].Strength;
        MaxDamage += 3 * Sockets[index].Strength;
        MinDamage += Sockets[index].Agility;
        MaxDamage += 4 * Sockets[index].Agility;
    }

    public void RemoveGem(int index)
    {
        if (index < 0 || index >= Sockets.Length || Sockets[index] == null)
        {
            return;
        }

        Strength -= Sockets[index].Strength;
        Vitality -= Sockets[index].Vitality;
        Agility -= Sockets[index].Agility;

        MinDamage -= 2 * Sockets[index].Strength;
        MaxDamage -= 3 * Sockets[index].Strength;
        MinDamage -= Sockets[index].Agility;
        MaxDamage -= 4 * Sockets[index].Agility;

        Sockets[index] = null;
    }

    public override string ToString()
    {
        return
            $"{Name}: {MinDamage}-{MaxDamage} Damage, +{Strength} Strength, +{Agility} Agility, +{Vitality} Vitality";
    }
}
