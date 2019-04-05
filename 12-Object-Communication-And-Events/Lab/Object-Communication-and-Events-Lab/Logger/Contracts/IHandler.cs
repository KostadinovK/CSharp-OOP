using System;
using System.Collections.Generic;
using System.Text;
public interface IHandler
{
    void Handle(LogType logType, string msg);

    void SetSuccessor(IHandler handler);

}
