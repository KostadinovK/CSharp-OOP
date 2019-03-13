using System;
using System.Collections.Generic;
using System.Text;

public abstract class Soldier : ISoldier
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    protected Soldier(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
