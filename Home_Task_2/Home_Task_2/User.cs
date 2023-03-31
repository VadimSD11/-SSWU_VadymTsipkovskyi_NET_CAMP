using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_2
{
    internal class User
    {
        private double _consumption;

        private double _using = 0;
        public User(double consumption)
        {
            if (consumption < 0)
            {
                this._consumption = Math.Abs(consumption);
            }
            else { this._consumption = consumption; }
        }
        public void GetWater(WaterTower waterTower)
        {
            do
            {
                Console.WriteLine(ToString());
                _using += waterTower.GiveWater();// Method increases _using by fixed amount of water from waterTower

            }
            while (this._using < this._consumption);

            if (this._using >= this._consumption) { this._using = this._consumption; Console.WriteLine(ToString()); }


        }
        public override string? ToString()
        {
            if (this._using == this._consumption) { return "This user already got all the needed water ( " + _using + "ml out of " + _consumption + "ml)"; }

            return "This user has need of " + _consumption + "ml of water and this user hase already got " + _using + "ml of it";

        }
    }
}
