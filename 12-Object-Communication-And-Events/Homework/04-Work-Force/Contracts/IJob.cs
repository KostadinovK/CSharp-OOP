using System;
using System.Collections.Generic;
using System.Text;

public interface IJob
{
    string Name { get; }
    int HoursOfWorkRequired { get; }
    IEmployee Employee { get; }
    event JobDoneDelegate JobDoneEvent;

    void Update();
    string Status();
}
