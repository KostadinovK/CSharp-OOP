using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Dictionary<string, Team> teams = new Dictionary<string, Team>();

        string line = Console.ReadLine();

        while (line != "END")
        {
            string[] commandInfo = line.Split(';',StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (commandInfo[0] == "Add")
            {
                string tname = commandInfo[1];
                string playerName = commandInfo[2];
                int endurance = int.Parse(commandInfo[3]);
                int sprint = int.Parse(commandInfo[4]);
                int dribble = int.Parse(commandInfo[5]);
                int passing = int.Parse(commandInfo[6]);
                int shooting = int.Parse(commandInfo[7]);

                try
                {
                    Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                    if (teams.ContainsKey(tname))
                    {
                        teams[tname].AddPlayer(player);
                    }
                    else
                    {
                        Console.WriteLine($"Team {tname} does not exist.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    
                }

            }else if (commandInfo[0] == "Remove")
            {
                string teamName = commandInfo[1];
                string playerName = commandInfo[2];

                if (teams.ContainsKey(teamName) && teams[teamName].ContainsPlayer(playerName))
                {
                    Player toRemove = teams[teamName].GetPlayer(playerName);

                    teams[teamName].RemovePlayer(toRemove);

                }else if (!teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                }else if (!teams[teamName].ContainsPlayer(playerName))
                {
                    Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                }

            }else if (commandInfo[0] == "Rating")
            {
                string name = commandInfo[1];

                if (teams.ContainsKey(name))
                {
                    Console.WriteLine($"{teams[name].Name} - {teams[name].Rating}");
                }
                else
                {
                    Console.WriteLine($"Team {name} does not exist.");
                }
            }else if (commandInfo[0] == "Team")
            {
                Team t = new Team(commandInfo[1]);
                teams.Add(commandInfo[1], t);
            }

            line = Console.ReadLine();
        }
    }
}
