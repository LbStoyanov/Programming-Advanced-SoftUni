using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            int counter = 0;

            while (consonants.Count > 0)
            {
                if (counter == 4)
                {
                    consonants.Pop();
                    counter = 0;
                }

                var currentWord = wordsToBeCreated[counter];
                AddWordInFinalResult(vowels, consonants, currentWord, finalListOfWords);
                
                counter++;

            }


            Console.WriteLine($"Words found: {finalListOfWords.Count}");
            Console.WriteLine(String.Join(Environment.NewLine,finalListOfWords));


        }

        private static void AddWordInFinalResult(Queue<char> vowels, Stack<char> consonants, string currentWord, List<string> finalListOfWords)
        {
            string allChars = ReverseStackAndQueueIntoString(vowels, consonants);
            // e,a,u,o,p,r,l,x,f

            //currentWord - pear 
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < currentWord.Length; i++)
            {
                var currentWordChar = currentWord[i];
                //P
                
                for (int j = 0; j < allChars.Length; j++)
                {
                    var currentChar = allChars[j];

                    if (currentWordChar == currentChar)
                    {
                        sb.Append(currentChar);
                        break;
                    }
                        
                }

                if (sb.ToString() == currentWord && !finalListOfWords.Contains(currentWord))
                {
                    finalListOfWords.Add(sb.ToString());
                    break;
                }

            }

        }
        private static string ReverseStackAndQueueIntoString(Queue<char> vowels, Stack<char> consonants)
        {
            StringBuilder sb = new StringBuilder();

            var helperQueue = new Queue<char>();

            while (vowels.Count > 0)
            {
                var currentChar = vowels.Peek();
                sb.Append(currentChar);
                helperQueue.Enqueue(vowels.Dequeue());
            }

            List<char> list = new List<char>();

            while (consonants.Count > 0)
            {
                var currentChar = consonants.Peek();
                sb.Append(currentChar);
                list.Add(consonants.Pop());
            }

            list.Reverse();

            for (int i = 0; i < list.Count; i++)
            {
                consonants.Push(list[i]);
            }

            while (helperQueue.Count > 0)
            {
                vowels.Enqueue(helperQueue.Dequeue());
            }

            return sb.ToString();
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
