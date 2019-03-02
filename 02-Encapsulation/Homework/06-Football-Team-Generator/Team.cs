using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;

    public string Name {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    private Dictionary<string, Player> players;

    public int PlayersCount => players.Count;

    public int Rating { get; private set; }

    public Team(string name)
    {
        Name = name;
        players = new Dictionary<string, Player>();
        Rating = 0;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player.Name, player);

        CalculateRating();
    }

    public void RemovePlayer(Player player)
    {
        if (players.ContainsKey(player.Name))
        {
            players.Remove(player.Name);

            CalculateRating();
        }
        
    }


    private void CalculateRating()
    {
        double totalPlayersOverallSkill = 0;
        if (this.players.Count > 0)
        {
            Rating = (int)Math.Round(this.players.Values.Average(p => p.OverallSkill));
        }
        else
        {
            Rating = (int)totalPlayersOverallSkill;
        }

    }

    public bool ContainsPlayer(string name)
    {
        return players.ContainsKey(name);
    }

    public Player GetPlayer(string name)
    {
        if (!ContainsPlayer(name))
        {
            throw new ArgumentException();
        }

        return players[name];
    }

}

