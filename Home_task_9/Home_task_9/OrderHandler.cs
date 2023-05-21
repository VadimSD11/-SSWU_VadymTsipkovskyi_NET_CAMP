using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Home_task_9
{
    public class OrderHandler
    {
        private Chef[] _pizzaChefs;
        private Chef[] _drinksChefs;
        private Chef[] _sweetsChefs;
       

        public OrderHandler()
        {

            _pizzaChefs = new Chef[] {
                new Chef("PizzaChef1", Prof.Pizza),
                new Chef("PizzaChef2", Prof.Pizza),
                new Chef("PizzaChef3", Prof.Pizza)
            };
            _drinksChefs = new Chef[] {
                new Chef("DrinksChef1", Prof.Drinks),
                new Chef("DrinksChef2", Prof.Drinks),
                new Chef("DrinksChef3", Prof.Drinks)
            };
            _sweetsChefs = new Chef[] {
                new Chef("SweetsChef1", Prof.Sweets),
                new Chef("SweetsChef2", Prof.Sweets),
                new Chef("SweetsChef3", Prof.Sweets)
            };
        }
        public OrderHandler(Chef[] pizzaChefs, Chef[] drinksChefs, Chef[] sweetsChefs)
        {
            _pizzaChefs = pizzaChefs;
            _drinksChefs = drinksChefs;
            _sweetsChefs = sweetsChefs;
        }

        public void HandleDishes(List<Dish> dishes)
        {
            var tasks = new List<Task>();

            foreach (var dish in dishes)
            {
                Task task = null;

                if (dish.prof == Prof.Pizza)
                {
                    var chef = GetAvailableChef(_pizzaChefs);
                    if (chef != null)
                    {
                        chef.IsBusy = true;
                        task = Task.Run(() =>
                        {
                            chef.HandleDish(dish);
                            chef.IsBusy = false;
                        });
                    }
                }
                else if (dish.prof == Prof.Drinks)
                {
                    var chef = GetAvailableChef(_drinksChefs);
                    if (chef != null)
                    {
                        chef.IsBusy = true;
                        task = Task.Run(() =>
                        {
                            chef.HandleDish(dish);
                            chef.IsBusy = false;
                        });
                    }
                }
                else if (dish.prof == Prof.Sweets)
                {
                    var chef = GetAvailableChef(_sweetsChefs);
                    if (chef != null)
                    {
                        chef.IsBusy = true;
                        task = Task.Run(() =>
                        {
                            chef.HandleDish(dish);
                            chef.IsBusy = false;
                        });
                    }
                }

                if (task != null)
                {
                    tasks.Add(task);
                }
            }

            Task.WaitAll(tasks.ToArray());
        }

        private Chef GetAvailableChef(Chef[] chefs)
        {
            lock (chefs)
            {
                var chef = chefs.FirstOrDefault(chef => !chef.IsBusy);
                if (chef != null)
                {
                    chef.IsBusy = true;
                }
                return chef;
            }
        }
    }
}
