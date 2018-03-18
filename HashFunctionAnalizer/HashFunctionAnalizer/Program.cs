using System;
using System.Diagnostics;
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
            var stopwatch = new Stopwatch();


            byte[] data = { 0, 0, 5, 1, 1, 2 };
            string word = "abc";


            Sha1 hash = new Sha1();
            stopwatch.Start();
            Console.WriteLine("Proper HASH SHA1(data): " + UintArrayToString(hash.Hash(data)));
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Proper HASH SHA1 (word): " + UintArrayToString(hash.Hash(Encoding.ASCII.GetBytes(word))));
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine($"Speed of hashing: {Encoding.ASCII.GetBytes(word).Length * 1000000 / stopwatch.Elapsed.Ticks} bps");


            SHA3Managed hash5 = new SHA3Managed(512);
            //stopwatch.Start();
            //Console.WriteLine("Proper HASH SHA3-512(data): " + ToHexString(hash5.ComputeHash(data)));
            //stopwatch.Stop();
            //Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine("Proper HASH SHA3-512 (word): " + ByteArrayToString(hash5.ComputeHash(Encoding.UTF8.GetBytes(word))));
            stopwatch.Stop();
            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");
            Console.WriteLine($"Data hashed in: {stopwatch.ElapsedTicks} ticks");
            Console.WriteLine("Speed of hashing: {0:f2} bps", (double)(Encoding.ASCII.GetBytes(word).Length / 1024) * 1000L * 1000L * 10L / (stopwatch.ElapsedTicks));

            SHA2Managed hash6 = new SHA2Managed(512);
            stopwatch.Reset();
            Console.WriteLine("Proper HASH SHA-512(word): " + ByteArrayToString(hash6.ComputeHash(Encoding.UTF8.GetBytes(word))));

            SHA2Managed hash7 = new SHA2Managed(224);
            stopwatch.Reset();
            Console.WriteLine("Proper HASH SHA-224(word): " + ByteArrayToString(hash7.ComputeHash(Encoding.UTF8.GetBytes(word))));

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

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            int length;

            if (ba.Length == 64) length = 8;
            else length = 4;

            for (var x =0; x<ba.Length; x+=length)
            for (var i = length -1; i >= 0; i--)
            {
                    hex.AppendFormat("{0:X2}", ba[x + i]); 
            }
            return hex.ToString();
        }
    }
}
