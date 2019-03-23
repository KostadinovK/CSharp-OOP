using System;
using System.Collections.Generic;
using System.Text;


public abstract class Command : ICommand
{
    public Dictionary<string, Weapon> Weapons { get; set; }
    public string[] Data { get; set; }
    public abstract void Execute();
}
