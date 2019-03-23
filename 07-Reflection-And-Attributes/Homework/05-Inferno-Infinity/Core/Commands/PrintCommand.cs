using System;
using System.Collections.Generic;
using System.Text;


public class PrintCommand : Command
{
    public PrintCommand(string[] data, Dictionary<string, Weapon> weapons)
    {
        Data = data;
        Weapons = weapons;
    }

    public override void Execute()
    {
        string name = Data[0];

        Console.WriteLine(Weapons[name]);
    }
}
