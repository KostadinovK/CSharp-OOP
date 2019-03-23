using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RemoveCommand : Command
{
    public RemoveCommand(string[] data, Dictionary<string, Weapon> weapons)
    {
        Data = data;
        Weapons = weapons;
    }

    public override void Execute()
    {
        string name = Data[0];
        int index = int.Parse(Data[1]);

        Weapons[name].RemoveGem(index);
    }
}
