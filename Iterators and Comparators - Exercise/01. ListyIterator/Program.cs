using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .ToList();

            ListyIterator<string> listyIterator =
                new ListyIterator<string>(elements);

            string command;

            try
            {
                while ((command = Console.ReadLine()) != "END")
                {
                    if (command == "Move")
                    {
                        Console.WriteLine(listyIterator.Move());
                    }

                    if (command == "HasNext")
                    {
                        Console.WriteLine(listyIterator.HasNext());
                    }

                    if (command == "Print")
                    {
                        listyIterator.Print();
                    }

                    if (command == "PrintAll")
                    {
                        foreach (var item in listyIterator)
                        {
                            Console.Write(item + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
