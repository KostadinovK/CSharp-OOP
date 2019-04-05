using System;
using System.Collections.Generic;
using System.Text;

public class EventLogger : Logger
{
    public override void Handle(LogType logType, string msg)
    {
        switch (logType)
        {
            case LogType.EVENT:
            case LogType.ERROR:
                Console.WriteLine($"{logType}: {msg}");
                break;
        }

        PassToSuccessor(logType, msg);
    }
}
