using System.Runtime.Intrinsics.Arm;

namespace Exercise__2
{
    internal class Program
    {// немає копії вікна виконання.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Box shop = Box.CreateShop();

            Console.WriteLine();
            shop.PrintInfoAboutBoxesInIt();
            Box[] boxes = Box.GetlAllBoxesExceptShopAndDepBoxes(shop);
            Console.WriteLine();
            Box.MakeOrderInfo(boxes);
        }
    }
}
