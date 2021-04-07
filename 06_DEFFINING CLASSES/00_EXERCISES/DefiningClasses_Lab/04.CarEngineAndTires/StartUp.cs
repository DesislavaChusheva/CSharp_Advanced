using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var tires = new Tire[]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.2),
                new Tire(2, 2.4),
                new Tire(2, 2.3),
            };

            var engine = new Engine(560, 63000);

            Car car = new Car("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
            Console.WriteLine(car.WhoAmI());
        }
    }
}
