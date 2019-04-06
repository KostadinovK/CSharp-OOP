using System;
using System.Collections.Generic;
using System.Text;

public class Job : IJob
{
    public string Name { get; private set; }
    public int HoursOfWorkRequired { get; private set; }
    public IEmployee Employee { get; private set; }

    public event JobDoneDelegate JobDoneEvent;

    public Job(string name, int hoursOfWorkRequired, IEmployee employee)
    {
        Name = name;
        HoursOfWorkRequired = hoursOfWorkRequired;
        Employee = employee;
    }

    public void Update()
    {
        HoursOfWorkRequired -= Employee.WorkHoursPerWeek;
        if (HoursOfWorkRequired <= 0)
        {
            NotifyJobDone();
        }
    }

    public string Status()
    {
        return $"Job: {Name} Hours Remaining: {HoursOfWorkRequired}";
    }

    private void NotifyJobDone()
    {
        Console.WriteLine($"Job {Name} done!");
        JobDoneEvent.Invoke(this);
    }
}
