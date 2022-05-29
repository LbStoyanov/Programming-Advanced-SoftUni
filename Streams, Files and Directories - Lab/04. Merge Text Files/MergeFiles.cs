using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            //List<string> firstList = new List<string> { "1", "3", "5" };
            //List<string> secondList = new List<string> { "2", "4", "6","7" };
            //var result = firstList.Concat(secondList);
            //Console.WriteLine(string.Join(", ", result));

            string firstInputFilePath = @"..\..\..\input1.txt";
            string secondInputFilePath = @"..\..\..\input2.txt";
            string outputFilePath = @"..\..\..\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            // TODO: write your code here…

            StreamReader firstInputReader = new StreamReader(firstInputFilePath);

            var firstListResult = new List<string>();

            //StreamReader secondInputReader = new StreamReader(secondInputFilePath);

            using (firstInputReader)
            {
                while (true)
                {
                    string firsLine = firstInputReader.ReadLine();

                    if (firsLine == null)
                    {
                        break;
                    }

                    firstListResult.Add(firsLine);
                }
            }

            StreamReader secondInputReader = new StreamReader(secondInputFilePath);

            var secondListResult = new List<string>();

            using (secondInputReader)
            {
                
                while (true)
                {
                    string secondLine = secondInputReader.ReadLine();

                    if (secondLine == null)
                    {
                        break;
                    }

                    secondListResult.Add(secondLine);
                }
            }

            var result = MergeLists(firstListResult, secondListResult);

            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            using (streamWriter)
            {
                foreach (var item in result)
                {
                    streamWriter.WriteLine(item);
                }
            }
          
        }

        public static List<string> MergeLists(List<string> firstList,List<string> secondList)
        {
            int biggerListCount = firstList.Count;
            if (biggerListCount < secondList.Count)
            {
                biggerListCount = secondList.Count;
            }

            var outputList = new List<string>();

            for (int i = 0; i < biggerListCount; i++)
            {
                if (firstList.Count > i)
                {
                    outputList.Add(firstList[i]);
                }
                if (secondList.Count > i)
                {
                    outputList.Add(secondList[i]);
                }
            }

            return outputList;
        }

    }
}
