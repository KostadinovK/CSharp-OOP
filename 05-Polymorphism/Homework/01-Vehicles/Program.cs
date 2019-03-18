using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] carInfo = Console.ReadLine().Split().ToArray();
        string[] truckInfo = Console.ReadLine().Split().ToArray();

        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] commandArgs = Console.ReadLine().Split().ToArray();

            string command = commandArgs[0];
            string vehicle = commandArgs[1];
            double number = double.Parse(commandArgs[2]);

            if (command == "Drive")
            {
                if (vehicle == "Car")
                {
                    Console.WriteLine(car.Drive(number));
                }else if (vehicle == "Truck")
                {
                    Console.WriteLine(truck.Drive(number));
                }
            }else if (command == "Refuel")
            {
                if (vehicle == "Car")
                {
                    car.Refuel(number);
                }
                else if (vehicle == "Truck")
                {
                    truck.Refuel(number);
                }
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}
