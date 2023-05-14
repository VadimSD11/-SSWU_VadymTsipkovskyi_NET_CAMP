using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_8
{
    internal class TrafficLight
    {
        public enum LightColor
        {
            Red,
            Yellow,
            Green
        }
        public string Name { get; private set; }
        public TimeSpan RedDuration { get; private set; }
        public TimeSpan YellowDuration { get; private set; }
        public TimeSpan GreenDuration { get; private set; }

        public LightColor CurrentColor { get; private set; }

        public void SetColor(LightColor color) { CurrentColor = color; }
        public event Action<LightColor> ColorChanged;

        public TrafficLight()
        {

            CurrentColor = LightColor.Red;
            SetDuration(0.3f, 0.2f, 0.5f);
            this.ColorChanged += HandleColorChanged;

        }
        public TrafficLight(float red, float yellow, float green)
        {
            CurrentColor = LightColor.Red;

            SetDuration(red, yellow, green);
            this.ColorChanged += HandleColorChanged;
        }
        public  TrafficLight DeepCopy()
        {
            TrafficLight light = (TrafficLight)this.MemberwiseClone();
            light.CurrentColor = (LightColor)CurrentColor;
            light.RedDuration = (TimeSpan)RedDuration;
            light.YellowDuration = (TimeSpan)YellowDuration;
            light.GreenDuration = (TimeSpan)GreenDuration;
            light.Name= this.Name;
            return light;
        }
        public void SetName(string s) { Name= s; }
        public virtual void  RunFor(float time)
        {

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed < TimeSpan.FromSeconds(time))
            {
                
                this.Switch();
            }
        }
        public void SetDurationTimespan(TimeSpan red, TimeSpan yellow, TimeSpan green) {
            RedDuration = red;
            YellowDuration = yellow;
            GreenDuration = green;
        }
        public void SetDuration(float red, float yellow, float green)
        {
            RedDuration = TimeSpan.FromSeconds(red);
            YellowDuration = TimeSpan.FromSeconds(yellow);
            GreenDuration = TimeSpan.FromSeconds(green);
        }
        public void SimpleCycle() {
            while (true) { this.Switch(); }

        }
        public virtual void Switch()
        {
            switch (CurrentColor)
            {
                case LightColor.Red:
                    CurrentColor = LightColor.Yellow;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)GreenDuration.TotalSeconds);
                    break;
                case LightColor.Yellow:
                    CurrentColor = LightColor.Green;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)RedDuration.TotalSeconds);
                    break;
                case LightColor.Green:
                    CurrentColor = LightColor.Red;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)YellowDuration.TotalSeconds);
                    break;
            }
        }
        public void HandleColorChanged(LightColor color)
        {
            Console.WriteLine("Color changed to: " + color);
        }
    
        protected virtual void OnColorChanged(LightColor color)
        {
            ColorChanged?.Invoke(color);
        }
    }
}
