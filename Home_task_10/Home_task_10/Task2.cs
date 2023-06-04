using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10
{
    internal  static class Task2
    {
        public static void Execute() {
            var shippingCostVisitor = new ShopVisitor();
            List<IProduct> components = new List<IProduct>() {  
                new Product { Weight = 2, Size = 13, Days=4 },
                new Electronics { Weight = 4, Size = 15, ExcessChargePercentage = 15 },
                new Clothes { Weight = 1, Size = 2 },
                new Product { Weight = 2, Size = 13, Days=14 }

                 };
            Client.ClientCode(components, shippingCostVisitor);


        }
    }
}
