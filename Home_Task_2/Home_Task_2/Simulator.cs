using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Task_2
{
    internal class Simulator
    {// не продумана схема...
        private readonly WaterTower  _waterTower;
        private readonly User _user;
        private readonly Pump _pump;

        public Simulator(WaterTower waterTower, Pump pump, User user)
        {
            _waterTower = waterTower;
            _user = user;
            _pump = pump;
        }
        public void Simulate()
        {
            _user.GetWater(_waterTower);

        }

        public override string? ToString()
        {
            return "This simulator uses WaterTower  in this state: " + "\n" + _waterTower.ToString() + "\n" +
                "with this pump: \n" + _pump.ToString() + "\nand with this user: \n" + _user.ToString();

        }
    }
}
