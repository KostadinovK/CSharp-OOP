using System;
using System.Collections.Generic;
using System.Text;

public class Footman : IGuard
{
    public string Name { get; set; }
   
    public Footman(string name)
    {
        Name = name;
    }

    public void HandleKingsAttack()
    {
        Console.WriteLine($"Footman {Name} is panicking!");
    }

}
