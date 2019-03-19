using System;
using System.Collections.Generic;
using System.Text;

public class Logger : ILogger
{
    public List<IAppender> Appenders { get; set; }
    

    public Logger(params IAppender[] appenders)
    {
        Appenders = new List<IAppender>(appenders);
    }
    public Logger(List<IAppender> appenders)
    {
        Appenders = appenders;
    }

    public void Error(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, message, ReportLevel.Error);
        }
    }

    public void Info(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, message, ReportLevel.Info);
        }
    }

    public void Fatal(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, message, ReportLevel.Fatal);
        }
    }

    public void Critical(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, message, ReportLevel.Critical);
        }
    }

    public void Warning(string date, string message)
    {
        foreach (var appender in Appenders)
        {
            appender.Append(date, message, ReportLevel.Warning);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Logger info");
        if (Appenders.Count > 0)
        {
            foreach (var appender in Appenders)
            {
                sb.AppendLine(appender.ToString());
            }
        }

        return sb.ToString();
    }
}
