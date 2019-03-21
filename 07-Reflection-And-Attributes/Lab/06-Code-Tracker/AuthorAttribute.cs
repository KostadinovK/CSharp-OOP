using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class AuthorAttribute : Attribute
{
    public string Name { get; set; }

    public AuthorAttribute(string name)
    {
        this.Name = name;
    }
}
