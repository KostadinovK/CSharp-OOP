using System;
using System.Collections.Generic;
using System.Text;

public class Repair : IRepair
{
    public string PartName { get; set; }
    public int HoursWorked { get; set; }

    public Repair(string partName, int hoursWorked)
    {
        PartName = partName;
        HoursWorked = hoursWorked;
    }

    public override string ToString()
    {
        return $"  Part Name: {PartName} Hours Worked: {HoursWorked}";
    }
}
