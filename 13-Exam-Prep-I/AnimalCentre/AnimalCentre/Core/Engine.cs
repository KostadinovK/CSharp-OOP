using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private IAnimalCentre centre;

        public Engine(IAnimalCentre centre)
        {
            this.centre = centre;
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
                    string name = null;
                    int procedureTime = 0;

                    switch (command)
                    {
                        case "RegisterAnimal":
                            string type = commandArgs[1];
                            name = commandArgs[2];
                            int energy = int.Parse(commandArgs[3]);
                            int happiness = int.Parse(commandArgs[4]);
                            procedureTime = int.Parse(commandArgs[5]);
                            
                            Console.WriteLine(centre.RegisterAnimal(type, name, energy, happiness, procedureTime));
                            break;

                        case "Chip":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);

                            Console.WriteLine(centre.Chip(name, procedureTime));
                            break;

                        case "Vaccinate":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);

                            Console.WriteLine(centre.Vaccinate(name, procedureTime));
                            break;

                        case "Fitness":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);
                            
                            Console.WriteLine(centre.Fitness(name, procedureTime));
                            break;

                        case "Play":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);

                            Console.WriteLine(centre.Play(name, procedureTime));
                            break;

                        case "DentalCare":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);

                            Console.WriteLine(centre.DentalCare(name, procedureTime));
                            break;

                        case "NailTrim":
                            name = commandArgs[1];
                            procedureTime = int.Parse(commandArgs[2]);

                            Console.WriteLine(centre.NailTrim(name, procedureTime));
                            break;

                        case "Adopt":
                            name = commandArgs[1];
                            string owner = commandArgs[2];

                            Console.WriteLine(centre.Adopt(name, owner));
                            break;

                        case "History":
                            string procedureType = commandArgs[1];

                            Console.WriteLine(centre.History(procedureType));
                            break;
                    }

                    
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (InvalidOperationException oException)
                {
                    Console.WriteLine(oException.Message);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(centre.GetOwnersInformation());
            
        }
    }
}
