using System;
using System.Collections.Generic;
using System.Text;

public class Melon : Food
{
    public override int HappinessPoints {
        get => 1;
        protected set { }
    }
}
