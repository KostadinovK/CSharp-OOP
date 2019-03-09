using System;
using System.Collections.Generic;
using System.Text;

public class InvalidSongException : Exception
{
    public override string Message
    {
        get => "Invalid song.";
    }
}

