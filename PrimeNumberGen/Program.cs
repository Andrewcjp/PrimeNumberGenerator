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
        static long startUpTime;
        static void Main(string[] args)
        {
            Stopwatch s = new Stopwatch();

            s.Start();
            Manager m = new Manager();
            startUpTime = (DateTime.Now.Ticks - Process.GetCurrentProcess().StartTime.Ticks);
            Console.WriteLine("Init took  " + startUpTime.ToString("0000") + " Ticks (I think!)");
            m._startUpTime = startUpTime;

            m.StartWorkers();
            //     System.Threading.Thread.Sleep(100);
            //    PrimeSaver saver = new PrimeSaver(m.Primes);
            //  new SubRoutineSpeedTester(1500);
            Console.Read();
        }
    }
}
