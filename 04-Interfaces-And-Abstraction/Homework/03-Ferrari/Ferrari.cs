using System;
using System.Collections.Generic;
using System.Text;

public class Ferrari : ICar
{
    public string Model => "488-Spider";
    public string Driver { get; set; }

    public Ferrari(string driver)
    {
        Driver = driver;
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGasPedal()
    {
        return "Gas!";
    }

    public override string ToString()
    {
        return $"{Model}/{UseBrakes()}/{PushGasPedal()}/{Driver}";
    }
}
