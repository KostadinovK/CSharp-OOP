using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    protected string name;
    protected int age;

    public string Name
    {
        get => name;
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }

            name = value;
        }
    }

    public int Age
    {
        get => age;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }

            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString()
    {
        return $"Name: {name}, Age: {age}";
    }
}

