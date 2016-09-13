using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumberGen
{
    class PrimeSaver
    {
        string Filename = "Primes.txt";
        List<double> Primes = new List<double>();
        public PrimeSaver(List<double> primelist)
        {
            Primes = primelist;
            Save();
        }
        void Save()
        {

            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + Filename,false);
            
            Console.WriteLine("writeing "+Primes.Count+" to " + Environment.CurrentDirectory + Filename);
            foreach(double p in Primes)
            {
                sw.WriteLine(p);
                
            }
            sw.Close();
        }
    }
}
