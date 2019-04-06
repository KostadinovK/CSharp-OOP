using System;
using System.Collections.Generic;
using System.Text;


public delegate void OnAttackEventHandler();
public class King
{
    public string Name { get; set; }
    public event OnAttackEventHandler Attack;

    public King(string name)
    {
        Name = name;
    }

    public void IsAttacked()
    {
        Console.WriteLine($"King {Name} is under attack!");
        OnAttack();
    }

    private void OnAttack()
    {
        Attack?.Invoke();
    }
}

