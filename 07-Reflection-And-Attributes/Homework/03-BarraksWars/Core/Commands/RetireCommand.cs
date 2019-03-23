using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private IRepository repository;
        
        protected IRepository Repository {
            get => repository;
            set { repository = value; }
        }

        public RetireCommand(string[] data, IRepository repository) : base(data)
        {
            Repository = repository;
        }

        public override string Execute()
        {
            try
            {
                Repository.RemoveUnit(Data[1]);
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }

            return $"{Data[1]} retired!";
        }
    }
}
