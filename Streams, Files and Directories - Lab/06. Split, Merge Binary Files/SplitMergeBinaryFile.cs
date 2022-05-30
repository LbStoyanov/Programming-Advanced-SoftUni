using System;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string partOneFilePath = "";
            string partTwoFilePath = "";
            string sourceFilePath = "";
            string joinedFilePath = "";

            SplitBinaryFile(sourceFilePath, partOneFilePath, partTwoFilePath);
            MergeBinaryFiles(partOneFilePath, partTwoFilePath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            // TODO: write your code here…
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            // TODO: write your code here…
        }

    }
}
