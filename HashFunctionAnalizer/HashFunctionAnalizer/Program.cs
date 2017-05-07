using System;
using System.Collections.Generic;
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

            Sha512 hash3 = new Sha512();
            Console.WriteLine("Proper HASH SHA512(data): " + UlongArrayToString(hash3.Hash(data)));
            Console.WriteLine("Proper HASH SHA512 (word): " + UlongArrayToString(hash3.Hash(Encoding.UTF8.GetBytes(word))));

            Sha384 hash4 = new Sha384();
            Console.WriteLine("Proper HASH SHA384(data): " + UlongArrayToString(hash4.Hash(data)));
            Console.WriteLine("Proper HASH SHA384 (word): " + UlongArrayToString(hash4.Hash(Encoding.UTF8.GetBytes(word))));


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
