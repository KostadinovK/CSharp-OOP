using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;

    public string Name {
        get => name;
        private set {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            name = value;
        }
    }

    private int endurance;

    public int Endurance {
        get => endurance;
        private set {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Endurance should be between 0 and 100.");
            }

            endurance = value;
        }
    }

    private int sprint;

    public int Sprint {
        get => sprint;
        private set {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Sprint should be between 0 and 100.");
            }

            sprint = value;
        }
    }

    private int dribble;

    public int Dribble {
        get => dribble;
        private set {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Dribble should be between 0 and 100.");
            }

            dribble = value;
        }
    }


    private int passing;

    public int Passing {
        get => passing;
        private set {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Passing should be between 0 and 100.");
            }

            passing = value;
        }
    }

    private int shooting;

    public int Shooting {
        get => shooting;
        private set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentException("Shooting should be between 0 and 100.");
            }

            shooting = value;
        }
    }

    public int OverallSkill => GetOverallSkill();

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    private int GetOverallSkill()
    {
        return (int)Math.Round((Dribble + Endurance + Passing + Shooting + Sprint) / 5.0);
    }
}
