using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace PrimeNumberGen
{
    class Program
    {
        static long _startUpTime = 0;
        static void Main(string[] args)
        {
            Manager m = new Manager();
            _startUpTime = (DateTime.Now.Ticks - Process.GetCurrentProcess().StartTime.Ticks);
            Console.WriteLine("Init took  " + _startUpTime.ToString("0000") + " Ticks (I think!)");
            m._startUpTime = _startUpTime;
            m.StartWorkers();
            //  new SubRoutineSpeedTester(1500);
            Console.Read();
        }
    }
}
