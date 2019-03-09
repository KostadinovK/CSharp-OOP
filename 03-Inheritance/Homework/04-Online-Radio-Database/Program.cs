using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        int songsCount = int.Parse(Console.ReadLine());

        List<Song> playlist = new List<Song>();

        for (int i = 0; i < songsCount; i++)
        {
            try
            {

                string[] songInfo = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (songInfo.Length != 3)
                {
                    throw new InvalidSongException();
                }

                string[] duration = songInfo[2].Split(":").ToArray();
                int minutes = 0;
                int seconds = 0;

                if (int.TryParse(duration[0], out minutes) && int.TryParse(duration[1], out seconds))
                {
                    Song song = new Song(songInfo[0], songInfo[1], minutes, seconds);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException();
                }

            }
            catch (InvalidSongException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        Console.WriteLine($"Songs added: {playlist.Count}");


        int totalSeconds = playlist.Select(x => x.Seconds).Sum();
        int totalMinutes = playlist.Select(x => x.Minutes).Sum();
        int totalHours = 0;

        totalMinutes += totalSeconds / 60;
        totalSeconds = totalSeconds % 60;

        totalHours += totalMinutes / 60;
        totalMinutes = totalMinutes % 60;

        Console.WriteLine($"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s");

    }
}
