using System;
using System.Collections.Generic;
using System.Text;

public class PartTimeEmployee : Employee
{
    private const int WorkHours = 20;
    public PartTimeEmployee(string name) : base(name, WorkHours)
    {
    }
}
