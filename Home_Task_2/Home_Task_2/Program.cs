namespace Home_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(120);
            Pump pump = new Pump(5.5);
            WaterTower waterTower = new WaterTower(24, pump);
            Simulator simulator = new Simulator(waterTower, pump, user);
            Console.WriteLine(simulator.ToString());
            Console.WriteLine();
            simulator.Simulate();
        }
    }
}