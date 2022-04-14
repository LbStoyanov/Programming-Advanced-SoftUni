using System;

namespace ImplementingStackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Swap(1,2);

            customList.Swap(-2,3);


            Console.WriteLine(customList[0]);

            for (int i = 0; i < customList.Count; i++)
            {
                Console.Write(customList[i] + ", ");
            }
            //Console.WriteLine(String.Join(", ",customList));
            //customList.RemoveAt(1);
        }
    }
}
