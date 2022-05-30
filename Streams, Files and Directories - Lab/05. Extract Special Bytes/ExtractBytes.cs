using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractBytes
{
    public class ExtractBytes
    {
        static void Main(string[] args)
        {
            string binaryFilePath = @"../../../Files/image.png";
            string bytesFilePath = @"../../../Files/bytesFile.txt";
            string outputPath = @"../../../Files/output.txt";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);

        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            // TODO: write your code here…

            using StreamReader streamReader = new StreamReader(bytesFilePath);
            byte[] fileBytes = File.ReadAllBytes(binaryFilePath);
            var bytesList = new List<String>();
            var sb = new StringBuilder();

            while (!streamReader.EndOfStream)
            {
                bytesList.Add(streamReader.ReadLine());
            }
            foreach (var item in fileBytes)
            {
                if (bytesList.Contains(item.ToString()))
                {
                    sb.AppendLine(item.ToString());
                }

            }
            using StreamWriter file = new System.IO.StreamWriter(outputPath);
            file.WriteLine(sb.ToString().Trim());
        }
    
    }
}
