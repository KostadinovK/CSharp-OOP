using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animalType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            var instance = (IAnimal)Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);

            return instance;
        }
    }
}
