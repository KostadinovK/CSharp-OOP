using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando : ISpecialisedSoldier
{
    List<Mission> Missions { get; set; }
}
