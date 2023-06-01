using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    public class KitchenWithOnlyThreeChefs
    {
        private Chef _pizzaChef;
        private Chef _drinksChef;
        private Chef _sweetsChef;
        private object _drinkLcok;
        private object _pizzaLock;
        private object _sweetsLock;

        public KitchenWithOnlyThreeChefs()
        {
            _pizzaLock = new object();
            _drinkLcok = new object();
            _sweetsLock = new object();
            _drinksChef = new Chef("Drinkoid", Prof.Drinks);
            _pizzaChef = new Chef("Pizzoid", Prof.Pizza);
            _sweetsChef = new Chef("Dessertoid", Prof.Sweets);
        }
        public KitchenWithOnlyThreeChefs(Chef pizzaChef, Chef drinksChef, Chef sweetsChef) { 
            _sweetsChef= sweetsChef;
            _pizzaChef= pizzaChef;
            _drinksChef= drinksChef;
            _pizzaLock = new object();
            _drinkLcok = new object();
            _sweetsLock = new object();
        }
        public void SetChefsEventConsoleOutput()
        {
            _pizzaChef.DishPreparationEvent += _pizzaChef.DishPreparationHandlerForConsole;
            _pizzaChef.DishFinishedEvent += _pizzaChef.DishFinishedHandlerForConsole;

            _drinksChef.DishPreparationEvent += _drinksChef.DishPreparationHandlerForConsole;
            _drinksChef.DishFinishedEvent += _drinksChef.DishFinishedHandlerForConsole;

            _sweetsChef.DishPreparationEvent += _sweetsChef.DishPreparationHandlerForConsole;
            _sweetsChef.DishFinishedEvent += _sweetsChef.DishFinishedHandlerForConsole;
        }
        public void ReSetChefsEventConsoleOutput()
        {
            _pizzaChef.DishPreparationEvent -= _pizzaChef.DishPreparationHandlerForConsole;
            _pizzaChef.DishFinishedEvent -= _pizzaChef.DishFinishedHandlerForConsole;

            _drinksChef.DishPreparationEvent -= _drinksChef.DishPreparationHandlerForConsole;
            _drinksChef.DishFinishedEvent -= _drinksChef.DishFinishedHandlerForConsole;

            _sweetsChef.DishPreparationEvent -= _sweetsChef.DishPreparationHandlerForConsole;
            _sweetsChef.DishFinishedEvent -= _sweetsChef.DishFinishedHandlerForConsole;
        }
        public void Work(List<Dish> dishes)
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








