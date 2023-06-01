using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Home_task_9
{
    public class Dish
    {
        public string Name { get; private set; }
        public uint Quantity { get; private set; }
        public TimeSpan CookingTime { get; private set; }
        public Prof prof { get; private set; }
        public Dish(string name, uint quantity, TimeSpan cookingTime)
        {
            Name = name;
            Quantity = quantity;
            CookingTime = cookingTime;
            string[] drinks = { "drink", "water", "juice","vodka","cola","lemonade","soda",
                "milk","coffe","tea","cognak","rome","beer","wine","whiskey","Fanta","Spirte","7up" };
            string pizza = "pizza";
            bool containsAnydrink = drinks.Any(substring => name.ToLower().Contains(substring.ToLower()));
            if (containsAnydrink) { prof = Prof.Drinks; }
            else if (name.ToLower().Contains(pizza)) { prof = Prof.Pizza; }
            else if(!containsAnydrink && !(name.ToLower().Contains(pizza))){ prof = Prof.Sweets; }
        }

        public override string? ToString()
        {
            return $"{Name}\t Amount:{Quantity}\t Cooking Time:{CookingTime}";
        }
    }
}
