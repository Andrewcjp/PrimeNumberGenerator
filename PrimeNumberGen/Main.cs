using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace PrimeNumberGen
{
    class Main
    {
        //   int[] FoundPrimes;
        List<int> FoundPrimes = new List<int>();
        int primeCounter = 0;
        Stopwatch timer = new Stopwatch();
        Stopwatch perPrimetimer = new Stopwatch();
        double perPrimeTime = 0;
        int startNumber = 1;
        public Main()
        {
            Console.WriteLine(IsNumberPrime(6));
            CalculatePrimes(2000, 10000);
            Console.WriteLine("After Generating " + primeCounter + "  Primes It took " + timer.ElapsedMilliseconds + "MS With and avg of " + perPrimeTime + "MS Per Prime");
        }
        void CalculatePrimes(double MaxNumber, double TargetNumberOfPrimes)
        {
            timer.Start();
            perPrimetimer.Start();
            //FoundPrimes = new int[MaxNumber];
            for (int i = startNumber; i < MaxNumber; i++)
            {
                if (primeCounter >= TargetNumberOfPrimes)
                {
                    timer.Stop();
                    perPrimetimer.Stop();
                    return;
                }
                if (IsNumberPrime(i))
                {

                    FoundPrimes.Add(i);
                    primeCounter++;
                    ReportSpeed();

                }

            }
            timer.Stop();
            perPrimetimer.Stop();
            //  PrintArray();
        }
        void ReportSpeed()
        {
            Console.Clear();

            if (timer.ElapsedMilliseconds > 0)
            {
                perPrimeTime = timer.ElapsedMilliseconds / (double)primeCounter;
            }
            Console.WriteLine("I have found " + primeCounter + " Primes In " + timer.ElapsedMilliseconds + " MS Taking :" + perPrimeTime + " MS perPrime");
            perPrimetimer.Reset();
        }
        void PrintArray()
        {
            Console.WriteLine("I found Primes:");
            foreach (int i in FoundPrimes)
            {
                Console.WriteLine(i);
            }

        }
        bool IsNumberPrime(float Number)//count up method 
        {
            for (int i = 2; i < Number; i++)
            {
                if (i != 1 || i != 5)
                {
                    float Sum = Number / (float)i;
                    //   Console.WriteLine("Currently Evaluating " + i + " the Sum is " + Sum);
                    if (Sum == Math.Floor(Sum))
                    {
                        //     Console.WriteLine("Number is whole there for Not A Prime!");
                        return false;
                    }
                }
            }
            //  Console.WriteLine(Number +" Is a Prime!");
            return true;
        }
    }
}
