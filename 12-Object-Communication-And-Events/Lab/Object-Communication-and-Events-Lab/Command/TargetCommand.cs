using System;
using System.Collections.Generic;
using System.Text;

public class TargetCommand : ICommand
{
    private readonly IAttacker attacker;
    private readonly ITarget target;

    public TargetCommand(IAttacker attacker, ITarget target)
    {
        this.attacker = attacker;
        this.target = target;
    }

    public void Execute()
    {
        attacker?.SetTarget(target);
    }
}
