using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;

        protected IRepository Repository {
            get => repository;
            set { repository = value; }
        }

        public ReportCommand(string[] data, IRepository repository) : base(data)
        {
            Repository = repository;
        }

        public override string Execute()
        {
            string output = Repository.Statistics;
            return output;
        }
    }
}
