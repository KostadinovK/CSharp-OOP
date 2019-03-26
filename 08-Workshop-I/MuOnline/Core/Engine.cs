using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MuOnline.Core
{
    using System;

    using Contracts;

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var commandInterpreter = serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                try
                {
                    string[] commandInfo = Console.ReadLine().Split().ToArray();

                    string result = commandInterpreter.Read(commandInfo);
                    Console.WriteLine(result);
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
    }
}
