using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
namespace PrimeNumberGen
{
    class Manager
    {
        int _primeCounter = 0;
        public long _startUpTime = 0;
        List<Thread> _workers = new List<Thread>();
        List<double> _primes = new List<double>();
        //Here lies the Hardcoded number of threads used!
        int _numberOfThreads = 1;
        int _endedThreads = 0;
        Verifier _verifier = new Verifier();
        double _totalMS = 0;
        public Manager()
        {
            StartThreads(50, 1e5);
        }


        public List<double> Primes
        {
            get
            {
                return _primes;
            }

        }

        public void ThreadEnd(long total, double numberOfPrimes, List<double> primesfound)
        {
            lock (this)
            {
                _primes.AddRange(primesfound);
                Console.WriteLine("Thread " + (_endedThreads) + " Ended");
                _primeCounter += (int)numberOfPrimes;
                _totalMS += total;
                _endedThreads++;
                if (_endedThreads == _numberOfThreads)
                {

                    _totalMS = TimeSpan.FromTicks(total).Milliseconds;
                    double avg = _totalMS / (double)_primeCounter;
                    Console.WriteLine("After Generating " + _primeCounter + "  Primes It took " + (_totalMS) + "MS and init took " + TimeSpan.FromTicks(_startUpTime).Milliseconds + "MS With and avg of " + avg + "MS Per Prime");
                    new PrimeSaver(_primes);
                    double precent;
                    _verifier.Verify(Primes, out precent);
                    Console.WriteLine("Verifercation complete with " + precent.ToString("0.00") + "%");
                }

            }
        }

        void StartThreads(int threads, double maxNumber, int startValue = 2)
        {
            _numberOfThreads = threads;
            //split the range of numbers into chunks for each thread to process
            double subsection = (maxNumber - startValue) / threads;
            double currentStartValue = startValue;
            double currentMaxValue = maxNumber;
            for (int i = 0; i < threads; i++)
            {
                currentMaxValue = currentStartValue + subsection;
                Console.WriteLine("Starting Primes worker " + i + " with constraints of " + currentStartValue + " and " + currentMaxValue);
                PrimeWorker worker = new PrimeWorker(i, currentStartValue, currentMaxValue, this);
                Thread worker1 = new Thread(new ThreadStart(worker.StartWorker));
                _workers.Add(worker1);
                currentStartValue += subsection;
            }
        }
        public void StartWorkers()
        {
            _totalMS = _startUpTime;
            foreach (Thread w in _workers)
            {
                w.Start();
            }
        }


    }

}
