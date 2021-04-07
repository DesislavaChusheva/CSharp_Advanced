using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                people.Add(name, age);
            }
            string conditionInput = Console.ReadLine();
            int ageInput = int.Parse(Console.ReadLine());
            string formatInput = Console.ReadLine();
            Func<int, bool> tester = TestCondition(conditionInput, ageInput);
            Action<KeyValuePair<string, int>> printer = Printer(formatInput);
            PrintFilteredPeople(people, tester, printer);
        }

        private static void PrintFilteredPeople(Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (tester(person.Value))
                {
                    printer(person);
                }
            }
        }

        public static Func<int, bool> TestCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x < age;
                case "older":
                    return x => x >= age;
                default:
                    return null;
            }
        }
        public static Action<KeyValuePair<string, int>> Printer(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine(person.Key);
                case "age":
                    return person => Console.WriteLine(person.Value);
                case "name age":
                    return person => Console.WriteLine($"{person.Key} - {person.Value}");
                default:
                    return null;
            }
        }
    }
}
