using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Tire[]> allTires = new List<Tire[]>();

            while (command != "No more tires")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[]
            {
                new Tire(int.Parse(cmdArg[0]), double.Parse(cmdArg[1])),
                new Tire(int.Parse(cmdArg[2]), double.Parse(cmdArg[3])),
                new Tire(int.Parse(cmdArg[4]), double.Parse(cmdArg[5])),
                new Tire(int.Parse(cmdArg[6]), double.Parse(cmdArg[7])),
            };
                allTires.Add(tires);

                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();
            command = Console.ReadLine();
            while (command != "Engines done")
            {
                string[] cmdArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(cmdArg[0]);
                double cubicCapacity = double.Parse(cmdArg[1]);

                engines.Add(new Engine(horsePower, cubicCapacity));

                command = Console.ReadLine();
            }

            List<Car> specialCars = new List<Car>();
            command = Console.ReadLine();
            while (command != "Show special")
            {
                string[] car = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = car[0];
                string model = car[1];
                int year = int.Parse(car[2]);
                double fuelQuantity = double.Parse(car[3]);
                double fuelConsumption = double.Parse(car[4]);
                int engineIndex = int.Parse(car[5]);
                int tiresIndex = int.Parse(car[6]);
                double fuelLeft = fuelQuantity - 0.2 * fuelConsumption;

                if (year >= 2017 
                    && engines[engineIndex].HorsePower > 330 
                    && (allTires[tiresIndex].Sum(t => t.Pressure) >= 9 && allTires[tiresIndex].Sum(t => t.Pressure) <= 10)
                    && fuelLeft > 0)
                {
                    specialCars.Add(new Car(make, model, year, fuelLeft, fuelConsumption, engines[engineIndex], allTires[tiresIndex]));
                }

                command = Console.ReadLine();
            }

            foreach (var car in specialCars)
            {
                Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
            }
        }
    }
}
