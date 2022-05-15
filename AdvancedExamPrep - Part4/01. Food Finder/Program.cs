using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> finalListOfWords = new List<string>();

            List<string> wordsToBeCreated = new List<string>
            {
                "pear",
                "flour",
                "pork",
                "olive",
            };

            char[] volewsInput = Console.ReadLine().Replace(" ","").ToCharArray();
            char[] consonantsInput = Console.ReadLine().Replace(" ","").ToCharArray();

            Queue<char> vowels = AddVolewsInQueue(volewsInput);
            Stack<char> consonants = AddConsonantInStack(consonantsInput);

            while (consonants.Count != 0)
            {
                if (AddWordInFinalResult(vowels,consonants,wordsToBeCreated))
                {

                }
            }


        }

        private static bool AddWordInFinalResult(Queue<char> vowels, Stack<char> consonants, List<string> wordsToBeCreated)
        {
            throw new NotImplementedException();
        }

        public static Stack<char> AddConsonantInStack(char[] consonantsInput)
        {
            Stack<char> consonants = new Stack<char>();

            for (int i = consonantsInput.Length - 1; i >= 0; i--)
            {
                var currentChar = consonantsInput[i];
                consonants.Push(currentChar);
            }

            return consonants;
        }
        public static Queue<char> AddVolewsInQueue(char[] volewsInput)
        {
            Queue<char> vowels = new Queue<char>();

            for (int i = 0; i < volewsInput.Length; i++)
            {
                var currentChar = volewsInput[i];
                vowels.Enqueue(currentChar);
            }

            return vowels;
        }
    }
}
