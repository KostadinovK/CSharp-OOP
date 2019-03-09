using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public double WeekSalary {
        get => weekSalary;
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get => workHoursPerDay;
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            workHoursPerDay = value;
        }
    }

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    public double CalculateSalaryPerHour()
    {
        return WeekSalary / (5 * workHoursPerDay);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine($"Week Salary: {WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {WorkHoursPerDay:f2}");
        sb.AppendLine($"Salary per hour: {CalculateSalaryPerHour():f2}");

        return sb.ToString();
    }
}

