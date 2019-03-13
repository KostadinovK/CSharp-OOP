using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Citizen : IIdentifiable, IBirthable, INameable
{
    public string Id { get; }
    public string Name { get; }
    public int Age { get; }
    public string Birthdate { get; }

    public int Birthyear => int.Parse(Birthdate.Split('/').Skip(2).ToArray()[0]);

    public Citizen(string name, int age, string id, string birthdate)
    {
        Name = name;
        Age = age;
        Id = id;
        Birthdate = birthdate;
    }
}
