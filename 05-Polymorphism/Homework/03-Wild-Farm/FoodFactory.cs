using System;
using System.Collections.Generic;
using System.Text;

public static class FoodFactory
{
    public static Food GetFood(string type, int quantity)
    {
        switch (type)
        {
            case "Vegetable":
                return new Vegetable(quantity);
            case "Fruit":
                return new Fruit(quantity);
            case "Meat":
                return new Meat(quantity);

        }

        return new Seeds(quantity);
    }
}
