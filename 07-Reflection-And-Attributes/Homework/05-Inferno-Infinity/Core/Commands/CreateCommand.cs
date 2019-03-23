using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CreateCommand : Command
{
    public CreateCommand(string[] data, Dictionary<string, Weapon> weapons)
    {
        Data = data;
        Weapons = weapons;
    }

    public override void Execute()
    {
        string[] weaponInfo = Data[0].Split().ToArray();
        string rarityType = weaponInfo[0];
        string type = weaponInfo[1];
        string name = Data[1];

        Weapon weapon = WeaponFactory.GetWeapon(rarityType, type, name);

        Weapons.Add(name, weapon);
    }
}
