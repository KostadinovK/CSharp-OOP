using System;
using System.Collections.Generic;
using System.Linq;

public class Pet : INameable, IBirthable
{
    public string Name { get; }
    public string Birthdate { get; }
    public int Birthyear => int.Parse(Birthdate.Split('/').Skip(2).ToArray()[0]);

    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
}
