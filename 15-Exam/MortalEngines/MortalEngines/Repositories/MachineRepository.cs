using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MortalEngines.Entities.Contracts;
using MortalEngines.Repositories.Contracts;

namespace MortalEngines.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly List<IMachine> machines;
        public IReadOnlyList<IMachine> Machines => machines.AsReadOnly();

        public MachineRepository()
        {
            machines = new List<IMachine>();
        }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);
        }

        public void RemoveMachine(IMachine machine)
        {
            if (machines.Contains(machine))
            {
                machines.Remove(machine);
            }
        }

        public bool ContainsMachine(string name)
        {
            return machines.Select(m => m.Name).Contains(name);
        }
    }
}
