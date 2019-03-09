using System;
using System.Collections.Generic;
using System.Text;

public class Song
{
    private string artistName;
    private string name;
    private int minutes;
    private int seconds;

    public string ArtistName {
        get => artistName;
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            artistName = value;
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            name = value;
        }
    }

    public int Minutes
    {
        get => minutes;
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            minutes = value;
        }
    }

    public int Seconds
    {
        get => seconds;
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            seconds = value;
        }
    }

    public Song(string artistName, string name, int minutes, int seconds)
    {
        ArtistName = artistName;
        Name = name;
        Minutes = minutes;
        Seconds = seconds;
    }
}
