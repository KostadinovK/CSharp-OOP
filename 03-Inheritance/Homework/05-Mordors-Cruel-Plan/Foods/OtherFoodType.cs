using System;
using System.Collections.Generic;
using System.Text;

class OtherFoodType : Food
{
    public override int HappinessPoints {
        get => -1;
        protected set { }
    }
}

