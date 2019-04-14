using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Factories.Contracts
{
    public interface IPilotFactory
    {
        IPilot CreatePilot(string type, string name);
    }
}
