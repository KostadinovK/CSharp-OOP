using System;
using System.Collections.Generic;
using System.Text;


public static class WeaponFactory
{
    public static Weapon GetWeapon(string rarityType, string type, string name)
    {
        var typeOfRarity = Type.GetType(rarityType + "Rarity");
        Rarity rarity = (Rarity)Activator.CreateInstance(typeOfRarity);

        var typeOfWeapon = Type.GetType(type);

        return (Weapon)Activator.CreateInstance(typeOfWeapon, new object[]{rarity, name});
    }
}
