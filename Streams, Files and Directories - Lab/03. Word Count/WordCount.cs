using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordCount
{
    public class WordCount
    {
        static void Main(string[] args)
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            CalculateWordCounts(wordsFilePath, textFilePath, outputFilePath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader wordReader = new StreamReader(wordsFilePath);

            using (wordReader)
            {
                string[] words = wordReader.ReadLine().Split();
                
                StringBuilder stringBuilder = new StringBuilder();

                

                StreamReader textReader = new StreamReader(textFilePath);

                using (textReader)
                {
                    while (true)
                    {
                        string line = textReader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        stringBuilder.AppendLine(line);
                        
                    }
                }

                string[] wordsInText = stringBuilder.ToString()
                    .Replace("!","")
                    .Replace(".","")
                    .Replace("...","")
                    .Replace("-","")
                    .Replace("?","")
                    .Replace(",","")
                    .Split();

                StreamWriter streamWriter = new StreamWriter(outputFilePath);

                var wordCountDict = new Dictionary<string, int>();

                ExtractWordsCount(words, wordsInText, wordCountDict);

                using (streamWriter)
                {
                    foreach (var item in wordCountDict.OrderByDescending(x => x.Value))
                    {
                        streamWriter.WriteLine($"{item.Key} - {item.Value}");
                    }
                }

            }
        }

        private static void ExtractWordsCount(string[] words, string[] wordsInText, Dictionary<string, int> wordCountDict)
        {
            foreach (var word in words)
            {
                for (int i = 0; i < wordsInText.Length; i++)
                {
                    string currentWord = wordsInText[i].ToLower();

                    if (word == currentWord)
                    {
                        if (!wordCountDict.ContainsKey(word))
                        {
                            wordCountDict.Add(word, 1);
                            continue;
                        }

                        wordCountDict[word]++;
                    }
                }
            }
        }
    }
}
