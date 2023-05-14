using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class Road
    {
       private List<RoadLane> laneList;
        
        public Road()
        {
            TrafficLight _northSouth = new TrafficLight();
            TrafficLight _southNorth = new TrafficLight();
            _northSouth.SetDuration(0.50f, 0.5f, 0.7f);
            _northSouth.SetName("North-South Light");
            _southNorth.SetDuration(0.50f, 0.5f, 0.7f);
            _northSouth.SetName("South-North Light");

            RoadLane northsouthrl = new RoadLane(_northSouth);
            RoadLane southnorthrl = new RoadLane(_southNorth);
            laneList = new List<RoadLane>();
            laneList.Add(northsouthrl);
            laneList.Add(southnorthrl);
        }
        public Road Deepcopy() { 
            Road road=(Road)this.MemberwiseClone();
            road.laneList = this.laneList;
            return road;
        
        }
        public RoadLane[] GetRoadLanes() { 
        return laneList.ToArray();
        }
        public Road(RoadLane rl1,RoadLane rl2)
        {
            laneList = new List<RoadLane>();
            laneList.Add(rl1);
            laneList.Add(rl2);

        }
        public Road(RoadLane rl1, RoadLane rl2,RoadLane rl3)
        {
            laneList = new List<RoadLane>();
            laneList.Add(rl1);
            laneList.Add(rl2);
            laneList.Add(rl3);

        }
        public Road(RoadLane rl1, RoadLane rl2,RoadLane rl3,RoadLane rl4)
        {
            laneList = new List<RoadLane>();
            laneList.Add(rl1);
            laneList.Add(rl2);
            laneList.Add(rl3);
            laneList.Add(rl4);

        }
        

    }
}
