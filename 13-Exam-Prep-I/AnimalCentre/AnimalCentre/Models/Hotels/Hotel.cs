﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IAnimal> animals;

        public IReadOnlyDictionary<string, IAnimal> Animals => animals.ToImmutableDictionary();

        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
        }

        public void Accommodate(IAnimal animal)
        {
            if (animals.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException("Animal {animal name} already exist");
            }

            animals.Add(animal.Name, animal);
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            animals.Remove(animalName);
        }
    }
}
