using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class WarmWinter
    {
        static void Main(string[] args)
        {
            List<int> hatsInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> hats = new Stack<int>(hatsInput);


            List<int> scarfsInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> scarfs = new Queue<int>(scarfsInput);

            List<int> createdSets = new List<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                var currentHat = hats.Peek();
                var currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    int setPrice = currentHat + currentScarf;
                    createdSets.Add(setPrice);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if(currentHat < currentScarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();

                    int incriesedHatValue = hats.Pop() + 1;

                    hats.Push(incriesedHatValue);

                }
            }
            

            int mostExpansiveSet = createdSets.OrderByDescending(x => x).FirstOrDefault();

            Console.WriteLine($"The most expensive set is: {mostExpansiveSet}");

            Console.WriteLine(String.Join(" ",createdSets));
        }
    }
}
