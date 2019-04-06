using System;
using System.Collections.Generic;
using System.Text;

public interface IGuard
{
    string Name { get; }
    int Hp { get; }
    event GuardAttackedEventHandler OnDeath;

    void TakeDamage();
    void HandleKingsAttack();
}
