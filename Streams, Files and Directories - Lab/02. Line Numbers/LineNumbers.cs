using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputFilePath, outputFilePath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            // TODO: write your code here…

            StreamReader streamReader = new StreamReader(inputFilePath);

            using (streamReader)
            {
                StreamWriter writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    int lineNum = 1;

                    while (true)
                    {
                        string line = streamReader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        writer.WriteLine($"{lineNum}. {line}");
                        lineNum++;
                    }

                }
            }

            

        }
    }

}
