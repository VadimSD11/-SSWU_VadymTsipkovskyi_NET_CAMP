using System.Text;

namespace Exercise___1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            
            Console.WriteLine("Vadym_Tsipkovskyi_Task_1");
            Console.WriteLine("Matrix: ");
            int[,] matrix = {
            {0, 1 ,2 ,3},
            {4, 5, 6, 7},
            {8, 9, 10, 11},
            {12, 13, 14, 15}
        };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write(matrix[i,j]+"\t");
                }
                Console.WriteLine();
            }

            SpiralMatrix m = new SpiralMatrix(matrix);

            var e = m.GetEnumerator();
            Console.WriteLine("Прохід по матрці:");
            while (e.MoveNext()) { Console.WriteLine(e.Current); }

            Console.ReadLine();



        }
    }
    }
