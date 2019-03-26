using System.Linq;
using System.Reflection;
using MuOnline.Core.Commands.Contracts;
using MuOnline.Core.Contracts;

namespace MuOnline.Core
{
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "command";
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public string Read(string[] args)
        {
            var commandString = args[0] + Suffix;
            var commandParams = args.Skip(1).ToArray();

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandString.ToLower());

            if (commandType == null)
            {
                throw new ArgumentNullException($"Command {args[0]} doesn't exist!");
            }

            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParams = constructor.GetParameters().Select(p => p.ParameterType).ToArray();
            var services = constructorParams.Select(serviceProvider.GetService).ToArray();

            var instance = (ICommand)Activator.CreateInstance(commandType, services);

            return instance.Execute(commandParams);
        }
    }
}
