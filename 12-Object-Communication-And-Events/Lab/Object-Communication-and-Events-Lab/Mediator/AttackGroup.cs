using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class AttackGroup : IAttackGroup
{
    private List<IAttacker> attackers;

    public AttackGroup()
    {
        attackers = new List<IAttacker>();
    }

    public void AddMember(IAttacker attacker)
    {
        attackers.Add(attacker);
    }

    public void GroupTarget(ITarget target)
    {
        foreach (var attacker in attackers)
        {
            attacker.SetTarget(target);
        }
    }

    public void GroupAttack()
    {
        foreach (var attacker in attackers)
        {
            attacker.Attack();
        }
    }
}
