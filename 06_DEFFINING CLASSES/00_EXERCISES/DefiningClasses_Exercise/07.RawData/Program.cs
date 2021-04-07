using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tirePressure1 = double.Parse(input[5]);
                int tireAge1 = int.Parse(input[6]);
                double tirePressure2 = double.Parse(input[7]);
                int tireAge2 = int.Parse(input[8]);
                double tirePressure3 = double.Parse(input[9]);
                int tireAge3 = int.Parse(input[10]);
                double tirePressure4 = double.Parse(input[11]);
                int tireAge4 = int.Parse(input[12]);

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                List<Tire> tires = new List<Tire>()
                {
                    new Tire(tirePressure1, tireAge1),
                    new Tire(tirePressure2, tireAge2),
                    new Tire(tirePressure3, tireAge3),
                    new Tire(tirePressure4, tireAge4)
                };

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }
            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(c => c.CargoData.Type == "fragile").Where(c => c.Tires.Any(t => t.Pressure < 1.0)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (Car car in cars.Where(c => c.CargoData.Type == "flamable").Where(c => c.EngineData.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
