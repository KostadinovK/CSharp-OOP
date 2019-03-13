using System;
using System.Collections.Generic;
using System.Text;


public class AddCollection : List<string>, IAddable
{
    public int Add(string toAdd)
    {
        int index = Count;

        base.Add(toAdd);

        return index;
    }
}

