using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GuardCollection
{
    private List<IGuard> guards;

    public GuardCollection()
    {
        guards = new List<IGuard>();
    }

    public void AddGuard(IGuard guard)
    {
        guards.Add(guard);
        guard.OnDeath += HandleGuardDeath;
    }

    public void Kill(string guardName)
    {
        IGuard guard = guards.FirstOrDefault(g => g.Name == guardName);
        guard?.TakeDamage();
    }

    public void HandleKingsAttack()
    {
        foreach (var guard in guards)
        {
            guard.HandleKingsAttack();
        }
    }

    public void HandleGuardDeath(IGuard guard)
    {
        guards.Remove(guard);
    }
}
