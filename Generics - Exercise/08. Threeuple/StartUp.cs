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
            string town = personInfoArr[3];

            CustomTuple<string, string, string> personInfo = new CustomTuple<string, string, string>(personName, personAddres, town);

            string[] beerArr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = beerArr[0];
            int litters = int.Parse(beerArr[1]);
            string condition = beerArr[2];
            bool result = false;
            if (condition == "drunk")
            {
                result = true;
            }

            CustomTuple<string, int, bool> beerInfo = new CustomTuple<string, int, bool>(name, litters, result);

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string personsName = numbers[0];
            double balance = double.Parse(numbers[1]);
            string bankName = numbers[2];


            CustomTuple<string, double, string> doubleInfo = new CustomTuple<string, double, string>(personsName, balance, bankName);

            Console.WriteLine(personInfo);

            Console.WriteLine(beerInfo);

            Console.WriteLine(doubleInfo);


        }
    }
}
