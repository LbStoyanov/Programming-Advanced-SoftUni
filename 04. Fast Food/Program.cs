using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < orders.Length; i++)
            {
                var order = orders[i];

                queue.Enqueue(order);
            }

            Console.WriteLine(queue.Max());

            while (queue.Count > 0)
            {
                var currentOrder = queue.Peek();
                if (foodQuantity - currentOrder >= 0)
                {
                    queue.Dequeue();
                    foodQuantity -= currentOrder;
                }
                else
                {
                    break;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                var ordersLeft = new List<int>();
                while (queue.Count > 0)
                {
                    ordersLeft.Add(queue.Dequeue());
                }

                Console.WriteLine($"Orders left: {string.Join(" ",ordersLeft)}");
            }
        }
    }
}
