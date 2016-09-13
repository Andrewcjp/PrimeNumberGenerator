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
        Stopwatch _timer = new Stopwatch();
        float _ticks = 0;
        public SubRoutineSpeedTester(double numberOfTests)
        {

            for (int i = 0; i < numberOfTests; i++)
            {
                _timer.Start();
                IsNumberPrime(10e20);
                _ticks += _timer.ElapsedTicks;
                _timer.Reset();
            }
            float avg = _ticks / (float)numberOfTests;
            long avgInMS = TimeSpan.FromTicks((long)avg).Milliseconds;
            long ticksInMS = TimeSpan.FromTicks((long)_ticks).Milliseconds;
            Console.WriteLine("Avg " + avg + " (" + avgInMS.ToString("0.00") + ") took " + _ticks + " ticks (" + ticksInMS.ToString("0.00") + ") for " + numberOfTests);
        }

        //Place Here the method to test
        double _startValue = 100;
        bool IsNumberPrime(double number)//I Don't think there is any other way todo this!
        {
            for (int i = (int)_startValue; i < number; i++)
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
