using System;
using System.Collections.Generic;
using System.Text;

public static class AnimalFactory
{
    public static Animal GetAnimal(string type, string[] args)
    {
        switch (type)
        {
            case "Hen":
                return new Hen(args[0], double.Parse(args[1]),double.Parse(args[2]));
            case "Owl":
                return new Owl(args[0],double.Parse(args[1]), double.Parse(args[2]));
            case "Mouse":
                return new Mouse(args[0],double.Parse(args[1]), args[2]);
            case "Dog":
                return new Dog(args[0], double.Parse(args[1]), args[2]);
            case "Cat":
                return new Cat(args[0], double.Parse(args[1]), args[2], args[3]);
        }

        return new Tiger(args[0], double.Parse(args[1]), args[2], args[3]);
    }
}
