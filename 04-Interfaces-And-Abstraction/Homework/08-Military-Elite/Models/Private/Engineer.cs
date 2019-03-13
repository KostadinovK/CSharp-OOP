using System;
using System.Collections.Generic;
using System.Text;


public class Engineer : SpecialisedSoldier, IEngineer
{
    public List<Repair> Repairs { get; set; }

    public Engineer(int id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
    {
        Repairs = repairs;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.Append("\nRepairs:");
        foreach (var repair in Repairs)
        {
            sb.Append("\n" + repair.ToString());
        }

        return sb.ToString();
    }
}
