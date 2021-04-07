using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1Km = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1Km);
                cars.Add(model, car);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = cmdArg[1];
                double amountOfKm = double.Parse(cmdArg[2]);
                if (!cars[model].Drive(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

                command = Console.ReadLine();
            }
            foreach (var item in cars)
            {
                Console.WriteLine($"{item.Value.Model} {item.Value.FuelAmount:F2} {item.Value.TravelledDistance}");
            }
        }
    }
}
