using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__2
{
    internal class Box
    {
        public string Name { get; set; }
        public Box ParentBox { get; set; }
        public Size Size { get; set; }
        public Department department { get; set; }
        public List<Box> Boxes { get; set; } = new List<Box>();
        public List<Item> itemsInBox { get; set; }=new List<Item>();

        public Box(string name) { 
        this.Name= name;
        }
        public Box(string name, Size size) {
            this.Name = name;
            this.Size = size;

        }
        public Box(Item item) {
            this.Name= item.Name;
            this.Size = item.Size;
            if (item.Department != null) { this.department = item.Department; }
           this.itemsInBox.Add(item);
        }
        
        public Box(Department dep) {
            Size totalSize = new Size(0, 0, 0);

            foreach (Item item in dep.Items) {
                totalSize.Depth += item.Size.Depth;
                totalSize.Width += item.Size.Width;
                totalSize.Height += item.Size.Height;
            }
            foreach (Item item in dep.Items)
            {
                this.Boxes.Add(ToPackSingleItem(item));
            }
            this.Name = dep.Name; this.Size = totalSize;
        }
        public static Box CreateShop() {
            Console.WriteLine("Input shop's name:");
            try
            {
                string name = Console.ReadLine();
                Box shop = new Box(name);
                Console.WriteLine("Input amount of Departments:");
                int n = int.Parse(Console.ReadLine());
                bool depchild = false;
                List<Department> deps = new List<Department>();
                List<Box> depBox = new List<Box>();

                for (int i = 0; i < n; i++)
                {
       
                    Department dep;
                    Console.WriteLine("Input Department name");
                    string depname = Console.ReadLine();
                    dep = new Department(depname);
                    deps.Add(dep);

                }
                foreach (Department dep in deps)
                {
                    Console.WriteLine("Add amount of items you want to add to this department(" + dep.Name + "):");
                    int m = int.Parse(Console.ReadLine());
                    for (int i = 0; i < m; i++)
                    {
                        Console.WriteLine("Enter item's name:");
                        string itemname = Console.ReadLine();
                        Console.WriteLine("Enter item's Height");
                        float height = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter item's Width");
                        float width = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter item's Depth");
                        float depth = float.Parse(Console.ReadLine());
                        Size item_size = new Size(width, height, depth);
                        Item item1 = new Item(itemname, item_size);
                        item1.SetDepartment(dep);
                        dep.Items.Add(item1);



                    }
                    Box boxdepbox = new Box(dep);
                    foreach (Box item in boxdepbox.Boxes)
                    {
                        item.ParentBox = boxdepbox;
                        item.department = boxdepbox.department;
                    }
                    boxdepbox.ParentBox = shop;
                    shop.Boxes.Add(boxdepbox);

                }

               
                return shop;
            }
            catch { Console.WriteLine("Input error"); return new Box("Error"); }
        
        }
        public static Box[] GetlAllBoxesExceptShopAndDepBoxes(Box shop) {
            List<Box> boxes = new List<Box>();
            foreach (Box item in shop.Boxes)
            {
                foreach (Box item1  in item.Boxes)
                {
                    boxes.Add(item1);
                }
            }

           return boxes.ToArray();
            
        
        }
        public static void MakeOrderInfo(Box[] allitemsinboxes) {
            Console.WriteLine("Enter item's adress in this way (shop's name\\\\department's name\\\\item's name)");
            string s = Console.ReadLine();
            GetInfoAboutOreder(s,allitemsinboxes);
        }
        private static void GetInfoAboutOreder(string s, Box[] boxes)
        {
            foreach (Box item in boxes)
            {
                if (s == item.ParentBox.ParentBox.Name + "\\\\" + item.ParentBox.Name + "\\\\" + item.Name)
                    item.PrintInfoAboutBoxesInIt();
             }
            
        }
        public static Box ToPackSingleItem(Item item) {
           Box box= new Box(item.Name, item.Size);
            box.itemsInBox.Add(item);
            if (item.Department != null) { box.department = item.Department; }
            return box;
        }
        public Box ToPackDepartment(Department dep) {

            Size totalSize=new Size(0,0,0);
            foreach (Item item in dep.Items) { 
                totalSize.Depth+=item.Size.Depth;
                totalSize.Width+=item.Size.Width;
                totalSize.Height+=item.Size.Height;
                
            }
            Box box = new Box(dep.Name, totalSize);
            foreach (Item item in dep.Items)
            {
                box.Boxes.Add(ToPackSingleItem(item));
            }
            return box;
        }
        public void PrintInfoAboutBoxesInIt() {
            Console.WriteLine(this);
            foreach (Box item in Boxes)
            {
                if (item.Boxes.Count > 0)//якщо коробка не пуста виводимо її зміст
                {
                    Console.WriteLine(item);
                    foreach (Box item1 in item.Boxes)
                    {
                        item1.department = item.department;
                        Console.WriteLine(item1);
                    }
                }
                else
                {
                    Console.WriteLine(item);
                }

            }
         
        }
        public override string? ToString()
        {
            if ( ParentBox != null) {
                return "This box name is:" + Name +"\nIt is located in box named:"+ParentBox.Name + "\nThis Box contains: " + itemsInBox.Count + " items\nThis box contains: " + Boxes.Count + " boxes";

            }
            if (department != null)
                return "This box name is:" + Name + "\nIt is located in " + department.Name + " department" + "\nThis Box contains: " + itemsInBox.Count + " items\nThis box contains: " + Boxes.Count + " boxes ";
            else {

                return "This box name is:" + Name + "\nThis Box contains: " + itemsInBox.Count + " items\nThis box contains: " + Boxes.Count + " boxes " ;
            }
        }
    }
}