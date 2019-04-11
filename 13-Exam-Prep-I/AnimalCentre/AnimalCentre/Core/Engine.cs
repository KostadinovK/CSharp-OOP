using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private IServiceProvider provider;

        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public void Run()
        {
            var commandInterpreter = provider.GetService<ICommandInterpreter>();
            var centre = provider.GetService<IAnimalCentre>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                try
                {
                    string[] commandArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string command = commandArgs[0];

                    commandInterpreter.ExecuteCommand(centre, command, commandArgs.Skip(1).ToArray());
                }
                catch (TargetInvocationException e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
               
                line = Console.ReadLine();
            }

            Console.WriteLine(centre.GetOwnersInformation());
            
        }
    }
}
