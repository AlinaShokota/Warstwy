using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ActualTemperature
    {
        public double BedroomTemperature = generateActualTemp();
        public double LivingroomTemperature = generateActualTemp();

        private static Random rnd = new Random();
        private static double generateActualTemp()
        {
            
            return rnd.Next(18, 30);
        }


        private Random rnd2 = new Random();
        public void updateBedroomTemp()
        {
            Console.WriteLine("updating bedroom temperature ...");
            if (BedroomTemperature < 16 || BedroomTemperature > 30)
            {
                updateBedroomTemp();
            }
            int a = rnd2.Next(0,100);
            if (a > 50)
            {
                BedroomTemperature += 0.1;
            }
            else
            {
                BedroomTemperature -= 0.1;
            }
        }

        public void updateLivingroomTemp()
        {
            Console.WriteLine("updating livingroom temperature ...");

            if (LivingroomTemperature < 16 || LivingroomTemperature > 30)
            {
                updateLivingroomTemp();
            }
            int a = rnd2.Next(0, 100);
            if (a > 50)
            {
                LivingroomTemperature += 0.1;
            }
            else
            {
                LivingroomTemperature -= 0.1;
            }
        }

    }
}
