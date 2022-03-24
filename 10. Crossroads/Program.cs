using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationOfTheGreenlight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            Queue<string> carsQueue = new Queue<string>();
            int carsPassedTheCrossRoad = 0;

            while (command != "END")
            {
                if (command == "green")
                {

                    int currentDurationOfGreen = durationOfTheGreenlight;

                    while (currentDurationOfGreen > 0)
                    {
                        
                        if (carsQueue.Count == 0)
                        {
                            break;
                        }

                        var currentCar = carsQueue.Peek();

                        if (currentDurationOfGreen - currentCar.Length > 0)
                        {
                            carsQueue.Dequeue();
                            currentDurationOfGreen -= currentCar.Length;
                            carsPassedTheCrossRoad++;
                        }
                        else
                        {

                            int carLenght = currentCar.Length - currentDurationOfGreen;

                            if (freeWindow < carLenght)
                            {
                                int count = carLenght - freeWindow;

                                int index = currentCar.Length - count;

                                char crash = currentCar.ElementAt(index);

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{currentCar} was hit at {crash}.");
                                return;
                            }
                            else
                            {
                                carsQueue.Dequeue();
                                carsPassedTheCrossRoad++;
                                break;
                                
                            }

                        }
                        
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedTheCrossRoad} total cars passed the crossroads.");
        }
    }
}
