using System;
using System.Collections.Generic;
using System.Linq;
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
            string word = "kornel";
            SHA1 hash = new SHA1();
            Console.WriteLine("Proper HASH SHA1: " + uintArrayToString(hash.Hash(data)));
            Console.WriteLine("Proper HASH SHA1 (word): " + uintArrayToString(hash.Hash(Encoding.UTF8.GetBytes(word))));


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HashFunctionAnalizerForm());

        }

        public static string uintArrayToString(uint[] input)
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
    }
}
