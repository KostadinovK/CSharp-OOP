using System;
using System.Collections.Generic;
using System.Text;
using MortalEngines.Entities.Contracts;

namespace MortalEngines.Repositories.Contracts
{
    public interface IMachineRepository
    {
        IReadOnlyList<IMachine> Machines { get; }
        void AddMachine(IMachine machine);
        void RemoveMachine(IMachine machine);
        bool ContainsMachine(string name);
    }
}
