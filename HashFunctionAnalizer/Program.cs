using System;
using System.Diagnostics;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;
using System.Text;
using System.Security.Cryptography;


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
            var stopwatch = new Stopwatch();


            byte[] data = { 0, 0, 5, 1, 1, 2 };
            string word = "abc";

            HashAlgorithm hash = new HashFunctions.SHA1();
            stopwatch.Start();
            Console.WriteLine($@"Proper HASH SHA1(data): {ByteArrayToString(hash.ComputeHash(data),hash)}");
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine($"Proper HASH SHA1 (word): {ByteArrayToString(hash.ComputeHash(Encoding.ASCII.GetBytes(word)),hash)}");
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 1000000 / stopwatch.Elapsed.Ticks} bps");


            SHA3Managed hash5 = new SHA3Managed(256);
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine($"Proper HASH SHA3-512 (word): {ByteArrayToString(hash5.ComputeHash(Encoding.UTF8.GetBytes(word)),hash5)}");
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {((double)(Encoding.ASCII.GetBytes(word).Length / 1024) * 1000L * 1000L * 10L / (stopwatch.ElapsedTicks)):f2} bps");

            SHA2Managed hash6 = new SHA2Managed(512);
            stopwatch.Reset();
            Console.WriteLine($"Proper HASH SHA-512(word): {ByteArrayToString(hash6.ComputeHash(Encoding.UTF8.GetBytes(word)),hash6)}");

            SHA2Managed hash7 = new SHA2Managed(224);
            stopwatch.Reset();
            Console.WriteLine($"Proper HASH SHA-224(word): {ByteArrayToString(hash7.ComputeHash(Encoding.UTF8.GetBytes(word)),hash7)}");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HashFunctionAnalizerForm());

        }

        public static string UintArrayToString(uint[] input)
        {
            var result = "";
            foreach (var i in input)
            {
                uint high = i >> 24;
                uint midhigh = (i << 8) >> 24;
                uint midlow = (i << 16) >> 24;
                uint low = (i << 24) >> 24;
                result += high.ToString("X2") + midhigh.ToString("X2") + midlow.ToString("X2") + low.ToString("X2");
            }
            return result;
        }

        public static string ByteArrayToString(byte[] ba, object hash)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            int length;

            length = ba.Length > 32 ? 8 : 4;

            for (var x =0; x<ba.Length; x+=length)
            for (var i = length -1; i >= 0; i--)
            {
                    hex.AppendFormat("{0:X2}", ba[x + i]); 
            }
            return hex.ToString();
        }
    }
}
