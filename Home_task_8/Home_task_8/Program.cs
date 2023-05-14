using System.Text;

namespace Home_task_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TrafficLight trafficLight = new TrafficLight(100, 200, 300);
            trafficLight.SetColor(TrafficLight.LightColor.Green);
            TrafficLightWithTurnRegulation tl = new TrafficLightWithTurnRegulation();
            tl.SetColor(TrafficLight.LightColor.Green);
            tl.SetName("West-East Light");
            trafficLight.SetName("East-West Light");
            RoadLane rl=new RoadLane(tl);
            RoadLane rl2=new RoadLane(trafficLight);
            Road road = new Road(rl, rl2);
            Road road1 = new Road();
            Crossroads crossroads = new Crossroads(road1,road,0,7);
            crossroads.StartSimulation();
        }
    }
}