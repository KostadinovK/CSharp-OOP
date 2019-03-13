using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public List<Mission> Missions { get; set; }

    public Commando(int id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
    {
        Missions = missions;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.Append("\nMissions:");
        foreach (var mission in Missions)
        {
            sb.Append("\n" + mission.ToString());
        }

        return sb.ToString();
    }
}
