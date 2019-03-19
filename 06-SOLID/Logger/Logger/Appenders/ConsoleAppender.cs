using System;
using System.Collections.Generic;
using System.Text;

public class ConsoleAppender : IAppender
{
    public int AppendedMessages { get; set; }
    public ILayout Layout { get; set; }
    public ReportLevel ReportLevel { get; set; }

    public ConsoleAppender(ILayout layout)
    {
        AppendedMessages = 0;
        Layout = layout;
        ReportLevel = ReportLevel.Info;
    }

    public void Append(string date, string message, ReportLevel reportLevel)
    {
        if (ReportLevel <= reportLevel)
        {
            AppendedMessages++;
            string result = Layout.Format;
            result = result.Replace("$date-time$", date).Replace("$report-level$", reportLevel.GetType().Name.ToUpper()).Replace("$message$", message);
            Console.WriteLine(result);
        }

    }

    public override string ToString()
    {
        return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {AppendedMessages}\n";
    }
}
