using Microsoft.VisualBasic;
using System.Text;
using static Home_Task_7b.TrafficLight;

namespace Home_Task_7b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Crossroads crossroads= new Crossroads();
            //crossroads.StartSimulation();
            //Crossroads crossroads1 = new Crossroads(0,20);
            //crossroads1.StartSimulation();
            Console.WriteLine();
            TrafficLight tl1= new TrafficLight(0.50f,0.2f,0.7f);
            TrafficLight tl2 = new TrafficLight(0.50f, 0.2f, 0.7f);
            TrafficLight tl3 = new TrafficLight(0.50f, 0.2f, 0.7f);
            TrafficLight tl4 = new TrafficLight(0.50f, 0.2f, 0.7f);

            Crossroads crossroads2 = new Crossroads(tl1,tl2,tl3,tl4,0,5);
            crossroads2.StartSimulation();
        }
    }
        
      
    }
