using System;
using System.Collections.Generic;
using System.Text;

public class Mission : IMission
{
    public string CodeName { get; set; }
    public string State { get; set; }

    public Mission(string codeName, string state)
    {
        CodeName = codeName;
        State = state;
    }

    public override string ToString()
    {
        return $"  Code Name: {CodeName} State: {State}";
    }
}
