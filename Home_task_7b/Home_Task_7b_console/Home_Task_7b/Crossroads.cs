using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_7b
{
    public class Crossroads
    {
        public TrafficLight _northSouth;
        public TrafficLight _southNorth;
        public TrafficLight _westEast;
        public TrafficLight _eastWest;
        private TimeSpan stimulationStart;
        private TimeSpan stimulationEnd;

        private TimeSpan stimulationtime;



        public Crossroads()
        {
           
            _northSouth = new TrafficLight();
            _southNorth = new TrafficLight();
            _westEast = new TrafficLight();
            _eastWest = new TrafficLight();
            
            _northSouth.SetDuration(0.50f, 0.5f, 0.7f);
            _southNorth.SetDuration(0.50f, 0.5f, 0.7f);
            _westEast.SetDuration(0.50f, 0.2f, 0.7f);
            _eastWest.SetDuration(0.50f, 0.2f, 0.7f);
            
            _westEast.SetColor(TrafficLight.LightColor.Green);
            _eastWest.SetColor(TrafficLight.LightColor.Green);

            stimulationStart = TimeSpan.FromSeconds(0);
            stimulationEnd = TimeSpan.FromSeconds(6);
            stimulationtime = stimulationEnd - stimulationStart;
          
        }
        public Crossroads(float start, float end) {
            _northSouth = new TrafficLight();
            _southNorth = new TrafficLight();
            _westEast = new TrafficLight();
            _eastWest = new TrafficLight();
          
            _northSouth.SetDuration(0.50f, 0.5f, 0.7f);
            _southNorth.SetDuration(0.50f, 0.5f, 0.7f);
            _westEast.SetDuration(0.50f, 0.2f, 0.7f);
            _eastWest.SetDuration(0.50f, 0.2f, 0.7f);
            
            _westEast.SetColor(TrafficLight.LightColor.Green);
            _eastWest.SetColor(TrafficLight.LightColor.Green);

            stimulationStart =TimeSpan.FromSeconds(start);
            stimulationEnd=TimeSpan.FromSeconds(end+1);
            stimulationtime=stimulationEnd-stimulationStart;

        }
        public Crossroads(TrafficLight northSouth, TrafficLight southNorth, TrafficLight westEast, TrafficLight eastWest, float stimulationStart1,float stimulationEnd1)
        {
            _northSouth = northSouth.DeepCopy();
            _southNorth = southNorth.DeepCopy();
            _westEast = westEast.DeepCopy();
            _eastWest = eastWest.DeepCopy();
            _westEast.SetColor(TrafficLight.LightColor.Green);
            _eastWest.SetColor(TrafficLight.LightColor.Green);

            this.stimulationStart = TimeSpan.FromSeconds( stimulationStart1);
            this.stimulationEnd = TimeSpan.FromSeconds(stimulationEnd1+1);
            this.stimulationtime = (stimulationEnd-stimulationStart);
        }

        public void SetNorthenLighttime(float red, float yellow, float green) {
            _northSouth.SetDuration(red, yellow, green);
        }
        public void SetSoutherLighttime(float red, float yellow, float green)
        {
            _southNorth.SetDuration(red, yellow, green);
        }
        public void SetWestLighttime(float red, float yellow, float green)
        {
            _westEast.SetDuration(red, yellow, green);
        }
        public void SetEastLighttime(float red, float yellow, float green)
        {
            _eastWest.SetDuration(red, yellow, green);
        }
        public void printinfo(Stopwatch stopwatch) {
            Console.WriteLine($"t={stopwatch.Elapsed.TotalSeconds:N0} с");
            Console.WriteLine($"Світлофор  Північ-південь  Південь-північ    Схід-захід    Захід-схід\nКолір: \t\t{_northSouth.CurrentColor}\t\t{_southNorth.CurrentColor}\t\t{_eastWest.CurrentColor}\t\t{_westEast.CurrentColor}");

        }
        public void StartSimulation()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.Elapsed <= stimulationtime)
            {
               printinfo(stopwatch);
                _northSouth.Switch();
                _southNorth.Switch();
                _westEast.Switch();
                _eastWest.Switch();
                
                Console.WriteLine();
                Thread.Sleep(1000); // пауза у 1 секунду між ітераціями
            }
        }

        //private void _northSouth_ColorChanged(TrafficLight.LightColor obj)
        //{
        //    throw new NotImplementedException();
        //}
        //private void _southNorth_ColorChanged(TrafficLight.LightColor obj)
        //{
        //    throw new NotImplementedException();
        //}
        //private void _westEast_ColorChanged(TrafficLight.LightColor obj)
        //{
        //    throw new NotImplementedException();
        //}
        //private void _eastWest_ColorChanged(TrafficLight.LightColor obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
