using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FamilyTree
{
    public class Person
    {
        public string Name { get; set; }
        public string Birthdate { get; set; }

        public List<Person> Parents { get; set; }

        public List<Person> Children { get; set; }

        public Person(string str)
        {
            Parents = new List<Person>();
            Children = new List<Person>();

            if (Char.IsDigit(str[0]))
            {
                Birthdate = str;
                Name = "";
            }
            else
            {
                Name = str;
                Birthdate = "";
            }
        }

        public Person(string name, string birthdate) : this(name)
        {
            Birthdate = birthdate;
        }

        public void AddChildren(Person child)
        {
            Children.Add(child);
        }

        public void AddParent(Person parent)
        {
            Parents.Add(parent);
        }

        public void Concatenate(Person other)
        {
            if (other.Name != "")
            {
                this.Name = other.Name;
            }

            if (other.Birthdate != "")
            {
                this.Birthdate = other.Birthdate;
            }


            if (other.Children.Count != 0)
            {
                foreach (var child in other.Children)
                {
                    this.Children.Add(child);
                }
            }

            if (other.Parents.Count != 0)
            {
                foreach (var parent in other.Parents)
                {
                    this.Parents.Add(parent);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name + " " + Birthdate);
            sb.AppendLine("Parents:");
            if (Parents.Count != 0)
            {
                foreach (var parent in Parents)
                {
                    sb.AppendLine(parent.Name + " " + parent.Birthdate);
                }
            }

            sb.AppendLine("Children:");
            if (Children.Count != 0)
            {
                foreach (var child in Children)
                {
                    sb.AppendLine(child.Name + " " + child.Birthdate);
                }
            }

            return sb.ToString();
        }
    }

}