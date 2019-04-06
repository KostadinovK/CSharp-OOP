using System;
using System.Collections.Generic;
using System.Text;

public class Footman : IGuard
{
    public string Name { get; private set; }
    public int Hp { get; private set; }
    public event GuardAttackedEventHandler OnDeath;
    public Footman(string name)
    {
        Name = name;
        Hp = 2;
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
        Console.WriteLine($"Footman {Name} is panicking!");
    }

}
