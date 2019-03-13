using System;
using System.Collections.Generic;
using System.Text;


public class AddRemoveCollection : List<string>, IAddable, IRemoveable
{
    public int Add(string toAdd)
    {
        int index = Count;

        base.Add(toAdd);

        return index;
    }

    public string Remove()
    {
        string toRemove = base[Count - 1];

        base.Remove(toRemove);

        return toRemove;
    }
}
