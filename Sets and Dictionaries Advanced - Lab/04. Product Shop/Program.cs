using System;
using System.Collections.Generic;

namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            SortedDictionary<string,List<string>> shopDict = new SortedDictionary<string,List<string>>();

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] splitedCommand = command.Split(", ",StringSplitOptions.RemoveEmptyEntries);

                string shopName = splitedCommand[0];
                string product = splitedCommand[1];
                double price = double.Parse(splitedCommand[2]);

                if (!shopDict.ContainsKey(shopName))
                {
                    shopDict.Add(shopName, new List<string>());
                    shopDict[shopName].Add(product);
                    shopDict[shopName].Add(price.ToString());
                }
                else
                {
                    if (shopDict[shopName][0] == product)
                    {
                        shopDict[shopName].Add(price.ToString());
                    }
                    else
                    {

                    }
                }



            }
        }
    }
}
