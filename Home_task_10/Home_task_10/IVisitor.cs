using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10
{
    internal interface IVisitor
    {
        void Visit(Product product);
        void Visit(Electronics electronics);
        void Visit(Clothes clothes);
    }
}
