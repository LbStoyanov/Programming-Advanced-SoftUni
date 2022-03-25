using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceForSingleBullet = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            var bulletsCount = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int[] locksCount = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int InteligencePrice = int.Parse(Console.ReadLine());
            bulletsCount.Reverse();

            Queue<int> locks = new Queue<int>(locksCount);
            Queue<int> bullets = new Queue<int>(bulletsCount);

            int currentBarrel = gunBarrelSize;
            int bulletCounts = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                var currentLock = locks.Peek();
                var currentBullet = bullets.Dequeue();
                currentBarrel--;
                bulletCounts++;

                if (currentLock < currentBullet)
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }

                if (currentBarrel == 0 && bullets.Count > 0)
                {
                    currentBarrel = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            

            if (locks.Count > 0)
            {
                int locksLeft = locks.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
            else
            {
                int moneyEarned = InteligencePrice - (bulletCounts * priceForSingleBullet);
                int bulletsLeft = bullets.Count;
                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
