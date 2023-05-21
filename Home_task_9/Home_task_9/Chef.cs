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
        public string Name { get; private set; }
        public Prof _chefsproffesion;
        public bool IsBusy { get;  set; }
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

            Console.WriteLine($"{Name} готує страву: {dish.Name} у кількості:{dish.Quantity}");
            Thread.Sleep(dish.CookingTime*dish.Quantity);
            Console.WriteLine($"{Name} приготував:{dish.Name}");
          
        }

        public override string? ToString()
        {
            return $"Chef's name:{Name}, chef's specialization:{_chefsproffesion}";
        }
    }
}
