using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public void ExecuteCommand(IAnimalCentre centre, string commandType, string[] commandArgs)
        {
            var command = typeof(Models.AnimalCentre).GetMethod(commandType);

            if (command == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            List<object> commandParams = new List<object>();

            foreach (var commandArg in commandArgs)
            {
                if (int.TryParse(commandArg, out int value))
                {
                    commandParams.Add(value);
                }
                else
                {
                    commandParams.Add(commandArg);
                }
            }
            
            var res = command.Invoke(centre, commandParams.ToArray());

            Console.WriteLine(res);
        }
    }
}
