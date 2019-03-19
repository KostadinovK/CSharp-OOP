using System;
using System.Collections.Generic;
using System.Text;


public static class AppenderFactory
{
    public static IAppender Get(string[] info)
    {
        ILayout layout = null;

        if (info[1] == "SimpleLayout")
        {
            layout = new SimpleLayout();
        }else if (info[1] == "XmlLayout")
        {
            layout = new XmlLayout();
        }

        IAppender appender = null;

        if (info[0] == "ConsoleAppender")
        {
            appender = new ConsoleAppender(layout);
        }else if (info[0] == "FileAppender")
        {
            appender = new FileAppender(layout, new LogFile());
        }

        if (info.Length == 3)
        {
            switch (info[2])
            {
                case "WARNING":
                    appender.ReportLevel = ReportLevel.Warning;
                    break;
                case "ERROR":
                    appender.ReportLevel = ReportLevel.Error;
                    break;
                case "CRITICAL":
                    appender.ReportLevel = ReportLevel.Critical;
                    break;
                case "FATAL":
                    appender.ReportLevel = ReportLevel.Fatal;
                    break;
            }
        }

        return appender;
    }
}
