using System;
using System.Collections.Generic;
using System.Text;


public interface ICommand
{
    Dictionary<string, Weapon> Weapons { get; set; }
    string[] Data { get; set; }

    void Execute();
}
