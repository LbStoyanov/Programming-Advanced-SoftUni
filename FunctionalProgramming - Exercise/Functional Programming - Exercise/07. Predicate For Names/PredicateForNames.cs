using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    internal class PredicateForNames
    {
        static void Main(string[] args)
        {
            int wordLenght = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split().ToList();

            Predicate<string> predicate = word => word.Length <= wordLenght;

            Func<List<string>,List<string>> modifiedNames = list => list.FindAll(predicate);

            modifiedNames(names).ForEach(x => Console.WriteLine(x));
            

            //Console.WriteLine(string.Join(Environment.NewLine,names));
        }
    }
}
