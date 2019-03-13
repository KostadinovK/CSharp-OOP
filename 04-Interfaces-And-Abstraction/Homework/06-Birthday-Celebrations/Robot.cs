using System;
using System.Collections.Generic;
using System.Text;

public class Robot : IIdentifiable
{
    public string Id { get; }
    public string Model { get; }

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }
}
