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

            while (true)
            {
                var currentLock = locks.Peek();
                var currentBullet = bullets.Dequeue();

                if (currentLock < currentBullet)
                {
                    Console.WriteLine("Ping!");
                    currentBarrel--;
                }
                else
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    currentBarrel--;
                }

                if (currentBarrel == 0)
                {
                    currentBarrel = gunBarrelSize;
                    int totalBulletsCost = currentBarrel * priceForSingleBullet;
                    InteligencePrice -= totalBulletsCost;
                    if (bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                    }
                }

                if (locks.Count == 0)
                {
                    int bulletsLeft = bullets.Count;
                    Console.WriteLine($"{bulletsLeft} bullets left. Earned ${InteligencePrice}");
                    Environment.Exit(0);
                }
                
                if (bullets.Count == 0)
                {
                    break;
                }
            }

            int locksLeft = locks.Count;

            Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
        }
    }
}
