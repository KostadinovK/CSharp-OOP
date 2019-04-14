using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MortalEngines.Entities.Contracts;
using MortalEngines.Factories.Contracts;

namespace MortalEngines.Factories
{
    public class PilotFactory : IPilotFactory
    {
        public IPilot CreatePilot(string type, string name)
        {
            var pilotType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (pilotType == null)
            {
                throw new ArgumentException("Invalid pilot type");
            }

            var pilot = (IPilot)Activator.CreateInstance(pilotType, name);

            return pilot;
        }
    }
}
