namespace Exercise__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Tree[] trees = { new Tree(0, 0), new Tree(0, 1), new Tree(1, 0), new Tree(1, 1),new Tree(2,1) };
            Tree[] trees3 = { new Tree(0, 0), new Tree(0, 1), new Tree(1, 3), new Tree(1, 1), new Tree(2, 1) };

            Tree tree = new Tree(0, 0);
            Console.WriteLine(tree);
       
            Garden garden =new Garden(trees);
            Garden garden2=new Garden(trees);
            Garden garden3 = new Garden(trees3);

            Console.WriteLine(garden);
            Console.WriteLine(garden2);
            Console.WriteLine(garden3);
           // Console.WriteLine(garden.ComputePerimeter(trees));
            Console.WriteLine();
            Console.WriteLine(garden==garden2);
            Console.WriteLine(garden2!=garden);
            Console.WriteLine();
            Console.WriteLine(garden.Equals(garden2));
            Console.WriteLine(garden2.Equals(garden));
            Console.WriteLine();

            Console.WriteLine(garden == garden3);
            Console.WriteLine(garden3 != garden);
            Console.WriteLine();
            Console.WriteLine(garden3.Equals(garden));
            Console.WriteLine(garden3.Equals(garden2));
            Console.WriteLine();
        }
    }
}