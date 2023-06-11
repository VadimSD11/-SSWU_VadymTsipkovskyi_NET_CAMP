using System;
using System.Collections.Generic;
using System.IO;

namespace Home_task_11
{
    public class FileMergeSort
    {
        public static void Sort(string filePath)
        {
            int maxMemorySize = 50;
            List<string> tempFiles = new List<string>();
            int pass = 0;

            using (StreamReader reader = new StreamReader(filePath))
            {
                List<int> numbers = new List<int>();
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    numbers.Add(int.Parse(line));

                    if (numbers.Count == maxMemorySize)
                    {
                        numbers.Sort();
                        string tempFilePath = GetTempFilePath(pass);
                        WriteNumbersToFile(numbers, tempFilePath);
                        tempFiles.Add(tempFilePath);
                        numbers.Clear();
                        pass++;
                    }
                }

                if (numbers.Count > 0)
                {
                    numbers.Sort();
                    string tempFilePath = GetTempFilePath(pass);
                    WriteNumbersToFile(numbers, tempFilePath);
                    tempFiles.Add(tempFilePath);
                }
            }

            MergeFiles(tempFiles, filePath);
            foreach (string tempFile in tempFiles)
            {
                File.Delete(tempFile);
            }
        }

        private static void WriteNumbersToFile(List<int> numbers, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }

        private static void MergeFiles(List<string> tempFiles, string outputPath)
        {
            while (tempFiles.Count > 1)
            {
                List<string> mergedFiles = new List<string>();

                for (int i = 0; i < tempFiles.Count; i += 2)
                {
                    if (i + 1 < tempFiles.Count)
                    {
                        string mergedFilePath = GetTempFilePath(i / 2);
                        mergedFiles.Add(mergedFilePath);

                        MergeTwoFiles(tempFiles[i], tempFiles[i + 1], mergedFilePath);
                    }
                    else
                    {
                        mergedFiles.Add(tempFiles[i]);
                    }
                }

                tempFiles = mergedFiles;
            }

            File.Delete(outputPath); 
            File.Copy(tempFiles[0], outputPath); 
            File.Delete(tempFiles[0]); 

        }

        private static void MergeTwoFiles(string filePath1, string filePath2, string outputPath)
        {
            using (StreamReader reader1 = new StreamReader(filePath1))
            using (StreamReader reader2 = new StreamReader(filePath2))
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    int number1 = int.Parse(line1);
                    int number2 = int.Parse(line2);

                    if (number1 <= number2)
                    {
                        writer.WriteLine(number1);
                        line1 = reader1.ReadLine();
                    }
                    else
                    {
                        writer.WriteLine(number2);
                        line2 = reader2.ReadLine();
                    }
                }

                while (line1 != null)
                {
                    writer.WriteLine(line1);
                    line1 = reader1.ReadLine();
                }

                while (line2 != null)
                {
                    writer.WriteLine(line2);
                    line2 = reader2.ReadLine();
                }
            }

            File.Delete(filePath1);
            File.Delete(filePath2);
        }

        private static string GetTempFilePath(int pass)
        {
            return Path.GetTempFileName() + ".pass" + pass;
        }
    }






    }

