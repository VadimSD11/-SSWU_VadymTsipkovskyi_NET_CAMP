using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__2
{
    internal class Item
    {
        public string Name { get; set; }
        public Department Department { get; set; }
        public Size Size { get; set; }

        public Item(string name,  Size size)
        {
            Name = name;
            Size = size;
        }
        public void SetDepartment(Department dep) { 
            Department = dep;
        }
        public override string? ToString()
        {
            if(Department== null) 
            return "This is "+Name+". It's size is "+Size.ToString();
            else
            {
                return "This is " + Name + ". It's size is " + Size.ToString()+" It relates to "+Department.Name+" department";

            }
        }
    }
}
