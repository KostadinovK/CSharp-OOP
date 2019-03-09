using System;
using System.Collections.Generic;
using System.Text;

public class HoneyCake : Food
{
    public override int HappinessPoints {
        get => 5;
        protected set { }
    }
}
