using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10
{
    internal class ShopVisitor : IVisitor
    {
        public void Visit(Product product)
        {
           
            double deliveryCost = CalculateDeliveryCost(product.Weight, product.Size);
            if (product.Days < 7) { deliveryCost += 5; }
            Console.WriteLine($"Delivery cost for Product: {deliveryCost}");
        }

        public void Visit(Electronics electronics)
        {
            double deliveryCost = CalculateDeliveryCost(electronics.Weight, electronics.Size);
            double excessCharge = electronics.ExcessChargePercentage * deliveryCost / 100;

            if(electronics.Size>10)
            deliveryCost += excessCharge;

            Console.WriteLine($"Delivery cost for Electronics: {deliveryCost}");
        }

        public void Visit(Clothes clothes)
        {
            double deliveryCost = CalculateDeliveryCost(clothes.Weight, clothes.Size);
            Console.WriteLine($"Delivery cost for Clothes: {deliveryCost}");
        }

        private double CalculateDeliveryCost(double weight, double size)
        {
          
            return weight * size;
        }
    
    }
}
