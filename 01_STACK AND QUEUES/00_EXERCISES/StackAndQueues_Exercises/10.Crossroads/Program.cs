using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine()); //yellow

            Queue<string> cars = new Queue<string>();
            bool crash = false;
            char crachedChar = ' ';
            int carPassed = 0;
            string carOnCrossroadLeft = string.Empty;
            string carOnCrossroad = string.Empty;

            string command = "";
            while ((command = Console.ReadLine()) != "END")
            {

                while (command != "green")
                {
                    cars.Enqueue(command);
                    command = Console.ReadLine();
                }

                int timeLeft = greenDuration;

                while (timeLeft > 0 && cars.Count > 0)
                {
                    carPassed++;
                    string currCar = cars.Dequeue();
                    if (currCar.Length <= timeLeft)
                    {
                        timeLeft -= currCar.Length;
                    }
                    else
                    {
                        carOnCrossroad = currCar;
                        for (int i = timeLeft; i > 0; i--)
                        {
                            timeLeft--;
                            carOnCrossroadLeft = currCar.Remove(0, 1);
                        }
                    }
                }

                if (carOnCrossroadLeft.Length <= freeWindowDuration)
                {
                    continue;
                }
                else
                {
                    crachedChar = carOnCrossroadLeft[carOnCrossroadLeft.Length - freeWindowDuration + 1];
                    crash = true;
                    break;
                }

            }
            if (crash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{carOnCrossroad} was hit at {crachedChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carPassed} total cars passed the crossroads.");
            }
        }
    }
}
