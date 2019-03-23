using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);

            return (IUnit)Activator.CreateInstance(type);
        }
    }
}
