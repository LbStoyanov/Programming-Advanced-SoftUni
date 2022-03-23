using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inicialSongs = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < inicialSongs.Length; i++)
            {
                queue.Enqueue(inicialSongs[i]);
            }

            string commands = Console.ReadLine();

            while (queue.Count > 0)
            {
                string[] actions = commands.Split(" ").ToArray();
                string mainAction = actions[0];

                if (mainAction == "Play" && queue.Count > 0)
                {
                    queue.Dequeue();
                }
                else if (mainAction == "Add")
                {
                    int startIndex = 4;
                    int endIndex = commands.Length - 1;

                    string newSong = commands.Substring(startIndex,endIndex - startIndex + 1);
                    if (!queue.Contains(newSong))
                    {
                        queue.Enqueue(newSong);
                    }
                    else
                    {
                        
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }
                else
                {
                    var currentSongsList = queue.ToList();
                    Console.WriteLine(String.Join(", ",currentSongsList));
                    
                }

                commands = Console.ReadLine();
            }

            var listOfSongs = queue.ToList();

            if (listOfSongs.Count != 0)
            {
                Console.WriteLine(String.Join(", ", listOfSongs));
                Console.WriteLine("No more songs!");
            }
            else
            {
                Console.WriteLine("No more songs!");
            }

            
        }
    }
}
