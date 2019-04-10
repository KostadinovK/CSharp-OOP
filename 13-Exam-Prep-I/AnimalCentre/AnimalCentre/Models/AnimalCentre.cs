using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Factories.Contracts;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Models
{
    public class AnimalCentre : IAnimalCentre
    {
        private Hotel hotel;
        private IAnimalFactory factory;
        private Dictionary<string, IProcedure> procedures;
        private Dictionary<string, List<string>> owners;

        public AnimalCentre(Hotel hotel, IAnimalFactory factory)
        {
            this.hotel = hotel;
            this.factory = factory;

            procedures = new Dictionary<string, IProcedure>
            {
                { "Chip", new Chip() },
                { "DentalCare", new DentalCare() },
                { "Fitness", new Fitness() },
                { "NailTrim", new NailTrim() },
                { "Play", new Play() },
                { "Vaccinate", new Vaccinate() },
            };

            owners = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = factory.CreateAnimal(type, name, energy, happiness, procedureTime);
            hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["Vaccinate"].DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["Fitness"].DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["Play"].DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["DentalCare"].DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal animal = hotel.Animals[name];
            procedures["NailTrim"].DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            
            IAnimal animal = hotel.Animals[animalName];

            hotel.Adopt(animalName, owner);

            if (!owners.ContainsKey(owner))
            {
                owners[owner] = new List<string>();
            }

            owners[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            if (!procedures.ContainsKey(type))
            {
                throw new ArgumentException("Invalid procedure type");
            }

            IProcedure p = procedures[type];

            return p.History();
        }

        public string GetOwnersInformation()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var kvp in owners.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {kvp.Key}");
                sb.AppendLine($"    - Adopted animals: {string.Join(" ", kvp.Value)}");
            }

            return sb.ToString().Trim();
        }
    }
}
