using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get => facultyNumber;
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.ToCharArray().All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string number) : base(firstName, lastName)
    {
        FacultyNumber = number;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine($"Faculty number: {FacultyNumber}");

        return sb.ToString();
    }
}

