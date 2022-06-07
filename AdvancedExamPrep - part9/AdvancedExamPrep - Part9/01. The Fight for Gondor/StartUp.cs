using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightforGondor
{
    internal class StartUp
    {
        static void Main(string[] args)
        {

            int orcsWavesNumber = int.Parse(Console.ReadLine());

            int[] platesInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>(platesInput);

            int wavesCounter = 1;

            //bool isPlatesWon = false;
            bool isOrcsWon = false;

            for (int i = 0; i < orcsWavesNumber; i++)
            {
                int[] orcsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (wavesCounter == 3)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(additionalPlate);
                    wavesCounter = 1;
                }

                Stack<int> orcs = new Stack<int>(orcsInput);

                var currentPlate = plates.Peek();
                var currentOrc = orcs.Peek();

                while (true)
                {

                    if (currentOrc > currentPlate)
                    {
                        currentOrc -= currentPlate; // 6 - 5
                        if (currentOrc <= 0)
                        {
                            currentOrc = orcs.Pop();
                        }
                        plates.Dequeue();
                        if (plates.Count == 0)
                        {
                            isOrcsWon = true;
                            orcs.Pop();
                            orcs.Push(currentOrc);
                            break;
                        }
                        currentPlate = plates.Peek();
                    }
                    else if (currentOrc < currentPlate)
                    {
                        currentPlate -= currentOrc;
                        if (currentPlate <= 0)
                        {
                           currentPlate = plates.Dequeue();
                        }
                        orcs.Pop();
                        if (orcs.Count == 0)
                        {
                            plates.Dequeue();
                            plates.Enqueue(currentPlate);
                            break;
                        }

                        currentOrc = orcs.Peek();
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }



                    if (plates.Count == 0)
                    {
                        isOrcsWon = true;
                        break;
                    }

                    if (orcs.Count == 0)
                    {
                        break;
                    }

                }

                if (isOrcsWon)
                {
                    Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                    
                    var orcsList = new List<int>();

                    foreach (var orc in orcs)
                    {
                        orcsList.Add(orc);
                    }

                    Console.WriteLine($"Orcs left: {string.Join(", ",orcsList)}");

                    Environment.Exit(0);
                }

                wavesCounter++;
            }


            Console.WriteLine("The people successfully repulsed the orc's attack.");

            var platesFinalList = new List<int>();

            foreach (var plate in plates)
            {
                platesFinalList.Add(plate);
            }

            Console.WriteLine($"Plates left: {string.Join(", ",platesFinalList)}");
        }
    }
}
