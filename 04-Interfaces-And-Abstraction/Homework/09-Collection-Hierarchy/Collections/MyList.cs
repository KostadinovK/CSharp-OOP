using System;
using System.Collections.Generic;
using System.Text;

public class MyList : List<string>, IAddable, IRemoveable, IUseable
{
    public int Used => Count;
    public int Add(string toAdd)
    {
        int index = Count;

        base.Add(toAdd);

        return index;
    }

    public string Remove()
    {
        string toRemove = base[0];

        base.Remove(toRemove);

        return toRemove;
    }

}
