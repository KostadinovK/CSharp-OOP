using System;
using AnimalCentre.Core;
using AnimalCentre.Core.Contracts;
using AnimalCentre.Factories;
using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hotel hotel = new Hotel();
            IAnimalFactory factory = new AnimalFactory();
            ICommandInterpreter interpreter = new CommandInterpreter();

            IAnimalCentre centre = new Models.AnimalCentre(hotel, factory);
            IEngine engine = new Engine(centre, interpreter);

            engine.Run();
        }
    }
}
