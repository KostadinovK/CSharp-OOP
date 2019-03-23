using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public abstract class Command : IExecutable
    {
        private string[] data;
        

        protected string[] Data
        {
            get => data;
            set { data = value; }
        }

        protected Command(string[] data)
        {
            Data = data;
        }

        public abstract string Execute();
    }
}
