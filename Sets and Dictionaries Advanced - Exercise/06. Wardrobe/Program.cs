using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            AddRobes(wardrobe, numberOfLines);


            string[] searchCloth = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

            string searchedColor = searchCloth[0];
            string searchedCloth = searchCloth[1];
            PrintRezult(wardrobe, searchedColor, searchedCloth);
        }
        static Dictionary<string, Dictionary<string, int>> AddRobes(Dictionary<string, Dictionary<string, int>> wardrobe, int lines)
        {

            for (int i = 0; i < lines; i++)
            {
                string[] input
                    = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string currentColor = input[0];
                string[] clothes = input[1].Split(',');

                if (!wardrobe.ContainsKey(currentColor))
                {
                    wardrobe.Add(currentColor, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobe[currentColor].ContainsKey(cloth))
                    {
                        wardrobe[currentColor].Add(cloth, 0);
                    }

                    wardrobe[currentColor][cloth]++;
                }
            }

            return wardrobe;
        }
        static void PrintRezult(Dictionary<string, Dictionary<string, int>> wardrobe, string searchedColor, string searchedCloth)
        {
            foreach (var color in wardrobe)
            {
                string currentColor = color.Key;

                var currentClothes = color.Value;

                Console.WriteLine($"{currentColor} clothes:");

                foreach (var cloth in currentClothes)
                {
                    if (currentColor == searchedColor && cloth.Key == searchedCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
        
    }
}
