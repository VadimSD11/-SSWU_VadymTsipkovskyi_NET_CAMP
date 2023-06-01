using System.Text;

namespace Home_task_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                 OrderHandler - реалізація із трьома масивами шефів
                 OrderHandlerThreeChefs - реалізація де усього три шефи 
                 (я його залишив окремо бо мені здається, що він працює краще ніж той що на три масиви )
    
            Напевно трошки поправив програму додавши класс симулятор і замінивши у классі шеф строки із виводом у консоль на обробку відпоідниш подій
             */
            Console.OutputEncoding = Encoding.UTF8;
         
           Simulator simulator= new Simulator();
            simulator.SimulateForConsoleWithDataInput();

        }
    }
}