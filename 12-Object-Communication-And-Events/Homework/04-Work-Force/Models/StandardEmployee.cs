using System;
using System.Collections.Generic;
using System.Text;

public class StandardEmployee : Employee
{
    private const int WorkHours = 40;
    public StandardEmployee(string name) : base(name, WorkHours)
    {
    }
}
