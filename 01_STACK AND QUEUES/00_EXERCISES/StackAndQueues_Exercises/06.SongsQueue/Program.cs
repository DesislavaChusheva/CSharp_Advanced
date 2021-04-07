using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(input);

            bool flag = true;

            while (flag)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {
                    case "Play":
                        if (songs.Any())
                        {
                            songs.Dequeue();
                        }
                        if (!songs.Any())
                        {
                            Console.WriteLine("No more songs!");
                            flag = false;
                        }
                        break;
                    case "Add":
                        string commandSong = string.Join(' ', command);
                        commandSong = commandSong.Substring(4, commandSong.Length - 4);
                        if (songs.Contains(commandSong))
                        {
                            Console.WriteLine($"{commandSong} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(commandSong);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
