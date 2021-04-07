﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                int age = int.Parse(input[1]);

                if (age > 30)
                {
                    Person person = new Person(name, age);
                    people.Add(person);
                }
            }
            foreach (Person person in people.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
