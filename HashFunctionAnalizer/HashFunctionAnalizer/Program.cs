using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;
using System.Text;

namespace HashFunctionAnalizer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var stopwatchSHA1 = new Stopwatch();
            var stopwatchSHA224 = new Stopwatch();
            var stopwatchSHA256 = new Stopwatch();
            var stopwatchSHA384 = new Stopwatch();
            var stopwatchSHA512 = new Stopwatch();

            byte[] data = { 0, 0, 5, 1 };
            string word = "abc";
            Sha1 hash = new Sha1();
            stopwatchSHA1.Start();
            Console.WriteLine("Proper HASH SHA1(data): " + UintArrayToString(hash.Hash(data)));
            stopwatchSHA1.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA1.Elapsed} s");
            stopwatchSHA1.Reset();
            stopwatchSHA1.Start();
            Console.WriteLine("Proper HASH SHA1 (word): " + UintArrayToString(hash.Hash(Encoding.ASCII.GetBytes(word))));
            stopwatchSHA1.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA1.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatchSHA1.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 1000000 / stopwatchSHA1.Elapsed.Ticks} bps");


            Sha224 hash1 = new Sha224();
            stopwatchSHA224.Start();
            Console.WriteLine("Proper HASH SHA224(data): " + UintArrayToString(hash1.Hash(data)));
            stopwatchSHA224.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA224.Elapsed} s");
            stopwatchSHA224.Reset();
            stopwatchSHA224.Start();
            Console.WriteLine("Proper HASH SHA224 (word): " + UintArrayToString(hash1.Hash(Encoding.UTF8.GetBytes(word))));
            stopwatchSHA224.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA224.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatchSHA224.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 10000000 / stopwatchSHA224.Elapsed.Ticks} bps");

            Sha256 hash2 = new Sha256();
            stopwatchSHA256.Start();
            Console.WriteLine("Proper HASH SHA256(data): " + UintArrayToString(hash2.Hash(data)));
            stopwatchSHA256.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA256.Elapsed} ms");
            stopwatchSHA256.Reset();
            stopwatchSHA256.Start();
            Console.WriteLine("Proper HASH SHA256 (word): " + UintArrayToString(hash2.Hash(Encoding.UTF8.GetBytes(word))));
            stopwatchSHA256.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA256.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatchSHA256.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 10000000 / stopwatchSHA256.Elapsed.Ticks} bps");

            Sha384 hash4 = new Sha384();
            stopwatchSHA384.Start();
            Console.WriteLine("Proper HASH SHA384(data): " + UlongArrayToString(hash4.Hash(data)));
            stopwatchSHA384.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA384.Elapsed} s");
            stopwatchSHA384.Reset();
            stopwatchSHA384.Start();
            Console.WriteLine("Proper HASH SHA384 (word): " + UlongArrayToString(hash4.Hash(Encoding.UTF8.GetBytes(word))));
            stopwatchSHA384.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA384.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatchSHA384.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 10000000 / stopwatchSHA384.Elapsed.Ticks} bps");

            Sha512 hash3 = new Sha512();
            stopwatchSHA512.Start();
            Console.WriteLine("Proper HASH SHA512(data): " + UlongArrayToString(hash3.Hash(data)));
            stopwatchSHA512.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA512.Elapsed} s");
            stopwatchSHA512.Reset();
            stopwatchSHA512.Start();
            Console.WriteLine("Proper HASH SHA512 (word): " + UlongArrayToString(hash3.Hash(Encoding.UTF8.GetBytes(word))));
            stopwatchSHA512.Stop();
            Console.WriteLine($"Data hashed in: {stopwatchSHA512.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatchSHA512.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 10000000 / stopwatchSHA512.Elapsed.Ticks} bps");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HashFunctionAnalizerForm());

        }

        public static string UintArrayToString(uint[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                uint high = input[i] >> 24;
                uint midhigh = (input[i] << 8) >> 24;
                uint midlow = (input[i] << 16) >> 24;
                uint low = (input[i] << 24) >> 24;
                result += high.ToString("X2") + midhigh.ToString("X2") + midlow.ToString("X2") + low.ToString("X2");
            }
            return result;
        }

        public static string UlongArrayToString(ulong[] input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                ulong high = input[i] >> 48;
                ulong midhigh = (input[i] << 16) >> 48;
                ulong midlow = (input[i] << 32) >> 48;
                ulong low = (input[i] << 48) >> 48;
                result += high.ToString("X4") + midhigh.ToString("X4") + midlow.ToString("X4") + low.ToString("X4");
            }
            return result;
        }
    }
}
