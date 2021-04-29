using System;
using System.Collections.Generic;
using System.Text;

namespace RSAsign
{
    class RSA
    {
        int p, q, r, fi, e, d;

        int Gcd(int a, int b, out int x1, out int y1)
        {
            int d0 = a, d1 = b, d2, q;
            int x0 = 1, y0 = 0, x2, y2;
            x1 = 0; y1 = 1;

            while (d1 > 1)
            {
                q = d0 / d1;
                d2 = d0 % d1;
                x2 = x0 - q * x1;
                y2 = y0 - q * y1;
                d0 = d1; d1 = d2;
                x0 = x1; x1 = x2;
                y0 = y1; y1 = y2;
            }
            if (y1 < 0) y1 += a;
            return d1;
        }

        private void SetParams()
        {
            PrimeUtils primeUtils = new PrimeUtils();
            p = primeUtils.GetRandomPrime();
            q = primeUtils.GetRandomPrime();
            r = p * q;
            fi = (p - 1) * (q - 1);
            e = primeUtils.GetRandomCoprime(fi);
            int x1;
            Gcd(fi, e, out x1, out d);

            Console.WriteLine("Open key e:{0} r:{1}.", e, r);
            Console.WriteLine("Secret key d:{0} r:{1}.", d, r);
        }

        public string Encrypt(byte[] message)
        {
            SetParams();
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                if (i != 0)
                    result += " ";
                result += PowerNmod(message[i], d, r);
            }
            return result;
        }
        public string Decrypt(int[] message, int e, int r)
        {
            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                if (i != 0)
                    result += " ";
                result += PowerNmod(message[i], e, r);
            }
            return result;
        }

        private int PowerNmod(int number, int power, int delimeter)
        {
            int result = 1;
            while (power > 0)
            {
                if (power % 2 == 1)
                {
                    result = result * number % delimeter;
                    power--;
                }
                else
                {
                    number = number * number % delimeter;
                    power /= 2;
                }
            }
            return result;
        }
    }
}