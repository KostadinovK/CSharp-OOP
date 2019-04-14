using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Repositories.Contracts
{
    public interface IPilotRepository
    {
        IReadOnlyList<IPilot> Pilots { get; }
        void AddPilot(IPilot pilot);

        void RemovePilot(IPilot pilot);
        bool ContainsPilot(string name);
    }
}
