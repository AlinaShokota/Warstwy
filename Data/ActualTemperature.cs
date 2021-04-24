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


        private  Random rnd2 = new Random();
        public void updateBedroomTemp(double GoalBedroomTemperature)
        {
            Console.WriteLine("goal "+ GoalBedroomTemperature);
            Console.WriteLine("actual " + BedroomTemperature);
            if (GoalBedroomTemperature == 0 || Math.Round(GoalBedroomTemperature,1)== Math.Round(BedroomTemperature,1))
            {
                Console.WriteLine("updating bedroom temperature ...");
                if (BedroomTemperature < 16 || BedroomTemperature > 30)
                {
                    updateBedroomTemp(GoalBedroomTemperature);
                }
                int a = rnd2.Next(0, 100);
                if (a > 50)
                {
                    BedroomTemperature += 0.1;
                }
                else
                {
                    BedroomTemperature -= 0.1;
                }
            }
            else
            {
                if (BedroomTemperature < GoalBedroomTemperature)
                {
                    BedroomTemperature += 0.1;
                }
                else if (BedroomTemperature > GoalBedroomTemperature)
                {
                    BedroomTemperature -= 0.1;
                }
                else
                {

                }
            }
            
        }

        public void updateLivingroomTemp(double GoalLivingroomTemperature)
        {
            Console.WriteLine("goal " + GoalLivingroomTemperature);
            Console.WriteLine("actual " + LivingroomTemperature);
            if (GoalLivingroomTemperature == 0 || Math.Round(GoalLivingroomTemperature, 1) == Math.Round(LivingroomTemperature, 1))
            {
                Console.WriteLine("updating livingroom temperature ...");

                if (LivingroomTemperature < 16 || LivingroomTemperature > 30)
                {
                    updateLivingroomTemp(GoalLivingroomTemperature);
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
            else
            {
                if (LivingroomTemperature < GoalLivingroomTemperature)
                {
                    LivingroomTemperature += 0.1;
                }
                else if (LivingroomTemperature > GoalLivingroomTemperature)
                {
                    LivingroomTemperature -= 0.1;
                }
                else
                {

                }
            }
        }

            /*public void changeBedroomTemp(double goal)
            {
                Console.WriteLine("in ACTUALTEMP" + goal);
                GoalBedroomTemperature = goal;
                Console.WriteLine("in ACTUALTEMP GoalBedroomTemperature " + GoalBedroomTemperature);
                 if (BedroomTemperature < goal)
                 {
                     BedroomTemperature += 0.1;
                 }
                 else if (BedroomTemperature > goal)
                 {
                     BedroomTemperature -= 0.1;
                 }
                 else
                 {

                 }
            }

            public void changeLivingroomTemp(double goal)
            {
                Console.WriteLine("in ACTUALTEMP" + goal);
                if (LivingroomTemperature < goal)
                {
                    LivingroomTemperature += 0.3;
                }
                else if (LivingroomTemperature > goal)
                {
                    LivingroomTemperature -= 0.3;
                }
                else
                {

                }
            }*/

        }
}
