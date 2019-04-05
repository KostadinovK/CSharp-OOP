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

        IAttacker warrior = new Warrior("Pesho", 20, combatLogger);
        ITarget target = new Dragon("Drago", 30, 200, combatLogger);

        warrior.Attack();
        warrior.SetTarget(target);
        warrior.Attack();
        warrior.Attack();
        warrior.Attack();
    }
}
