using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__1
{
    public class Tree
    {
        private readonly double x;
        private readonly double y;
        public Tree(double x, double y) {
            this.x = x;
            this.y = y;
        }
        public double X { get { return x; } }   
        public double Y { get { return y; } }

        public override string? ToString()
        {
            return $"This tree locates at ({x},{y})";
        }
    }
}
