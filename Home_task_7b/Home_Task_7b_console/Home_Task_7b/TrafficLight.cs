using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Timers;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel;

namespace Home_Task_7b
{
    public class TrafficLight
    {
        public enum LightColor
        {
            Red,
            Yellow,
            Green
        }

        //Час горіння кожного кольору світлафора
        public TimeSpan RedDuration { get; private set; }
        public TimeSpan YellowDuration { get; private set; }
        public TimeSpan GreenDuration { get; private set; }

        // колір світлофору
        public LightColor CurrentColor { get; private set; }

        public void SetColor(LightColor color) { CurrentColor = color; }
        public event Action<LightColor> ColorChanged;

        // конструктор класса
        public TrafficLight() { 

            CurrentColor= LightColor.Red;
            SetDuration(0.3f, 0.2f, 0.5f);

        }
        public TrafficLight(float red, float yellow, float green) { 
            CurrentColor = LightColor.Red;
            
            SetDuration(red, yellow, green);
        }
        public TrafficLight DeepCopy() {
            TrafficLight light = (TrafficLight)this.MemberwiseClone();
            light.CurrentColor = (LightColor)CurrentColor;
            light.RedDuration = (TimeSpan)RedDuration;
            light.YellowDuration = (TimeSpan)YellowDuration;
            light.GreenDuration = (TimeSpan)GreenDuration;
            return light;
        }

        // метод вставновлення часу горіння кольорів світлофора
        public void SetDuration(float red, float yellow, float green)
        {
            RedDuration = TimeSpan.FromSeconds(red);
            YellowDuration =TimeSpan.FromSeconds( yellow);
            GreenDuration = TimeSpan.FromSeconds(green);
        }

        // зміна кольору
        public void Switch()
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

        //виклик події зміни кольору
        protected virtual void OnColorChanged(LightColor color)
        {
            ColorChanged?.Invoke(color);
        }
    }
}

