using System;
using System.Collections.Generic;
using System.Text;

public class Private : Soldier, IPrivate
{
    public decimal Salary { get; set; }

    public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
    }
}
