using System;
using System.Collections.Generic;
using System.Text;

public class FileAppender : IAppender
{
    public int AppendedMessages { get; set; }
    public ILayout Layout { get; set; }
    public ReportLevel ReportLevel { get; set; }

    public IFile LogFile { get; set; }

    public FileAppender(ILayout layout, IFile file)
    {
        AppendedMessages = 0;
        Layout = layout;
        LogFile = file;
        ReportLevel = ReportLevel.Info;
    }

    public void Append(string date, string message, ReportLevel reportLevel)
    {
        if (ReportLevel <= reportLevel)
        {
            AppendedMessages++;
            string result = Layout.Format;
            result = result.Replace("$date-time$", date).Replace("$report-level$", reportLevel.GetType().Name.ToUpper()).Replace("$message$", message);

            LogFile.Write(result);
        }
    }

    public override string ToString()
    {
        return $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {AppendedMessages}, File size: {LogFile.Size}\n";
    }
}
