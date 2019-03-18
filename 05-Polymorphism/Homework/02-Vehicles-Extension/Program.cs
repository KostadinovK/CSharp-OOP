using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
        string[] busInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] commandArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();

            string command = commandArgs[0];
            string vehicle = commandArgs[1];
            double number = double.Parse(commandArgs[2]);

            if (command == "Drive")
            {
                if (vehicle == "Car")
                {
                    Console.WriteLine(car.Drive(number));
                }
                else if (vehicle == "Truck")
                {
                    Console.WriteLine(truck.Drive(number));
                }
                else if (vehicle == "Bus")
                {
                    Console.WriteLine(bus.Drive(number));
                }
            }
            else if (command == "Refuel")
            {
                if (vehicle == "Car")
                {
                    string res = car.Refuel(number);

                    if (res != null)
                    {
                        Console.WriteLine(res);
                    }
                }
                else if (vehicle == "Truck")
                {
                    string res = truck.Refuel(number);
                    truck.FuelQuantity -= number * 0.05;
                    if (res != null)
                    {
                        Console.WriteLine(res);
                    }
                }
                else if (vehicle == "Bus")
                {
                    string res = bus.Refuel(number);

                    if (res != null)
                    {
                        Console.WriteLine(res);
                    }
                }
            }else if (command == "DriveEmpty")
            {
                Console.WriteLine(bus.DriveEmpty(number));
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}
