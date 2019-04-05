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

        IAttackGroup attackGroup = new AttackGroup();
        attackGroup.AddMember(new Warrior("Pesho", 10, combatLogger));
        attackGroup.AddMember(new Warrior("Stamat", 20, combatLogger));
        
        ITarget target = new Dragon("Drago", 30, 200, combatLogger);

        IExecutor executor = new CommandExecutor();
        ICommand groupTargetCommand = new GroupTargetCommand(attackGroup, target);
        ICommand groupAttackCommand = new GroupAttackCommand(attackGroup);

        executor.ExecuteCommand(groupAttackCommand);
        executor.ExecuteCommand(groupTargetCommand);
        executor.ExecuteCommand(groupAttackCommand);
        executor.ExecuteCommand(groupAttackCommand);

    }
}
