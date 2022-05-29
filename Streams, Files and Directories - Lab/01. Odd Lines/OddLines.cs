using System;
using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            using (streamReader)
            {

                StreamWriter streamWriter = new StreamWriter(outputFilePath);

                using (streamWriter)
                {
                    int lineNum = 0;

                    while (true)
                    {
                        string line = streamReader.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        if (lineNum % 2 == 1)
                        {
                            streamWriter.WriteLine(line);
                        }
                        lineNum++;
                    }
                }
            }
        }
    }
}
