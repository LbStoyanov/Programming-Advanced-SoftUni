﻿using System;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            SortedDictionary<string,Dictionary<string,double>> shopDict = new SortedDictionary<string,Dictionary<string,double>>();

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] splitedCommand = command.Split(", ",StringSplitOptions.RemoveEmptyEntries);

                string shopName = splitedCommand[0];
                string product = splitedCommand[1];
                double price = double.Parse(splitedCommand[2]);

                if (!shopDict.ContainsKey(shopName))
                {
                    shopDict.Add(shopName, new Dictionary<string, double> { { product, price }});
                }
                else
                {
                    if (!shopDict[shopName].ContainsKey(product))
                    {
                        shopDict[shopName].Add(product, price);
                    }
                }

            }

            foreach (var shop in shopDict)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shopDict[shop.Key])
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
