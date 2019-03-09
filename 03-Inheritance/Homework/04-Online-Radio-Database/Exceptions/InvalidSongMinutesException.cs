using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongMinutesException : InvalidSongLengthException
{
    public override string Message {
        get => "Song minutes should be between 0 and 14.";
    }
}

