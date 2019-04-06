using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Program
{
    public static void Main()
    {
        JobCollection jobs = new JobCollection();

        Dictionary<string, IEmployee> employees = new Dictionary<string, IEmployee>();

        string command = Console.ReadLine();

        while (command != "End")
        {
            string[] commandArgs = command.Split().ToArray();
            
            if (commandArgs[0] == "PartTimeEmployee")
            {
                employees.Add(commandArgs[1], new PartTimeEmployee(commandArgs[1]));
            }
            else if (commandArgs[0] == "StandardEmployee")
            {
                employees.Add(commandArgs[1], new StandardEmployee(commandArgs[1]));
            }
            else if(commandArgs[0] == "Job")
            {
                string employeeName = commandArgs[3];
                var employee = employees[employeeName];
                IJob job = new Job(commandArgs[1], int.Parse(commandArgs[2]), employee);
                jobs.AddJob(job);
            }
            else if(commandArgs[0] == "Pass")
            {
                jobs.PassWeek();
            }
            else if(commandArgs[0] == "Status")
            {
                jobs.Status();
            }

            command = Console.ReadLine();
        }
    }
}
