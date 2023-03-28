using System.Text;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            Console.WriteLine();
            Console.WriteLine("Цiпковський_Вадим_Задача_3");
            Console.WriteLine();
            int[,,] array3D = new int[,,] {
            {  {1,1,1},
               {1,0,1},
               {1,1,1}
            },

            {   {1,1,1},
                {1,0,1},
                {1,1,1}
            },
             {  {1,1,1},
                {1,0,1},
                {1,1,1}
            }
        };

            Cube cube = new Cube(array3D);
            cube.Execute();
        }
    }
}
