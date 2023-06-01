using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_9
{
    public enum Prof { Drinks, Sweets, Pizza }

    public class Chef
    {
        public event Action<string,string, uint> DishPreparationEvent;
        public event Action<string,string> DishFinishedEvent;

        public string Name { get; private set; }
        public Prof _chefsproffesion;
        public bool IsBusy { get;  set; }
        public Chef() {
            Name = "Chef";
            _chefsproffesion= Prof.Pizza;
            IsBusy = false;
        }
        public Chef(string lastName,Prof prof)
        {
            Name = lastName;
            _chefsproffesion = prof;
            IsBusy = false;
        }

        public bool CanHandleDish(Dish dish)
        {
            
            
                if (this._chefsproffesion == dish.prof)
                {
                    
                    return true; }
            
          return false;
        }
       
        public void HandleDish(Dish dish)
        {

            DishPreparationEvent?.Invoke(Name,dish.Name, dish.Quantity);

            Thread.Sleep(dish.CookingTime*dish.Quantity);
            DishFinishedEvent?.Invoke(Name, dish.Name);          
        }
        public void DishPreparationHandlerForConsole(string chefName, string dishname, uint quantity)
        {
            Console.WriteLine($"{chefName} готує страву {dishname} у кількості: {quantity}");
        }
        public void DishFinishedHandlerForConsole(string chefName, string dishname)
        {
            Console.WriteLine($"{chefName} приготував {dishname} ");
        }

        public override string? ToString()
        {
            return $"Chef's name:{Name}, chef's specialization:{_chefsproffesion}";
        }
    }
}
