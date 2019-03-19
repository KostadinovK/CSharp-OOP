using System;
using System.Collections.Generic;
using System.Text;

public interface IAppender
{
    int AppendedMessages { get; set;}
    ILayout Layout { get; set; }
    ReportLevel ReportLevel { get; set; }

    void Append(string date, string message, ReportLevel reportLevel);
}
