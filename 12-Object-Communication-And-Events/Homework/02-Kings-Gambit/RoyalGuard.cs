using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard : IGuard
{
    public string Name { get; set; }

    public RoyalGuard(string name)
    {
        Name = name;
    }

    public void HandleKingsAttack()
    {
        Console.WriteLine($"Royal Guard {Name} is defending!");
    }

}

