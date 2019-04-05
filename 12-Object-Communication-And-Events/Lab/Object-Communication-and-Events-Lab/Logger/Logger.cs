using System;
using System.Collections.Generic;
using System.Text;

public abstract class Logger : IHandler
{
    private IHandler successor;

    public abstract void Handle(LogType logType, string msg);

    public void SetSuccessor(IHandler handler)
    {
        successor = handler;
    }

    protected void PassToSuccessor(LogType logType, string msg)
    {
        successor?.Handle(logType, msg);
    }
}
