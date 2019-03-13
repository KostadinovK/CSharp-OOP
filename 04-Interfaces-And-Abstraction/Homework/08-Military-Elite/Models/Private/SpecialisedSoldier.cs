using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public string Corps { get; set; }

    protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public override string ToString()
    {
        string res = base.ToString();
        res += "\nCorps: " + Corps;

        return res;
    }
}
