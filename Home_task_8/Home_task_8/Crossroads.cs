using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class Crossroads
    {
        private Road northSouth;
        private Road eastWest;
        private TimeSpan stimulationStart;
        private TimeSpan stimulationEnd;
        private TimeSpan stimulationtime;


        public Crossroads()
        {

            TrafficLight _northSouth = new TrafficLight();
            TrafficLight _southNorth = new TrafficLight();
            TrafficLight _westEast = new TrafficLight();
            TrafficLight _eastWest = new TrafficLight();
            
            _northSouth.SetDuration(0.50f, 0.5f, 0.7f);
            _southNorth.SetDuration(0.50f, 0.5f, 0.7f);
            _westEast.SetDuration(0.50f, 0.2f, 0.7f);
            _eastWest.SetDuration(0.50f, 0.2f, 0.7f);

            _westEast.SetColor(TrafficLight.LightColor.Green);
            _eastWest.SetColor(TrafficLight.LightColor.Green);

            RoadLane northsouthrl= new RoadLane(_northSouth);
            RoadLane southnorthrl = new RoadLane(_southNorth);
            northSouth = new Road(northsouthrl, southnorthrl);
            RoadLane eastWestrl = new RoadLane(_eastWest);
            RoadLane westEastrl=new RoadLane(_westEast);

            eastWest=new Road(westEastrl,eastWestrl);
            stimulationStart = TimeSpan.FromSeconds(0);
            stimulationEnd = TimeSpan.FromSeconds(6);
            stimulationtime = stimulationEnd - stimulationStart;


        }
        public Crossroads(float start, float end)
        {
            try
            {
                TrafficLight _northSouth = new TrafficLight();
                TrafficLight _southNorth = new TrafficLight();
                TrafficLight _westEast = new TrafficLight();
                TrafficLight _eastWest = new TrafficLight();

                _northSouth.SetDuration(0.50f, 0.5f, 0.7f);
                _southNorth.SetDuration(0.50f, 0.5f, 0.7f);
                _westEast.SetDuration(0.50f, 0.2f, 0.7f);
                _eastWest.SetDuration(0.50f, 0.2f, 0.7f);

                _westEast.SetColor(TrafficLight.LightColor.Green);
                _eastWest.SetColor(TrafficLight.LightColor.Green);

                RoadLane northsouthrl = new RoadLane(_northSouth);
                RoadLane southnorthrl = new RoadLane(_southNorth);
                northSouth = new Road(northsouthrl, southnorthrl);
                RoadLane eastWestrl = new RoadLane(_eastWest);
                RoadLane westEastrl = new RoadLane(_westEast);

                eastWest = new Road(westEastrl, eastWestrl);

                stimulationStart = TimeSpan.FromSeconds(start);
                stimulationEnd = TimeSpan.FromSeconds(end + 1);
                stimulationtime = stimulationEnd - stimulationStart;
            }
            catch { Console.WriteLine("Wrong input data"); }
        }
        public Crossroads(TrafficLight northSouthtl, TrafficLight southNorth, TrafficLight westEast, TrafficLight eastWesttl, float stimulationStart1, float stimulationEnd1)
        {
            try
            {
                var _northSouth = northSouthtl.DeepCopy();
                var _southNorth = southNorth.DeepCopy();
                var _westEast = westEast.DeepCopy();
                var _eastWest = eastWesttl.DeepCopy();
                _westEast.SetColor(TrafficLight.LightColor.Green);
                _eastWest.SetColor(TrafficLight.LightColor.Green);

                RoadLane northsouthrl = new RoadLane(_northSouth);
                RoadLane southnorthrl = new RoadLane(_southNorth);
                northSouth = new Road(northsouthrl, southnorthrl);
                RoadLane eastWestrl = new RoadLane(_eastWest);
                RoadLane westEastrl = new RoadLane(_westEast);

                eastWest = new Road(westEastrl, eastWestrl);

                this.stimulationStart = TimeSpan.FromSeconds(stimulationStart1);
                this.stimulationEnd = TimeSpan.FromSeconds(stimulationEnd1 + 1);
                this.stimulationtime = (stimulationEnd - stimulationStart);
            }
            catch { Console.WriteLine("Wrong input data"); }
        }
        public Crossroads(Road northSouthroad, Road westEastRoad) {

            northSouth=northSouthroad.Deepcopy();
            eastWest=westEastRoad.Deepcopy();
            stimulationStart = TimeSpan.FromSeconds(0);
            stimulationEnd = TimeSpan.FromSeconds(6);
            stimulationtime = stimulationEnd - stimulationStart;
        }
        public Crossroads(Road northSouthroad, Road westEastRoad,float stimulationStart1,float stimulationEnd1)
        {
            try
            {
                northSouth = northSouthroad.Deepcopy();
                eastWest = westEastRoad.Deepcopy();
                stimulationStart = TimeSpan.FromSeconds(stimulationStart1);
                stimulationEnd = TimeSpan.FromSeconds(stimulationEnd1+1);
                stimulationtime = stimulationEnd - stimulationStart;
            }
            catch (Exception ex) { Console.WriteLine("Wrong input Data"); }
        }
        public void SetNorthenLighttime(float red, float yellow, float green)
        {
           RoadLane[] rls= northSouth.GetRoadLanes();
            foreach (var item in rls)
            {
                item._trafficLight.SetDuration(red, yellow, green);
            }
          
        }
       
        public void SetEastLighttime(float red, float yellow, float green)
        {
            RoadLane[] rls = eastWest.GetRoadLanes();
            foreach (var item in rls)
            {
                item._trafficLight.SetDuration(red, yellow, green);
            }
        }
        public void printinfo(Stopwatch stopwatch)
        {
            RoadLane[] rls = northSouth.GetRoadLanes();
            RoadLane[] rls2 = eastWest.GetRoadLanes();

            Console.WriteLine($"t={stopwatch.Elapsed.TotalSeconds:N0} с");
            Console.WriteLine($"Світлофор  Північ-південь  Південь-північ    Схід-захід    Захід-схід\nКолір: \t\t{rls[0]._trafficLight.CurrentColor}\t\t{rls[1]._trafficLight.CurrentColor}\t\t{rls2[0]._trafficLight.CurrentColor}\t\t{rls2[1]._trafficLight.CurrentColor}");

        }
        public void StartSimulation()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            RoadLane[] rls = northSouth.GetRoadLanes();
            RoadLane[] rls2 = eastWest.GetRoadLanes();

            while (stopwatch.Elapsed <= stimulationtime)
            {
                printinfo(stopwatch);
                foreach (var item in rls)
                {
                    item._trafficLight.Switch();
                }
           
                foreach (var item in rls2)
                {
                    item._trafficLight.Switch();
                }

                Console.WriteLine();
                Thread.Sleep(1000); // пауза у 1 секунду між ітераціями
            }
        }
    }
}
