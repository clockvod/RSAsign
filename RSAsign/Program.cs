using System;

namespace RSAsign
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateSign();
            CheckSign();
            Console.ReadKey();
        }
        static void CreateSign()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            byte[] hash = FNVHash.Calculate(input);
            Console.WriteLine("Hash: {0}", string.Join(' ', hash));
            RSA rsa = new RSA();
            string sign = rsa.Encrypt(hash);
            Console.WriteLine("Message: {0}", input);
            Console.WriteLine("Sign: {0}", sign);
        }

        static void CheckSign()
        {
            Console.WriteLine();
            Console.WriteLine("Check sign");
            Console.WriteLine("Enter message:");
            string message = Console.ReadLine();

            Console.WriteLine("Enter sign:");
            string sign = Console.ReadLine();

            Console.WriteLine("Open key:");
            Console.WriteLine("Enter e:");
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter r:");
            int r = int.Parse(Console.ReadLine());

            string hash = string.Join(" ", FNVHash.Calculate(message));
            Console.WriteLine("Hash: {0}", hash);


            string[] signNums = sign.Split(' ');
            int[] convertedSign = Array.ConvertAll(signNums, s => int.Parse(s));

            RSA rsa = new RSA();
            string decryptedHash = rsa.Decrypt(convertedSign, e, r);
            Console.WriteLine("Decrypted hash: {0}", decryptedHash);
            if (decryptedHash == hash)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}