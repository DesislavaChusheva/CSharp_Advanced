using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "P");
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
