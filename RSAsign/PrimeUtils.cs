using System;
using System.Collections.Generic;
using System.Text;

namespace RSAsign
{
    class PrimeUtils
    {
        int[] primes = new int[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101,
            103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
            233, 239, 241, 251, 257, 263, 269 };

        public int GetRandomPrime()
        {
            Random rnd = new Random();
            return primes[rnd.Next(primes.Length - 1)];
        }
        private bool IsCoprime(int a, int b)
        {
            return a == b ? a == 1 : a > b ? IsCoprime(a - b, b) : IsCoprime(b - a, a);
        }

        public int GetRandomCoprime(int src)
        {
            List<int> coprimes = new List<int>();
            for (int i = 2; i < src; i++)
                if (IsCoprime(i, src)) coprimes.Add(i);
            Random rnd = new Random();
            return coprimes[rnd.Next(coprimes.Count - 1)];
        }
    }
}