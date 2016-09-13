using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
namespace PrimeNumberGen
{
    class PrimeWorker
    {

        double maxNumber;
        List<double> foundPrimes = new List<double>();
        int primeCounter = 0;
        Stopwatch timer = new Stopwatch();
        Manager myManager;
        int threadNumber = 0;
        double startValue = 1000;

        public PrimeWorker(int inThreadnumber, double inMaxNumber, Manager manager)
        {
            threadNumber = inThreadnumber;
            myManager = manager;
            maxNumber = inMaxNumber;


        }
        public PrimeWorker(int inThreadnumber, double inStartValue, double inMaxNumber, Manager manager)
            : this(inThreadnumber, inMaxNumber, manager)
        {

            startValue = inStartValue;

        }
        public void StartWorker()
        {
            CalculatePrimes(maxNumber);
            myManager.ThreadEnd(timer.ElapsedTicks, primeCounter, foundPrimes);

        }
        void CalculatePrimes(double maxNumber)
        {
            timer.Start();
            startValue = Math.Floor(startValue);
            for (double i = startValue; i < maxNumber; i++)
            {
                //  Console.WriteLine(startValue +" "+ maxNumber);

                if (IsNumberPrime(i))
                {
                    foundPrimes.Add(i);
                    //  Console.WriteLine("Found prime " + i);
                    primeCounter++;
                }

            }

        }

        public bool IsNumberPrime(double number)//I Don't think there is any other way todo this!
        {
            for (int i = 2; i < number; i++)
            {
                if (i != 1)
                {
                    double sum = number / (double)i;//this apparently "Useless" FLOAT cast acctauly means that this sum works and doesn't autoround! 
                                                    //  Console.WriteLine("Currently Evaluating " + i + " the Sum is " + sum);
                    if (sum == Math.Floor(sum))//is the number the same as the truceted value
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
