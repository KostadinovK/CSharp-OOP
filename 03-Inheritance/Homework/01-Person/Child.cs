using System;
using System.Collections.Generic;
using System.Text;

public class Child : Person
{
    public new int Age
    {
        get => this.age;
        private set
        {
            if (value > 15)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }

            base.Age = value;
        }
    }

    public Child(string name, int age) : base(name, age)
    {
        Age = age;
    }
}

