using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class)]

public class AuthorAttribute : Attribute
{
    public string Author { get; private set; }
    public int Revision { get; private set; }
    public string Description { get; private set; }
    public List<string> Reviewers { get; private set; }

    public AuthorAttribute(string author, int revision, string description, params string[] reviewers)
    {
        Author = author;
        Revision = revision;
        Description = description;
        Reviewers = new List<string>(reviewers);
    }
}
