using System;
using System.Collections.Generic;
using System.Text;


public class Citizen : IResident, IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Country { get; set; }

    public Citizen(string name, string country, int age)
    {
        Name = name;
        Country = country;
        Age = age;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {Name}";
    }
    string IPerson.GetName()
    {
        return Name;
    }
}
