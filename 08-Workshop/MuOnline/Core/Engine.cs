using System.Linq;

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
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            while (true)
            {
                string[] commandInfo = Console.ReadLine().Split().ToArray();

                string result = commandInterpreter.Read(commandInfo);
                Console.WriteLine(result);
            }
        }
    }
}
