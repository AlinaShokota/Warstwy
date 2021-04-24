using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Sensor
    {
        private ActualTemperature actual = new ActualTemperature();

        public double getActualTemperature(string room, double goal)
        {
            if (room.Equals("bedroom"))
            {
                actual.updateBedroomTemp(goal);
                return actual.BedroomTemperature;
            }
            else if (room.Equals("livingroom"))
            {
                actual.updateLivingroomTemp(goal);
                return actual.LivingroomTemperature;
            }
            else
            {
                return 0;
            }
            
            
        }
    }
}
