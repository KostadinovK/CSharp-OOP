using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MortalEngines.Core.Contracts;
using MortalEngines.IO.Contracts;

namespace MortalEngines.Core
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
            var writer = provider.GetService<IWriter>();
            var machinesManager = provider.GetService<IMachinesManager>();
            string line = Console.ReadLine();

            while (line != "Quit")
            {
                string[] commandArgs = line.Split().ToArray();

                try
                {
                    string command = commandArgs[0];

                    switch (command)
                    {
                        case "HirePilot":
                            writer.Write(machinesManager.HirePilot(commandArgs[1]));
                            break;

                        case "PilotReport":
                            writer.Write(machinesManager.PilotReport(commandArgs[1]));
                            break;

                        case "ManufactureTank":
                            string tankName = commandArgs[1];
                            double tankAttackPoints = double.Parse(commandArgs[2]);
                            double tankDefensePoints = double.Parse(commandArgs[3]);

                            writer.Write(machinesManager.ManufactureTank(tankName, tankAttackPoints, tankDefensePoints));
                            break;

                        case "ManufactureFighter":
                            string fighterName = commandArgs[1];
                            double fighterAttackPoints = double.Parse(commandArgs[2]);
                            double fighterDefensePoints = double.Parse(commandArgs[3]);

                            writer.Write(machinesManager.ManufactureFighter(fighterName, fighterAttackPoints, fighterDefensePoints));
                            break;

                        case "MachineReport":
                            writer.Write(machinesManager.MachineReport(commandArgs[1]));
                            break;

                        case "AggressiveMode":
                            writer.Write(machinesManager.ToggleFighterAggressiveMode(commandArgs[1]));
                            break;

                        case "DefenseMode":
                            writer.Write(machinesManager.ToggleTankDefenseMode(commandArgs[1]));
                            break;

                        case "Engage":
                            string pilotName = commandArgs[1];
                            string machineName = commandArgs[2];

                            writer.Write(machinesManager.EngageMachine(pilotName, machineName));
                            break;

                        case "Attack":
                            string attackingMachineName = commandArgs[1];
                            string defendingMachineName = commandArgs[2];

                            writer.Write(machinesManager.AttackMachines(attackingMachineName, defendingMachineName));
                            break;
                    }
                }
                catch (NullReferenceException nullReferenceException)
                {
                    Console.WriteLine("Error:" + nullReferenceException.Message);
                }
                catch (ArgumentNullException argumentNullException)
                {
                    Console.WriteLine("Error:" + argumentNullException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine("Error:" + argumentException.Message);
                }

                line = Console.ReadLine();
            }
        }
    }
}
