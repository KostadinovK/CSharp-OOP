using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        protected IRepository Repository {
            get => repository;
            set { repository = value; }
        }

        protected IUnitFactory UnitFactory {
            get => unitFactory;
            set { unitFactory = value; }
        }
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) : base(data)
        {
            Repository = repository;
            UnitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
