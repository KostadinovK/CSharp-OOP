using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongSecondsException : InvalidSongLengthException
{
    public override string Message {
        get => "Song seconds should be between 0 and 59.";
    }
}
