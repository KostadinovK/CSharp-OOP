using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MoodFactory
{
    public static Mood CreateMood(List<Food> foods)
    {
        int happiness = foods.Select(x => x.HappinessPoints).Sum();

        if (happiness < -5)
        {
            return new AngryMood();
        }

        if (happiness < 1)
        {
            return new SadMood();
        }

        if (happiness < 16)
        {
            return new HappyMood();
        }

        return new JavaScriptMood();
    }
}

