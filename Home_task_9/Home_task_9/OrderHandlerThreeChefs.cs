using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    public class OrderHandlerThreeChefs
    {
        private Chef _pizzaChef;
        private Chef _drinksChef;
        private Chef _sweetsChef;
        private object _drinkLcok;
        private object _pizzaLock;
        private object _sweetsLock;

        public OrderHandlerThreeChefs()
        {
            _pizzaLock = new object();
            _drinkLcok = new object();
            _sweetsLock = new object();
            _drinksChef = new Chef("Drinkoid", Prof.Drinks);
            _pizzaChef = new Chef("Pizzoid", Prof.Pizza);
            _sweetsChef = new Chef("Dessertoid", Prof.Sweets);
        }
        public void HandleDishes(List<Dish> dishes)
        {
            var tasks = new List<Task>();

            foreach (var dish in dishes)
            {
                if (_pizzaChef.CanHandleDish(dish))
                {
                    tasks.Add(Task.Run(() =>
                    {
                        lock (_pizzaLock)
                        {
                            _pizzaChef.HandleDish(dish);
                        }
                    }));
                }
                else if (_drinksChef.CanHandleDish(dish))
                {
                    tasks.Add(Task.Run(() =>
                    {
                        lock (_drinkLcok)
                        {
                            _drinksChef.HandleDish(dish);
                        }
                    }));
                }
                else if (_sweetsChef.CanHandleDish(dish))
                {
                    tasks.Add(Task.Run(() =>
                    {
                        lock (_sweetsLock)
                        {
                            _sweetsChef.HandleDish(dish);
                        }
                    }));
                }
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}








