using System;
using System.Collections.Generic;
using System.Text;

namespace _07.RawData
{
    public class Car
    {
        public string Model { get; set; }
        public Engine EngineData { get; set; }
        public Cargo CargoData { get; set; }
        public List<Tire> Tires { get; set; }

        public Car (string model, Engine engineData, Cargo cargoData, List<Tire> tires)
        {
            Model = model;
            EngineData = engineData;
            CargoData = cargoData;
            Tires = tires;
        }
    }
}
