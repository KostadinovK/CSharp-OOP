using System;
using System.Collections.Generic;
using System.Text;

interface IWeapon
{
    string Name { get; set; }
    int MinDamage { get; set; }
    int MaxDamage { get; set; }
    Gem[] Sockets { get; set; }
    int Strength { get; set; }
    int Agility { get; set; }
    int Vitality { get; set; }
    IRarity Rarity { get; set; }

    void AddGem(int index, Gem gem);
    void RemoveGem(int index);
}
