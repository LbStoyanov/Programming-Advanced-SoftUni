using System;
using System.Collections.Generic;
using System.IO;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"../../../Files/example.png";
            string partOneFilePath = @"../../../Files/part-1.bin";
            string partTwoFilePath = @"../../../Files/part-2.bin";
            string joinedFilePath = @"../../../Files/example-joined.png";

            SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);
           
            MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            // TODO: write your code here…
            using StreamReader streamReader = new StreamReader(sourceFilePath);

            byte[] fileBytes = File.ReadAllBytes(sourceFilePath);

            var firstPart = new List<byte>();
            var secondPart = new List<byte>();

            for (int i = 0; i < fileBytes.Length; i++)
            {
                if (i >= fileBytes.Length/2)
                {
                    firstPart.Add(fileBytes[i]);
                }
                else
                {
                    secondPart.Add(fileBytes[i]);
                }
            }

            using StreamWriter firstFile = new System.IO.StreamWriter(partOneFilePath);

            foreach (var item in firstPart)
            {
                firstFile.Write(item);
            }
            

            using StreamWriter secondFile = new System.IO.StreamWriter(partTwoFilePath);

            foreach (var item in secondPart)
            {
                secondFile.Write(item);
            }

        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            // TODO: write your code here…

            using StreamReader firstStreamReader = new StreamReader(partOneFilePath);

            byte[] fileBytes = File.ReadAllBytes(partOneFilePath);

            using (firstStreamReader)
            {
                StreamWriter firstStreamWriter = new StreamWriter(joinedFilePath);

                foreach (var item in fileBytes)
                {
                    firstStreamWriter.WriteLine(item);
                }

                firstStreamWriter.Close();
            } 

            

            using StreamReader secondStreamReader = new StreamReader(partTwoFilePath);

            byte[] fileBytes2 = File.ReadAllBytes(partTwoFilePath);

            using StreamWriter secondStreamWriter = new StreamWriter(joinedFilePath);

            foreach (var item in fileBytes2)
            {
                secondStreamWriter.WriteLine(item);
            }
        }

    }
}
