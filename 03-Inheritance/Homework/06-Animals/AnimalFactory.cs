using System;
using System.Collections.Generic;
using System.Text;

public static class AnimalFactory
{
    public static Animal Get(string type, string[] animalInfo)
    {
        switch (type)
        {
            case "Dog":
                return new Dog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Frog":
                return new Frog(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Cat":
                return new Cat(animalInfo[0], int.Parse(animalInfo[1]), animalInfo[2]);
            case "Kitten":
                return new Kitten(animalInfo[0], int.Parse(animalInfo[1]));
            case "Tomcat":
                return new Tomcat(animalInfo[0], int.Parse(animalInfo[1]));
        }

        throw new ArgumentException("Invalid input!");
    }
}

