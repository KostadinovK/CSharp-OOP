using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class AddCommand : Command
{
    public AddCommand(string[] data, Dictionary<string, Weapon> weapons)
    {
        Data = data;
        Weapons = weapons;
    }

    public override void Execute()
    {
        string name = Data[0];
        int index = int.Parse(Data[1]);
        string[] gemInfo = Data[2].Split().ToArray();
        string clarityType = gemInfo[0];
        string gemType = gemInfo[1];

        Gem gem = GemFactory.GetGem(clarityType, gemType);

        Weapons[name].AddGem(index, gem);
    }
}
