using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class RoadLane
    {
        public TrafficLight _trafficLight { get; private set; }
        public RoadLane()
        {

        }
        public RoadLane DeepCopy() {

            RoadLane rl = (RoadLane)this.MemberwiseClone();
            rl._trafficLight=this._trafficLight.DeepCopy();
            return rl;
        }
        public RoadLane(TrafficLight tl)
        {
            _trafficLight=tl.DeepCopy();
        }
        public RoadLane(TrafficLightWithTurnRegulation tlr1) { 
            _trafficLight = tlr1.DeepCopy();
        }
    }
}
