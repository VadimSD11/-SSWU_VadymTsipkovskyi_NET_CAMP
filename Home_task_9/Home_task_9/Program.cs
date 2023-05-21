using System.Text;

namespace Home_task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                 OrderHandler - реалізація із трьома масивами шефів
                 OrderHandlerThreeChefs - реалізація де усього три шефи 
                 (я його залишив окремо бо мені здається, що він працює краще ніж той що на три масиви )
             */
            Console.OutputEncoding = Encoding.UTF8;
            List<Dish> dishes = new List<Dish> {
             new Dish("Pizza 4 cheeses",3, TimeSpan.FromSeconds(5)),
             new Dish("Tiramisu", 2, TimeSpan.FromSeconds(2)),
             new Dish("Hawai Pizza", 5, TimeSpan.FromSeconds(5)),
             new Dish("Heaven's Dessert",3, TimeSpan.FromSeconds(5)),
             new Dish("Pineapple Juice", 1, TimeSpan.FromSeconds(5)),
             new Dish("Cake", 5, TimeSpan.FromSeconds(5)),
             new Dish("Cola", 5, TimeSpan.FromSeconds(5)),
             new Dish("Soda", 6, TimeSpan.FromSeconds(2)),
            };
            OrderHandlerThreeChefs orderHandler = new OrderHandlerThreeChefs();
            orderHandler.HandleDishes(dishes);
            //OrderHandler orderHandler1 = new OrderHandler();
            //orderHandler1.HandleDishes(dishes);
        }
    }
}