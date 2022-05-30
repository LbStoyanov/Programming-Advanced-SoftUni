﻿using System;
using System.IO;

namespace FolderSize
{
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"C:\Users\Lyubaka\source\repos";
            string outputFilePath = @"../../../output.txt";

            GetFolderSize(folderPath, outputFilePath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            // TODO: write your code here…

            double sum = 0;

            DirectoryInfo dir = new DirectoryInfo(folderPath);
            FileInfo[] infos = dir.GetFiles("*", SearchOption.AllDirectories);

            foreach (FileInfo fileInfo in infos)
            {
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText(outputFilePath, $"{sum} KB");

        }

    }
}
