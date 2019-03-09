using System;
using System.Collections.Generic;
using System.Text;

public class Cram : Food
{
    public override int HappinessPoints {
        get => 2;
        protected set { }
    }
}
