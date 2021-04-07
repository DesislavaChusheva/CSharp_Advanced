using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale = new EqualityScale<int>(5, 5);
            Console.WriteLine(scale.AreEqual());

            EqualityScale<int> scaleTwo = new EqualityScale<int>(5, 6);
            Console.WriteLine(scaleTwo.AreEqual());
        }
    }
}
