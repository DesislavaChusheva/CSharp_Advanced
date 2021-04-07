using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine()
                                                       .Split(" ")
                                                       .Select(int.Parse)
                                                       .ToArray());
            Stack<int> ingredients = new Stack<int>(Console.ReadLine()
                                                       .Split(" ")
                                                       .Select(int.Parse)
                                                       .ToArray());
            Dictionary<string, int> food = new Dictionary<string, int>();
            food.Add("Bread", 0);
            food.Add("Cake", 0);
            food.Add("Pastry", 0);
            food.Add("Fruit Pie", 0);

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currLiquid = liquids.Dequeue();
                int currIngredient = ingredients.Peek();
                int sum = currLiquid + currIngredient;
                bool foodMade = false;

                if (sum == 25 || sum == 50 || sum == 75 || sum == 100)
                {
                    ingredients.Pop();
                    foodMade = true;
                    switch (sum)
                    {
                        case 25:
                            food["Bread"]++;
                            break;
                        case 50:
                            food["Cake"]++;
                            break;
                        case 75:
                            food["Pastry"]++;
                            break;
                        case 100:
                            food["Fruit Pie"]++;
                            break;

                        default:
                            break;
                    }
                }
                if (!foodMade)
                {
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            if (food.All(f => f.Value >= 1))
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count > 0)
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Count>0)
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var kvp in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
