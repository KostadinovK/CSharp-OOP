using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Factories.Contracts
{
    public interface IMachineFactory
    {
        IMachine CreateMachine(string type, string name, double attackPoints, double defensePoints);
    }
}
