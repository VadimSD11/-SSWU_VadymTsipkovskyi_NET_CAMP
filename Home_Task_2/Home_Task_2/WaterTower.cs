using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_2
{
    internal class WaterTower
    {
        private readonly double _maxLevelWater;
        private double _curentLevel = 0;
        private readonly Pump _pump;
        public WaterTower(double maxLevelWater, Pump pump)
        {
            if (maxLevelWater < 0) { this._maxLevelWater=Math.Abs(maxLevelWater); }
            this._maxLevelWater = maxLevelWater;
            this._pump = pump;
        }
        public void AutoGainWater()
        {
            if (_curentLevel <= 0)
            {
                if (_pump.IsOn)
                {
                    while (_curentLevel < _maxLevelWater)
                    {
                        _curentLevel += _pump.ToPump();
                        if (_curentLevel >= _maxLevelWater) { _curentLevel = _maxLevelWater; }
                    }

                }
                else { _pump.ChangeState(); }
            }
        }

        public double GiveWater()
        {
            if (_curentLevel <= 0) { AutoGainWater(); }
            Console.WriteLine(ToString());
            _curentLevel -= _pump.ToPump();

            return _pump.ToPump();
        }
        public override string? ToString()
        {
            return "This WaterTower maximum level of water is" + _maxLevelWater + ". Now it's water level is " + _curentLevel + ".";
        }
    }
}
