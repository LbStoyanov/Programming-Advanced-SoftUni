using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPrint
{
    internal class ActionPrint
    {
        static void Main(string[] args)
        {
            //Action<int> => Its void, use for printing or modification.Its not return value;
            //int number = 5;
            //Action<int> printMultiplyNum = number => Console.WriteLine(number * 2); //=> Define an Action

            //printMultiplyNum(number);

            Action<List<string>> printCollection = names => names.ForEach(x => Console.WriteLine(x));

            string namesInput = Console.ReadLine();

            List<string> names = namesInput.Split().ToList();
            printCollection(names);

            
        }
    }
}
