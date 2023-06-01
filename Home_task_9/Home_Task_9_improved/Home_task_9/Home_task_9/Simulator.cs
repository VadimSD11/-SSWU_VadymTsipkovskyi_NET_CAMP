using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    internal class Simulator
    {
        

        private KitchenWithOnlyThreeChefs CreateKitchenThreeChefsConsoleInput() {
            Console.WriteLine("Вкажіть ім'я шефу відповідальному за піццу: ");
            string name = Console.ReadLine();
            Chef pizza = new Chef(name, Prof.Pizza);
            Console.WriteLine("Вкажіть ім'я шефу відповідальному за напої: ");
            string name2 = Console.ReadLine();
            Chef drinks = new Chef(name2, Prof.Drinks);
            Console.WriteLine("Вкажіть ім'я шефу відповідальному за десерти: ");
            string name3 = Console.ReadLine();
            Chef sweets = new Chef(name3, Prof.Sweets);
            return new KitchenWithOnlyThreeChefs(pizza,drinks,sweets);
        }
        private Dish[] CreateDishList() {

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
            return dishes.ToArray();
        }
        private void CreateDishforDishListConsoleInput(List<Dish> dishes) {
            Console.WriteLine("Вкажіть назву страви: ");
            try
            {
                string name = Console.ReadLine();
                Console.WriteLine("Вкажіть кількість: ");
                uint m = UInt32.Parse(Console.ReadLine());
                Console.WriteLine("Вкажіть час приготування: ");
                int t = Int32.Parse(Console.ReadLine());
                dishes.Add(new Dish(name, m, TimeSpan.FromSeconds(t)));
            }
            catch { CreateDishforDishListConsoleInput(dishes); }
        }
        private Dish[] CreateDishListConsoleInput()
        {

            Console.WriteLine("Вкажіть кілкькість блюд: ");
            List<Dish> dishes = new List<Dish>();

            try
            {
                uint n = UInt32.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                 CreateDishforDishListConsoleInput(dishes); 
                }
            }
            catch { Console.Clear(); CreateDishListConsoleInput(); }
            return dishes.ToArray();

        }

        private Kitchen? CreateKitchenConsoleInput() {
            Console.WriteLine("Вкажіть кількість шефів відповідальних за піццу");
            int p = Int32.Parse(Console.ReadLine());
            List<Chef> pizzachefs = new List<Chef>();
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine("Вкажіть ім'я шефу відповідальному за піццу: ");
                string name = Console.ReadLine();
                Chef pizza = new Chef(name, Prof.Pizza);
                pizzachefs.Add(pizza);
            }
            Console.WriteLine("Вкажіть кількість шефів відповідальних за напої");
            int d = Int32.Parse(Console.ReadLine());
            List<Chef> drinkschefs = new List<Chef>();
            for (int i = 0; i < d; i++)
            {
                Console.WriteLine("Вкажіть ім'я шефу відповідальному за напої: ");
                string name = Console.ReadLine();
                Chef drinks = new Chef(name, Prof.Drinks);
                drinkschefs.Add(drinks);
            }
            Console.WriteLine("Вкажіть кількість шефів відповідальних за десерти");
            int swts = Int32.Parse(Console.ReadLine());
            List<Chef> sweetschefs = new List<Chef>();
            for (int i = 0; i < swts; i++)
            {
                Console.WriteLine("Вкажіть ім'я шефу відповідальному за десерти: ");
                string name = Console.ReadLine();
                Chef sweets = new Chef(name, Prof.Sweets);
                sweetschefs.Add(sweets);
            }
            Chef[] parry=pizzachefs.ToArray();
            Chef[] drnks=drinkschefs.ToArray();
            Chef[] sts=sweetschefs.ToArray();
            Kitchen kitchen = new Kitchen(parry,drnks,sts);
            return kitchen;

        }
        public void SimulateForConsole() { 
            Kitchen kitchen = new Kitchen();
            Dish[] dishes = CreateDishList();
            kitchen.SetChefsEventConsoleOutput();
            kitchen.Work(dishes.ToList());
            
        
        }
        public void SimulateForConsoleWithDataInput() {
            Dish[] dishes = CreateDishListConsoleInput();
           
            try
            {
                Console.WriteLine("Оберіть тип кухні 1) велика кухня 2) мала кухня");
                int n = Int32.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Kitchen kitchen = CreateKitchenConsoleInput();
                    kitchen.SetChefsEventConsoleOutput();
                    kitchen.Work(dishes.ToList());
                }
                if (n == 2)
                {
                    KitchenWithOnlyThreeChefs kitchen = CreateKitchenThreeChefsConsoleInput();
                    kitchen.SetChefsEventConsoleOutput();
                    kitchen.Work(dishes.ToList());
                }
            }
            catch {
                Console.Clear();
                Console.WriteLine("Неправльно введені дані");
                Console.WriteLine("Оберіть тип кухні 1) велика кухня 2) мала кухня");
                int n = Int32.Parse(Console.ReadLine());
                if (n == 1)
                {
                    Kitchen kitchen = CreateKitchenConsoleInput();
                    kitchen.SetChefsEventConsoleOutput();
                    kitchen.Work(dishes.ToList());
                }
                if (n == 2)
                {
                    KitchenWithOnlyThreeChefs kitchen = CreateKitchenThreeChefsConsoleInput();
                    kitchen.SetChefsEventConsoleOutput();
                    kitchen.Work(dishes.ToList());
                }

            }

        }
    }
}
