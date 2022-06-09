using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] personInfoArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = $"{personInfoArr[0]} {personInfoArr[1]}";
            string personAddres = personInfoArr[2];

            CustomTuple<string, string> personInfo = new CustomTuple<string, string>(personName, personAddres);

            string[] beerArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = beerArr[0];
            int litters = int.Parse(beerArr[1]);

            CustomTuple<string, int> beerInfo = new CustomTuple<string, int>(name, litters);

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int firstNum = int.Parse(numbers[0]);
            double secondNume = double.Parse(numbers[1]);

            CustomTuple<int, double> doubleInfo = new CustomTuple<int, double>(firstNum, secondNume);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(doubleInfo);


        }
    }
}