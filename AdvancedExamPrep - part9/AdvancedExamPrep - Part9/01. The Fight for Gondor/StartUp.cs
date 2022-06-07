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

            Queue<int> aragonsDefensePlates = new Queue<int>(platesInput);

            int wavesCounter = 0;

            for (int i = 0; i < orcsWavesNumber; i++)
            {
                if (wavesCounter == 3)
                {
                    int additionalPlate = int.Parse(Console.ReadLine());
                    aragonsDefensePlates.Enqueue(additionalPlate);
                    wavesCounter = 0;
                }

                int[] orcsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Stack<int> orcs = new Stack<int>(orcsInput);

                while (true)
                {
                    var currentPlate = aragonsDefensePlates.Peek();
                    var currentOrc = orcs.Peek();



                }

                
                wavesCounter++;
            }
        }
    }
}
