using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal : ISoundProducable
{
    protected string name;
    protected int age;
    protected string gender;

    public string Name
    {
        get => name;
        protected set
        {
            if (string.IsNullOrEmpty(value))
            {
               throw new ArgumentException("Invalid input!");
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
                throw new ArgumentException("Invalid input!");
            }

            age = value;
        }
    }
    public string Gender
    {
        get => gender;
        protected set
        {
            if (value != "Male" && value != "Female")
            {
                throw new ArgumentException("Invalid input!");
            }

            gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(GetType().ToString());
        sb.AppendLine($"{Name} {Age} {Gender}");
        sb.Append($"{ProduceSound()}");

        return sb.ToString();
    }

    public virtual string ProduceSound()
    {
        return "";
    }
}
