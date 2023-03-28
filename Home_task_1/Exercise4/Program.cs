using System.Text;

namespace Exercise4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine("Цiпковський_Вадим_Задача_4");
            Console.WriteLine();
            int n = 3;
            // Створення тензору  3x3x3 
            Tensor<int> tensor3d = new Tensor<int>(n, n, n);

            Random rand = new Random();
            Console.WriteLine("Виведення тензору 3х3х3");
            // Встановлення випадкових значень 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        tensor3d.SetValue(rand.Next(0, 10), i, j, k);
                    }
                }
            }
            //виведення значень
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write(tensor3d.GetValue(i, j, k) + " ");
                    }

                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Tensor<int> tensor2d = new Tensor<int>(n, n);
            Console.WriteLine("Виведення тензору 3х3");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tensor2d.SetValue(rand.Next(0, 10), i, j);
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(tensor2d.GetValue(i, j) + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Виведення вектору");
            Tensor<int> tensor1d = new Tensor<int>(n);
            for (int i = 0; i < n; i++)
            {
                tensor1d.SetValue(rand.Next(0, 10), i);

            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(tensor1d.GetValue(i) + " ");

            }
            Console.WriteLine();
            Console.WriteLine("Виведення числа");
            Tensor<int> tnsr1d = new Tensor<int>(1);
            tnsr1d.SetValue(10, 0);
            Console.WriteLine(tnsr1d.GetValue(0));
        }
    }
}