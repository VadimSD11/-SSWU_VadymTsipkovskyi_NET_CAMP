using System;
using System.IO;

namespace Home_task_11
{
    public class Task2
    {
        public static void Execute()
        {
            Console.WriteLine("Task 2");
            string filePath = "input.txt";
            GenerateInputFile(filePath, 100);
            Console.WriteLine("File content before sort:");
            PrintFileInfo(filePath);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("File content after sort:");
            FileMergeSort.Sort(filePath);
            PrintFileInfo(filePath);


        }
        static void PrintFileInfo(string filePath) {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write(line + " ");
                }
            }
        }

        static void GenerateInputFile(string filePath, int count)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(random.Next(1, 100));
                }
            }
        }
    }
}
