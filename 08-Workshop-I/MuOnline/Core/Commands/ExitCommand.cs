using System;
using System.Collections.Generic;
using System.Text;
using MuOnline.Core.Commands.Contracts;

namespace MuOnline.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public ExitCommand()
        {

        }

        public string Execute(string[] inputArgs)
        {
            Environment.Exit(0);
            return null;
        }
    }
}
