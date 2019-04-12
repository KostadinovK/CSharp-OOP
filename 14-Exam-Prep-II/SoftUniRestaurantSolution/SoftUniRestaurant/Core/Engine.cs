using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SoftUniRestaurant.Core.Contracts;

namespace SoftUniRestaurant.Core
{
    public class Engine : IEngine
    {
        private IRestaurantController controller;
        
        public Engine(IRestaurantController controller)
        {
            this.controller = controller;
        }
        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "END")
            {
                try
                {
                    string[] commandArgs = line.Split().ToArray();
                    string command = commandArgs[0];

                    switch (command)
                    {
                        case "AddFood":
                            Console.WriteLine(controller.AddFood(commandArgs[1], commandArgs[2], decimal.Parse(commandArgs[3])));
                            break;
                        case "AddDrink":
                            Console.WriteLine(controller.AddDrink(commandArgs[1], commandArgs[2], int.Parse(commandArgs[3]), commandArgs[4]));
                            break;
                        case "AddTable":
                            Console.WriteLine(controller.AddTable(commandArgs[1], int.Parse(commandArgs[2]), int.Parse(commandArgs[3])));
                            break;
                        case "ReserveTable":
                            Console.WriteLine(controller.ReserveTable(int.Parse(commandArgs[1])));
                            break;
                        case "OrderFood":
                            Console.WriteLine(controller.OrderFood(int.Parse(commandArgs[1]), commandArgs[2]));
                            break;
                        case "OrderDrink":
                            Console.WriteLine(controller.OrderDrink(int.Parse(commandArgs[1]), commandArgs[2], commandArgs[3]));
                            break;
                        case "LeaveTable":
                            Console.WriteLine(controller.LeaveTable(int.Parse(commandArgs[1])));
                            break;
                        case "GetFreeTablesInfo":
                            Console.WriteLine(controller.GetFreeTablesInfo());
                            break;
                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(controller.GetOccupiedTablesInfo());
                            break;
                    }
                }
                catch (TargetInvocationException e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(controller.GetSummary());
        }
    }
}
