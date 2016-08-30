//This file is part of Sequence Studio 2014, an application by Revealed Design, LLC. 
//Copyright© 2014 by Revealed Designs, LLC. All rights reserved. No part of this file may be used without express written permission of Revealed Designs, LLC. 
//No warranties or guarantees are expressed in this document.
//This document does not provide you with any legal rights to any intellectual property in any Revealed Designs, LLC product.


using System;
using System.Collections.Generic;
using System.Text;

namespace SequenceStudio
{
    /// <summary>
    /// This class contains static classes for returing mathmatical series or for testing if a 
    /// given number belongs to a given mathmatical series type.
    /// </summary>
    public class Math
    {
        /// <summary>
        /// Generates a Fibonacci series upto the limit <paramref name="limit"/>.</summary>
        /// <param name="limit">Int32 - the largest number of the returned series.</param>
        /// <returns>List(Int32) - the list of the returned series.</returns>
        public static List<Int32> FibonacciSeries(Int32 limit)
        {
            Int32 fib = 0;
            Int32 fib1 = 0;
            Int32 fib2 = 1;
            List<Int32> fibList = new List<Int32>();

            while (fib < limit)
            {
                fib = fib1 + fib2;
                fibList.Add(fib);
                fib1 = fib2;
                fib2 = fib;
            }
            return fibList;
        }

        /// <summary>
        /// Generates a series of prime numbers upto 'limit'
        /// </summary>
        /// <param name="limit">Int32 - the largest number to return</param>
        /// <returns>List(Int32) - the list of the returned series.</returns>
        public static List<Int32> PrimeSeries(Int32 limit)
        {
            List<Int32> primes = new List<Int32>();
            primes.Add(2);
            Int32 prime = 3;
            Boolean isPrime = true;

            while (prime <= limit)
            {
                Int32 count = primes.Count - 1;
                for (Int32 index = 0; index <= count; index++)
                {
                    if (prime % primes[index] == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    primes.Add(prime);
                    prime += 2;
                }
                else
                {
                    prime += 2;
                    isPrime = true;
                }
            }
            return primes;
        }

        /// <summary>
        /// Returns a Boolean 'true' if the input interger is a prime number
        /// </summary>
        /// <param name="number">Int32 - the number to be examined</param>
        /// <returns>Boolean IsPrime</returns>
        public static bool IsPrime(Int32 number)
        {
            //number += Math.Abs(number);
            if (number < 2) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            List<Int32> primes = new List<Int32>();
            Int32 index = 3;
            bool isPrime = false;
            if (index == number) { return true; }

            while (index != number)
            {
                foreach (Int32 p in primes)
                {
                    if (index % p == 0) { isPrime = true; primes.Add(index); }
                }
                index += 2;
            }
            return isPrime;
        }

        /// <summary>
        /// Generates a string of all the residues at the interval.
        /// </summary>
        /// <param name="seq">String - the DNA, RNA, or Polypeptide sequence</param>
        /// <param name="interval">A list of intergers that define the position at which to grab the residue.</param>
        /// <param name="pattern">ref StringBuilder the resultant sequence.</param>
        public static void NumericalPattern(String seq, List<Int32> interval,
            ref StringBuilder pattern)
        {
            seq = seq.ToUpper();

            Int32 len = seq.Length;
            Int32 index = seq.Length - 1;

            foreach (Int32 loc in interval)
            {
                if (loc <= len)
                {
                    pattern.Append(seq.Substring(loc - 1, 1));
                }
            }
        }

        /// <summary>
        /// Generates a string of all the residues at intervals that follow the Fibonacci numbers upto 'limit'..
        /// </summary>
        /// <param name="seq">String - the DNA, RNA, or Polypeptide sequence</param>
        /// <param name="limit">The largest number (position) to be returned.</param>
        /// <param name="pattern">ref StringBuilder the resultant sequence.</param>
        public static void FibonacciPattern(String seq, Int32 limit, ref StringBuilder pattern)
        {
            seq = seq.ToUpper();

            Int32 len = seq.Length;
            Int32 index = seq.Length - 1;

            if (limit > len) { limit = index; }

            List<Int32> interval = SequenceStudio.Math.FibonacciSeries(limit);

            foreach (Int32 loc in interval)
            {
                if (loc <= len)
                {
                    pattern.Append(seq.Substring(loc - 1, 1));
                }
                else { break; }
            }
        }

        /// <summary>
        /// Generates a string of all the residues at intervals that follow the seies of prime numbers upto 'limit'.
        /// </summary>
        /// <param name="seq">String - the DNA, RNA, or Polypeptide sequence</param>
        /// <param name="limit">The largest number (position) to be returned.</param>
        /// <param name="pattern">ref StringBuilder the resultant sequence.</param>
        public static void PrimePattern(String seq, Int32 limit, ref StringBuilder pattern)
        {
            seq = seq.ToUpper();

            Int32 len = seq.Length;
            Int32 index = seq.Length - 1;

            if (limit > len) { limit = index; }

            List<Int32> interval = SequenceStudio.Math.PrimeSeries(limit);

            foreach (Int32 loc in interval)
            {
                if (loc <= len)
                {
                    pattern.Append(seq.Substring(loc - 1, 1));
                }
                else { break; }

            }
        }

    }

}
