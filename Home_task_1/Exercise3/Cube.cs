using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{// Не враховано подібність коду на 3 вітках. тут можна оптимізувати....
    internal class Cube
    {
        int[,,] _cube;
        int _size;
        public Cube()
        {
            this._size = 3;
            this._cube = new int[_size, _size, _size];
        }
        public Cube(int[,,] cube)
        {
            this._cube = cube;
            this._size = cube.GetLength(0);
        }
        public Cube(int size)
        {
            this._size = size;
            this._cube = new int[_size, _size, _size];
        }
        public Cube(int size, int[,,] cube)
        {
            this._cube = cube;
            this._size = size;
        }
        public void Execute()
        {

            // шукаємо отвір
            for (int i = 0; i < _cube.GetLength(0); i++)
            {

                for (int j = 0; j < _cube.GetLength(1); j++)
                {
                    // Шукаємо отвір у осі X
                    // ваш коментар не коректний. Змінюється третя координата...
                    bool holeExistsAlongX = true;
                    for (int k = 0; k < _cube.GetLength(2); k++)
                    {
                        if (_cube[i, j, k] != 0)
                        {
                            holeExistsAlongX = false;
                            break;
                        }
                    }
                    if (holeExistsAlongX)
                    {
                        Console.WriteLine("Отвір знайдено у осі X:");
                        Console.WriteLine($"Початок отвору: ({i}, {j}, 0 )");
                        Console.WriteLine($"Кінець отвору: ({i}, {j}, {_cube.GetLength(2) - 1})");
                    }

                    // Шукаємо отвір у осі Y
                    bool holeExistsAlongY = true;
                    for (int k = 0; k < _cube.GetLength(2); k++)
                    {
                        if (_cube[i, k, j] != 0)
                        {
                            holeExistsAlongY = false;
                            break;
                        }
                    }
                    if (holeExistsAlongY)
                    {
                        Console.WriteLine("Отвір знайдено у осі Y:");
                        Console.WriteLine($"Початок отвору: ({i}, 0, {j})");
                        Console.WriteLine($"Кінець отвору: ({i}, {_cube.GetLength(1) - 1}, {j})");
                    }

                    // Шукаємо отвір у осі Z
                    bool holeExistsAlongZ = true;
                    for (int k = 0; k < _cube.GetLength(0); k++)
                    {
                        if (_cube[k, i, j] != 0)
                        {
                            holeExistsAlongZ = false;
                            break;
                        }
                    }
                    if (holeExistsAlongZ)
                    {//роздруки в модельних класах є не бажані.
                        Console.WriteLine("Отвір знайдено у осі Z:");
                        Console.WriteLine($"Початок отвору: (0, {i}, {j})");
                        Console.WriteLine($"Кінець отвору: ({_cube.GetLength(0) - 1}, {i}, {j})");
                    }
                }

            }
        }
    }
}
