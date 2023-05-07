using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_7b_windowsformsapp
{
    internal class TrafficLight
    {


        //Час горіння кожного кольору світлафора
        public TimeSpan RedDuration { get; private set; }
        public TimeSpan YellowDuration { get; private set; }
        public TimeSpan GreenDuration { get; private set; }

        // колір світлофору
        public Color CurrentColor { get; private set; }

        public void SetColor(Color color) { CurrentColor = color; }
        public event Action<Color> ColorChanged;

        // конструктор класса
        public TrafficLight()
        {

            CurrentColor = Color.Red;
            SetDuration(0.3f, 0.2f, 0.5f);

        }
        public TrafficLight(float red, float yellow, float green)
        {
            CurrentColor = Color.Red;

            SetDuration(red, yellow, green);
        }
        public TrafficLight DeepCopy()
        {
            TrafficLight light = (TrafficLight)this.MemberwiseClone();
            light.CurrentColor = (Color)CurrentColor;
            light.RedDuration = (TimeSpan)RedDuration;
            light.YellowDuration = (TimeSpan)YellowDuration;
            light.GreenDuration = (TimeSpan)GreenDuration;
            return light;
        }

        // метод вставновлення часу горіння кольорів світлофора
        public void SetDuration(float red, float yellow, float green)
        {
            RedDuration = TimeSpan.FromSeconds(red);
            YellowDuration = TimeSpan.FromSeconds(yellow);
            GreenDuration = TimeSpan.FromSeconds(green);
        }

        // зміна кольору
        public void Switch()
        {
      
            while (true) {
                if (CurrentColor == Color.Red) {
                    CurrentColor = Color.Yellow;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)GreenDuration.TotalSeconds);
                    break;
                }
                if (CurrentColor == Color.Yellow) {
                    CurrentColor = Color.Green;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)RedDuration.TotalSeconds);
                    break;
                }
                if(CurrentColor == Color.Green)
                {
                    CurrentColor = Color.Red;
                    OnColorChanged(CurrentColor);
                    System.Threading.Thread.Sleep((int)YellowDuration.TotalSeconds);
                    break;
                }
            }
           
        }

        //виклик події зміни кольору
        protected virtual void OnColorChanged(Color color)
        {
            ColorChanged?.Invoke(color);
        }
    }
}
