using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_2
{
    internal class Pump
    {
        private readonly double _power;
        private bool isOn = false;
        public bool IsOn
        {
            set { isOn = value; }
            get { return isOn; }
        }
        public Pump(double power)
        {
            if (power < 0)
            {
                this._power = Math.Abs(power);
            }
            else { this._power = power; }
        }
        public void ChangeState()
        {
            if (this.isOn == false) {  this.IsOn = true; } else { this.IsOn = false; }   //change isOn value
        }
        public double ToPump()
        {

            return _power * 10;
        }
        public override string? ToString()
        {
            string c;
            if (IsOn) { c = "right now it works"; } else { c = "right now it doesn't work"; }
            return "This pump's power is " + _power + " and " + c;
        }
    }
}
