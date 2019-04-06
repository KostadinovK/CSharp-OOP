using System;
using System.Collections.Generic;
using System.Text;

public abstract class Employee : IEmployee
{
    public string Name { get; set; }
    public int WorkHoursPerWeek { get; }

    protected Employee(string name, int workHoursPerWeek)
    {
        Name = name;
        WorkHoursPerWeek = workHoursPerWeek;
    }
}
