using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class TrafficLightWithTurnRegulation:TrafficLight
    {
        private bool _turnRegulation=false;
        private TimeSpan _turnRegulationInterval;
        public event Action<bool> TurnWorks;
        private Stopwatch _stopwatch=new Stopwatch();
        public TrafficLightWithTurnRegulation():base()
        {
            _turnRegulationInterval = TimeSpan.FromSeconds(5);
            this.TurnWorks += OnTurnWorks;
        }
        public TrafficLightWithTurnRegulation(float time,float red,float yellow,float green):base(red,yellow,green)
        {
            _turnRegulationInterval = TimeSpan.FromSeconds(time);
            this.TurnWorks += OnTurnWorks;

        }
        public TrafficLightWithTurnRegulation DeepCopy() {
         

            TrafficLightWithTurnRegulation tltr = (TrafficLightWithTurnRegulation)this.MemberwiseClone();
            tltr._turnRegulationInterval=this._turnRegulationInterval;
            tltr.SetDurationTimespan(this.RedDuration,this.YellowDuration,this.GreenDuration);
            tltr.SetColor(this.CurrentColor);
            return tltr;
        }
        public override void Switch()
        {
            _stopwatch.Start();
            if (_stopwatch.Elapsed < this._turnRegulationInterval)
            {

                Task.Run(() => { this.StartTurnRegulation(); });
            }
            else
            {
                Task.Run(() => { this.StopTurnRegulation(); });
                switch (CurrentColor)
                {
                    case LightColor.Red:
                        this.SetColor(LightColor.Yellow);
                        OnColorChanged(CurrentColor);
                        System.Threading.Thread.Sleep((int)GreenDuration.TotalSeconds);
                        break;
                    case LightColor.Yellow:
                        this.SetColor(LightColor.Green);
                        OnColorChanged(CurrentColor);
                        System.Threading.Thread.Sleep((int)RedDuration.TotalSeconds);
                        break;
                    case LightColor.Green:
                        this.SetColor(LightColor.Red);
                        OnColorChanged(CurrentColor);
                        System.Threading.Thread.Sleep((int)YellowDuration.TotalSeconds);
                        break;
                }

            }
        }
        public override void RunFor(float time)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
            {
                this.Switch();
                if(stopwatch.Elapsed < _turnRegulationInterval) { 
                StartTurnRegulation();

                }
                else { StopTurnRegulation(); }
            }
        }
        public void StartTurnRegulation() {
         _turnRegulation = true;
            OnTurnWorks(_turnRegulation);

        }
        public void StopTurnRegulation()
        {
            _turnRegulation = false;
            OnTurnWorks(_turnRegulation); 
          
        }
        protected virtual void OnTurnWorks(bool isWorking)
        {
            if (isWorking)
            {
                if (this.Name != null)
                    Console.Write(this.Name + "'s " + "Turn works.\t");
                else { Console.Write("Turn works"); }
            }
            else
            {
                if(this.Name!=null)
                Console.Write(this.Name+"'s "+"Turn doesn't work.\t");
                else { Console.Write("Turn doesn't work"); }
            }
        }
    }
}
