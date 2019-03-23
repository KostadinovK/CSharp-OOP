using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        string[] lightsColors = Console.ReadLine().Split().ToArray();
        int lightTimes = int.Parse(Console.ReadLine());

        List<TrafficLight> lights = new List<TrafficLight>();

        for (int i = 0; i < lightsColors.Length; i++)
        {
            TrafficLight light = (TrafficLight)Activator.CreateInstance(typeof(TrafficLight), new object[]{lightsColors[i]});
            lights.Add(light);
        }

        for (int i = 0; i < lightTimes; i++)
        {
            foreach (var light in lights)
            {
                var method = light.GetType().GetMethod("LightNextColor");

                method.Invoke(light, null);
            }

            Console.WriteLine(string.Join(" ", lights));
        }
        
    }
}
