using System;
using System.Collections.Generic;
using System.Text;
public class TargetLogger : Logger
{
    public override void Handle(LogType logType, string msg)
    {
        switch (logType)
        {
            case LogType.TARGET:
                Console.WriteLine($"{logType}: {msg}");
                break;
        }

        PassToSuccessor(logType, msg);
    }
}
