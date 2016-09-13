using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace PrimeNumberGen
{
    class SubRoutineSpeedTester
    {
        Stopwatch timer = new Stopwatch();
        float ticks = 0;
        public SubRoutineSpeedTester(double numberOfTests)
        {

            for (int i = 0; i < numberOfTests; i++)
            {
                timer.Start();
                IsNumberPrime(10e20);
                ticks += timer.ElapsedTicks;
                timer.Reset();
            }
            float avg = ticks / (float)numberOfTests;
            long avgInMS = TimeSpan.FromTicks((long)avg).Milliseconds;
            long ticksInMS = TimeSpan.FromTicks((long)ticks).Milliseconds;
            Console.WriteLine("Avg " + avg + " (" + avgInMS.ToString("0.00") + ") took " + ticks + " ticks (" + ticksInMS.ToString("0.00") + ") for " + numberOfTests);


        }

        //Place Here the Methord to test
        double startValue = 100;
        bool IsNumberPrime(double number)//I Don't think there is any other way todo this!
        {
            for (int i = (int)startValue; i < number; i++)
            {

                double sum = number / (double)i;//this apparently "Useless" float cast Acctuly means that this sum acctualy works and doesnt autoround!
                if (sum == Math.Floor(sum))
                {

                    return false;
                }


            }
            return true;
        }
    }
}
