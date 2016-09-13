using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrimeNumberGen
{
    class Verifier
    {
        List<double> _primesFromFile = new List<double>();

        public Verifier()
        {
            StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Primes1000.txt");
            string data = streamReader.ReadToEnd();
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                _primesFromFile.Add(ParseToDouble(line));
            }
        }

        private double ParseToDouble(string line)
        {
            double result = 0;
            double.TryParse(line, out result);
            if (result == 0)
            {
                Console.WriteLine("ERROR: Failed to parse " + line);
            }
            return result;
        }

        public bool Verify(List<double> primes, out double percent)
        {
            double correctValues = 0;
            int primesToVerify = 175;
            if (primes.Count > _primesFromFile.Count)
            {
                primesToVerify = _primesFromFile.Count;
            }
            else
            {
                primesToVerify = primes.Count;
            }
            double previousPrime = 0;
            for (int i = 0; i < primesToVerify; i++)
            {
                //check for duplication of primes
                if (primes[i] == previousPrime)
                {
                    Console.WriteLine("Duplicated prime " + primes[i]);
                }
                previousPrime = primes[i];
                if (primes.Contains(_primesFromFile[i]))
                {
                    correctValues++;
                }
                else
                {
                    Console.WriteLine("Unable to Verify " + _primesFromFile[i]);
                }
            }
            percent = (correctValues / primesToVerify) * 100;
            return true;
        }
    }
}
