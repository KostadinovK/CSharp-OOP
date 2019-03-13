using System;
using System.Collections.Generic;
using System.Text;

public class Spy : Soldier, ISpy
{
    public int CodeNumber { get; set; }

    public Spy(int id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
    {
        CodeNumber = codeNumber;
    }

    public override string ToString()
    {
        return $"Name: {FirstName} {LastName} Id: {Id}\nCode Number: {CodeNumber}";
    }
}
