using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Core.Contracts
{
    public interface ICommandInterpreter
    {
        void ExecuteCommand(IAnimalCentre centre, string commandType, string[] commandArgs);
    }
}
