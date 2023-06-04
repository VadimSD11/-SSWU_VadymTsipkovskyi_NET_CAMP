using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10
{
    internal class Product : IProduct
    {
        public double Weight { get; set; }
        public double Size { get; set; }
        public uint Days { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
