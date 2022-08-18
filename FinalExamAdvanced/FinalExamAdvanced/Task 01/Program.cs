using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Sink = 40;
            const int Oven = 50;
            const int _Countertop = 60;
            const int Wall = 70;


            SortedDictionary<string,int> locations = new SortedDictionary<string, int>
            {
                {"Countertop",0 },
                {"Floor",0 },
                {"Oven",0 },
                {"Sink",0 },
                {"Wall",0 },
            };


            int[] whiteTilesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> whiteTiles = new Stack<int>(whiteTilesInput);

            int[] greyTilesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> greyTiles = new Queue<int>(greyTilesInput);

            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
             
                var currentGreyTile = greyTiles.Peek();
                var currentWhiteTile = whiteTiles.Peek();

                if (currentGreyTile == currentWhiteTile)
                {
                    int newFormedArea = currentGreyTile + currentWhiteTile;

                    if (newFormedArea == Sink)
                    {
                        locations["Sink"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (newFormedArea == Oven)
                    {
                        locations["Oven"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (newFormedArea == _Countertop)
                    {
                        locations["Countertop"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (newFormedArea == Wall)
                    {
                        locations["Wall"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else if (currentGreyTile == currentWhiteTile)
                    {
                        locations["Floor"]++;
                        greyTiles.Dequeue();
                        whiteTiles.Pop();
                    }
                    else 
                    {
                      

                    }
                }
                else
                {
                    var decreasedWhiteTile = whiteTiles.Pop() / 2;
                    whiteTiles.Push(decreasedWhiteTile);
                    var currentTile = greyTiles.Dequeue();
                    greyTiles.Enqueue(currentTile);

                }
                

            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {

                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles.ToList())}");
            }


            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {

                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles.ToList())}");
            }

            foreach (var area in locations.OrderByDescending(x => x.Value))
            {
                if (area.Value == 0)
                {
                    continue;
                }
                Console.WriteLine($"{area.Key}: {area.Value}");
            }
        }
    }
}
