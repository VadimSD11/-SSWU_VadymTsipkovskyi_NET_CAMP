using System.Text;

namespace Exercise2
{
    internal class Program
    {
        public static void FindAndPrintLongestHorizontalLine(int[,] arr)
        {
            //змінні для пошуку запитаної інформації
            int longestLength = 0;
            int longestStartRow = 0;
            int longestEndRow = 0;
            int longestStartCol = 0;
            int longestEndCol = 0;

            //цикл обходить масив і шукає необхідну інформацію
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int currentLength = 1;
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == arr[i, j - 1])
                    {
                        currentLength++;
                    }
                    else
                    {
                        if (currentLength > longestLength)
                        {
                            longestLength = currentLength;
                            longestStartRow = i;
                            longestEndRow = i;
                            longestStartCol = j - currentLength;
                            longestEndCol = j - 1;
                        }
                        currentLength = 1;
                    }
                }
                if (currentLength > longestLength)
                {
                    longestLength = currentLength;
                    longestStartRow = i;
                    longestEndRow = i;
                    longestStartCol = arr.GetLength(1) - currentLength;
                    longestEndCol = arr.GetLength(1) - 1;
                }
            }
            int longestElement = arr[longestStartRow, longestStartCol];
            if (longestLength > 1)
            {
                Console.WriteLine("\n Найдовша горизонтальна лінія створена із {0} ;\n починається за такою адресою строка {1} стовпчик {2} ;\n закінчується у строці {3} стовпчику {4} ;\n має довжину = {5};", longestElement, longestStartRow, longestStartCol, longestEndRow, longestEndCol, longestLength);
            }
            else
            {
                Console.WriteLine("Горизантальні лінії у масиві відсутні");
            }
        }
            static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine();
            Console.WriteLine("Цiпковський_Вадим_Задача_2");
            Console.WriteLine();

            Console.Write("Вкажiть значення n:");
            string n1 = Console.ReadLine();
            int n = int.Parse(n1);


            Console.Write("Вкажiть значення m:");
            string m1 = Console.ReadLine();
            int m = int.Parse(m1);
            int[,] arr = new int[n, m];
            if (n > 0 && m > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("Вкажіть значення для [{0},{1}]: ", i, j);
                        int val = Convert.ToInt32(Console.ReadLine());
                        if (val >= 0 && val <= 16) { arr[i, j] = val; }
                        else
                        {
                            Console.WriteLine("Вказане значення не підходить\n Введіть коректні данні");
                            goto exitLoop;
                        }
                    }
                }
                FindAndPrintLongestHorizontalLine(arr);
            exitLoop:;
            }
            else
            {

                Console.WriteLine("m i n мають бути бiльше 0");
            }
        }
    }
    }
