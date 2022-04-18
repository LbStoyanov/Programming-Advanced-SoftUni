﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box<int> box = new Box<int>();

            List<int> list = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.Add(input);
            }

            int[] indexes = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            box.SwapElements(list, firstIndex, secondIndex);
            Console.WriteLine(box);
        }
    }
}
