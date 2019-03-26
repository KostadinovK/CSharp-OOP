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
            throw new NotImplementedException();
        }
    }
}
