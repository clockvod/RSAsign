using System;
using System.Collections.Generic;
using System.Text;

namespace RSAsign
{
    public static class FNVHash
    {
        static uint prime = 0x811C9DC5;

        public static byte[] Calculate(string input)
        {
            uint hash = 0;
            for (int i = 0; i < input.Length; i++)
            {
                hash *= prime;
                hash ^= (byte)input[i];
            }
            return BitConverter.GetBytes(hash);
        }
    }
}