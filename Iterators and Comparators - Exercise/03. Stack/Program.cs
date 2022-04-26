using System;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string commands;

            while ((commands = Console.ReadLine()) != "END")
            {
                string[] splittedCommands = commands.Split(new string[] {" ",", "},StringSplitOptions.RemoveEmptyEntries);


                if (splittedCommands[0] == "Push")
                {
                    for (int i = 1; i < splittedCommands.Length; i++)
                    {
                        stack.Push(int.Parse(splittedCommands[i]));
                    }
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }
                    stack.Pop();
                }

            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
