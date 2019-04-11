using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private IAnimalCentre centre;
        private ICommandInterpreter interpreter;

        public Engine(IAnimalCentre centre, ICommandInterpreter interpreter)
        {
            this.centre = centre;
            this.interpreter = interpreter;
        }
        public void Run()
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                try
                {
                    string[] commandArgs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string command = commandArgs[0];

                    interpreter.ExecuteCommand(centre, command, commandArgs.Skip(1).ToArray());
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
