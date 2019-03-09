using System;
using System.Collections.Generic;
using System.Text;

public abstract class Mood
{
    public abstract string MoodName { get; protected set; }
    public override string ToString()
    {
        return MoodName;
    }
}
