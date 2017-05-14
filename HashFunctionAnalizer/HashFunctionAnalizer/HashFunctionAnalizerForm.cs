using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;

namespace HashFunctionAnalizer
{
    public partial class HashFunctionAnalizerForm : Form
    {
        private bool _generateTextHashBtnClicked;
        private static bool _checkBoxSha1_checked;
        private static bool _checkBoxSha224_checked;

        public HashFunctionAnalizerForm()
        {
            InitializeComponent();
        }

        private void HashFunctionAnalizerForm_Load(object sender, EventArgs e)
        {
            dataGridViewHashCalculate.Columns.Add("Function", "Function");
            dataGridViewHashCalculate.Columns.Add("Hash", "Hash");
        }

        private void hashKeyFileChooseBtn_Click(object sender, EventArgs e)
        {
        }

        private void generateTextHashBtn_Click(object sender, EventArgs e)
        {
            _generateTextHashBtnClicked = true;
            checkBoxSHA1_CheckedChanged(sender, e);
            checkBoxSHA224_CheckedChanged(sender,e);
            checkBoxSHA256_CheckedChanged(sender,e);
            checkBoxSHA384_CheckedChanged(sender,e);
            checkBoxSHA512_CheckedChanged(sender,e);
            _generateTextHashBtnClicked = false;
        }

        public static string GetHashSha1(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new Sha1();
            foreach (var b in alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public static string GetHashSha224(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new Sha224();
            foreach (var b in alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public static string GetHashSha256(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new Sha256();
            foreach (var b in alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public static string GetHashSha384(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new Sha384();
            foreach (var b in alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public static string GetHashSha512(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new Sha512();
            foreach (var b in alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA1.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA1", GetHashSha1(hashField));
            }
        }

        private void checkBoxSHA224_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA224.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA224", GetHashSha224(hashField));
            }
        }

        private void checkBoxSHA256_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA256.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA256", GetHashSha256(hashField));
            }
        }

        private void checkBoxSHA384_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA384.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA384", GetHashSha384(hashField));
            }
        }

        private void checkBoxSHA512_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA512.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA512", GetHashSha512(hashField));
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stopwatchSHA1 = new Stopwatch();
            var stopwatchSHA224 = new Stopwatch();
            var stopwatchSHA256 = new Stopwatch();
            var stopwatchSHA384 = new Stopwatch();
            var stopwatchSHA512 = new Stopwatch();

            Stream fileStream = null;
            var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!((fileStream = openFileDialog.OpenFile()) == null))
                        using (fileStream)
                        {
                            var imageData = new byte[fileStream.Length];

                            fileStream.Read(imageData, 0, Convert.ToInt32(fileStream.Length));
                            var fs = fileStream as FileStream;

                            var hashSha1 = new Sha1();
                            var hashSha224 = new Sha224();
                            var hashSha256 = new Sha256();
                            var hashSha512 = new Sha512();
                            var hashSha384 = new Sha384();

                            stopwatchSHA1.Start();
                            Console.WriteLine("FILE HASH SHA1: " +
                                              UintArrayToString(hashSha1.Hash(FileToByteArray(fs.Name))));
                            stopwatchSHA1.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA1.Elapsed} s");

                            stopwatchSHA224.Start();
                            Console.WriteLine("FILE HASH SHA224: " +
                                              UintArrayToString(hashSha224.Hash(FileToByteArray(fs.Name))));
                            stopwatchSHA224.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA224.Elapsed} s");

                            stopwatchSHA256.Start();
                            Console.WriteLine("FILE HASH SHA256: " +
                                              UintArrayToString(hashSha256.Hash(FileToByteArray(fs.Name))));
                            stopwatchSHA256.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA256.Elapsed} s");

                            stopwatchSHA384.Start();
                            Console.WriteLine("FILE HASH SHA384: " +
                                              UlongArrayToString(hashSha384.Hash(FileToByteArray(fs.Name))));
                            stopwatchSHA384.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA384.Elapsed} s");
                            Console.WriteLine($"Data hashed in: {stopwatchSHA384.ElapsedTicks} ms");


                            stopwatchSHA512.Start();
                            Console.WriteLine("FILE HASH SHA512: " +
                                              UlongArrayToString(hashSha512.Hash(FileToByteArray(fs.Name))));
                            stopwatchSHA512.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA512.Elapsed} s");

                            //Write length of file
                            Console.WriteLine($"File Length: {fileStream.Length}");
                            
                            //Close the File Stream
                            fileStream.Close();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (var fs = File.OpenRead(fileName))
            {
                using (var binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int) fs.Length);
                }
            }
            return fileData;
        }

        public static string UintArrayToString(uint[] input)
        {
            var result = "";
            for (var i = 0; i < input.Length; i++)
            {
                var high = input[i] >> 24;
                var midhigh = (input[i] << 8) >> 24;
                var midlow = (input[i] << 16) >> 24;
                var low = (input[i] << 24) >> 24;
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