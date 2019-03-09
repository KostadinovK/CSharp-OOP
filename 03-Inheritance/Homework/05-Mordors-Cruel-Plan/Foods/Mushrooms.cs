using System;
using System.Collections.Generic;
using System.Text;

public class Mushrooms : Food
{
    public override int HappinessPoints {
        get => -10;
        protected set { }
    }
}

