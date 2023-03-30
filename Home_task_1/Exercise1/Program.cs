namespace Exercise1
{
    internal class Program
    {//Напишіть, будь ласка, що бачите мій коментар.
        public static int[,] FillSpiralSnake(int n, int m)
        {
            try
            {
                // Виділення пам'яті 
                int[,] matrix = new int[n, m];

                // Bстановлення початкові значення для індексів рядків і стовпчиків
                int row = 0, col = 0;

                // задаємо напрям заповнення масиву
                string direction = "down";

                // цикл заповнення масиву
                for (int i = 1; i <= n * m; i++)
                {
                    // задання значення елемнту масива 
                    matrix[row, col] = i;

                    // переміщення по масиву в залежності від напрямку руху
                    switch (direction)
                    {
                        case "down":
                            if (row == n - 1 || matrix[row + 1, col] != 0)
                            {
                                direction = "right";
                                col++;
                            }
                            else
                            {
                                row++;
                            }
                            break;
                        case "right":
                            if (col == m - 1 || matrix[row, col + 1] != 0)
                            {
                                direction = "up";
                                row--;
                            }
                            else
                            {
                                col++;
                            }
                            break;
                        case "up":
                            if (row == 0 || matrix[row - 1, col] != 0)
                            {
                                direction = "left";
                                col--;
                            }
                            else
                            {
                                row--;
                            }
                            break;
                        case "left":
                            if (col == 0 || matrix[row, col - 1] != 0)
                            {
                                direction = "down";
                                row++;
                            }
                            else
                            {
                                col--;
                            }
                            break;
                    }
                }

                return matrix;
            }
            catch
            {
                Console.WriteLine("Wrong input data");
                throw new Exception("Wrong input data");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Цiпковський_Вадим_Задача_1");
            Console.WriteLine();

            Console.Write("Вкажiть значення n:");
            string n1 = Console.ReadLine();
            int n = int.Parse(n1);


            Console.Write("Вкажiть значення m:");
            string m1 = Console.ReadLine();
            int m = int.Parse(m1);
            if (n > 0 && m > 0)
            {
                Console.WriteLine();

                Console.WriteLine("Масив для n = " + n + " та " + " m = " + m + "\n");
                int[,] matrix = FillSpiralSnake(n, m);
                // Виведення масиву
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("m i n мають бути бiльше 0");
            }
        }
    }
}
