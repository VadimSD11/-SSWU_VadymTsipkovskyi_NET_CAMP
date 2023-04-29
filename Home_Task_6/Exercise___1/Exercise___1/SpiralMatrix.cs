using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise___1
{
    internal class SpiralMatrix:IEnumerable
    {
        private readonly int[,] matrix;

        public SpiralMatrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0, j = 0;
            bool goDown = true;
            int m=matrix.GetLength(0);
            int n=matrix.GetLength(1);

            for (int k = 0; k < n*m; k++)
            {
                yield return matrix[i, j];

                if (goDown)
                {
                    if (i == 3)
                    {
                        j++;
                        goDown = false;
                    }
                    else if (j == 0)
                    {
                        i++;
                        goDown = false;
                    }
                    else
                    {
                        i++;
                        j--;
                    }
                }
                else
                {
                    if (j == 3)
                    {
                        i++;
                        goDown = true;
                    }
                    else if (i == 0)
                    {
                        j++;
                        goDown = true;
                    }
                    else
                    {
                        i--;
                        j++;
                    }
                }
            }
        }


            IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
