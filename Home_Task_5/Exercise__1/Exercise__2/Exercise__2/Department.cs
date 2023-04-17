using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__2
{
    internal class Department
    {
        private Department _parent;

        public List<Item> Items { get; set; } = new List<Item>();

        public string Name { get; set; }//назва відділу
        public List<Department> Children { get; set; } = new List<Department>();
        
        public Department(string name) { 
        
        Name= name;
 
        }
   
        public void SetParent(Department department) { 
        _parent= department;
        }
        public void PrintAllItems() {
            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }
        public override string ToString()
        {
            if(_parent == null)
            return "This department name is: "+Name+"\nIt contains "+Items.Count+" items"+"\nIt has "+Children.Count+" children departments";
            else {
                return "This department name is: " + Name + "\nIt contains " + Items.Count + " items" + "\nIt has " + Children.Count + " children departments"+"\nIt is a child department of "+_parent+" department";
            }
        }
    }
}
