using System;
using System.Collections.Generic;
using System.Text;

public class LieutenantGeneral : Private, ILieutenantGeneral
{
    public List<Private> UnderCommand { get; set; }

    public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, List<Private> privates) : base(id, firstName, lastName, salary)
    {
        UnderCommand = privates;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(base.ToString());
        sb.Append("Privates:");

        foreach (var pr in UnderCommand)
        {
            sb.Append("\n  " + pr.ToString());
        }

        return sb.ToString();
    }
}
