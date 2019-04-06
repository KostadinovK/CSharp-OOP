using System;
using System.Collections.Generic;
using System.Text;

public class RoyalGuard : IGuard
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public event GuardAttackedEventHandler OnDeath;
    public RoyalGuard(string name)
    {
        Name = name;
        Hp = 3;
    }

    public void TakeDamage()
    {
        Hp--;
        if (Hp == 0)
        {
            OnDeath?.Invoke(this);
        }
    }

    public void HandleKingsAttack()
    {
        Console.WriteLine($"Royal Guard {Name} is defending!");
    }

}

