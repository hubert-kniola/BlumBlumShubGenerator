using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BBSGen
{
    static class BlumBlumSnub
    {
        public static readonly BigInteger p = 300091;
        public static readonly BigInteger q = 400003;
        public static readonly BigInteger N = p * q;

        public static BigInteger nextBit(BigInteger previous)
        {
            return (previous * previous) % N;
        }

        /*public static int parity(BigInteger n)
        {
            BigInteger q = n;
            BigInteger count = 0;
            while (q != BigInteger.Zero)
            {
                count += q & BigInteger.One;
                q >>= 1;
            }

            if ((count & BigInteger.One) != BigInteger.Zero)
                return 1;
            else
                return 0;
        }*/

        public static int leastSB(BigInteger n)
        {
            if ((n & BigInteger.One) != BigInteger.Zero)
                return 1;
            else
                return 0;
        }
 
        public static void generatorBBS()
        {
            BigInteger seed = findPrimeNumber(9000000000);
            var sizeString = 20000;
            
            Console.WriteLine($"Dane:\nseed = {seed}\nsize = {sizeString}\np = {p}\nq = {q}\nN = {N}");

            Console.WriteLine("BlumBlumSnub: ");
            var bbsList = new List<int>();
            BigInteger xprev = seed;
            for(int i=0; i<sizeString-1; i++)
            {
                BigInteger xnext = nextBit(xprev);
                int bit = leastSB(xnext);
                bbsList.Add(bit);
                xprev = xnext;
            }
            Console.WriteLine();

            Tests.SBTest(bbsList);
            Tests.LSTest(bbsList);
            Tests.SeriesTest(bbsList);
            Tests.PokerTest(bbsList);
        }

        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException();
        }

        static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        public static bool isPrime(BigInteger n)
        {
            if (n <= 0) throw new IOException();
            if (n == 1 || n == 2) return true;
            if (n % 2 == 0) return false;
            for (BigInteger i = 3; i < Sqrt(n); i++)
            {
                if (BigInteger.GreatestCommonDivisor(i, n) == i)
                    return false;
            }
            return true;
        }

        public static BigInteger findPrimeNumber(BigInteger min)
        {
            BigInteger primeNumber = 0;
            BigInteger temp;
            BigInteger check = 3;

            if (min % 2 == 0)
                temp = min + 1;
            else
                temp = min;
            bool flag = true;
            do
            {
                if (isPrime(temp) == true)
                    primeNumber = temp;
                else
                {
                    temp += 2;
                }
            } while (primeNumber == 0);
            return primeNumber;
        }
    }
}
