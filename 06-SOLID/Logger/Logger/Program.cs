using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int appendersCount = int.Parse(Console.ReadLine());

        List<IAppender> appenders = new List<IAppender>();

        for (int i = 0; i < appendersCount; i++)
        {
            string[] appenderInfo = Console.ReadLine().Split().ToArray();

            IAppender appender = AppenderFactory.Get(appenderInfo);
            appenders.Add(appender);
        }

        ILogger logger = new Logger(appenders);

        string line = Console.ReadLine();

        while (line != "END")
        {
            string[] messageInfo = line.Split("|").ToArray();

            string type = messageInfo[0];
            string date = messageInfo[1];
            string message = messageInfo[2];

            switch (type)
            {
                case "INFO":
                    logger.Info(date, message);
                    break;
                case "WARNING":
                    logger.Warning(date, message);
                    break;
                case "ERROR":
                    logger.Error(date, message);
                    break;
                case "CRITICAL":
                    logger.Critical(date, message);
                    break;
                case "FATAL":
                    logger.Fatal(date, message);
                    break;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine(logger);
    }
}
