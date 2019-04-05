using System;

public class Program
{
    static void Main(string[] args)
    {
        CombatLogger combatLogger = new CombatLogger();
        EventLogger eventLogger = new EventLogger();
        TargetLogger targetLogger = new TargetLogger();

        combatLogger.SetSuccessor(eventLogger);
        eventLogger.SetSuccessor(targetLogger);

        IAttacker pesho = new Warrior("Pesho", 10, combatLogger);
        IAttacker stamat = new Warrior("Stamat", 20, combatLogger);

        IAttackGroup attackGroup = new AttackGroup();
        attackGroup.AddMember(pesho);
        attackGroup.AddMember(stamat);
        
        ITarget target = new Dragon("Drago", 30, 200, combatLogger);
        ((ISubject) target).Register((IObserver)pesho);
        ((ISubject) target).Register((IObserver)stamat);

        IExecutor executor = new CommandExecutor();
        ICommand groupTargetCommand = new GroupTargetCommand(attackGroup, target);
        ICommand groupAttackCommand = new GroupAttackCommand(attackGroup);

        executor.ExecuteCommand(groupAttackCommand);
        executor.ExecuteCommand(groupTargetCommand);
        executor.ExecuteCommand(groupAttackCommand);
        executor.ExecuteCommand(groupAttackCommand);

    }
}
