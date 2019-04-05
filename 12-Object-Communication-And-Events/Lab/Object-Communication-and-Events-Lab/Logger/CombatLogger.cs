using System;
using System.Collections.Generic;
using System.Text;

public class CombatLogger : Logger
{
    public override void Handle(LogType logType, string msg)
    {
        switch (logType)
        {
            case LogType.ATTACK:
            case LogType.MAGIC:
                Console.WriteLine($"{logType}: {msg}");
                break;
        }

        PassToSuccessor(logType, msg);
    }
}
