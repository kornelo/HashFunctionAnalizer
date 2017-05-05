using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            byte[] data = { 0, 0, 5, 1 };
            string word = "abc";
            Sha1 hash = new Sha1();
            Console.WriteLine("Proper HASH SHA1(data): " + UintArrayToString(hash.Hash(data)));
            Console.WriteLine("Proper HASH SHA1 (word): " + UintArrayToString(hash.Hash(Encoding.ASCII.GetBytes(word))));

            
            Sha224 hash1 = new Sha224();
            Console.WriteLine("Proper HASH SHA224(data): " + UintArrayToString(hash1.Hash(data)));
            Console.WriteLine("Proper HASH SHA224 (word): " + UintArrayToString(hash1.Hash(Encoding.UTF8.GetBytes(word))));

            Sha256 hash2 = new Sha256();
            Console.WriteLine("Proper HASH SHA256(data): " + UintArrayToString(hash2.Hash(data)));
            Console.WriteLine("Proper HASH SHA256 (word): " + UintArrayToString(hash2.Hash(Encoding.UTF8.GetBytes(word))));


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

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
