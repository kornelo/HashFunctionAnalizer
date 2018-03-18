using System;
using System.Collections.Generic;
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
        private bool _speedTestHashBtnClicked;

        public HashFunctionAnalizerForm()
        {
            InitializeComponent();
        }

        private void HashFunctionAnalizerForm_Load(object sender, EventArgs e)
        {
            dataGridViewHashCalculate.Columns.Add("Function", "Function");
            dataGridViewHashCalculate.Columns.Add("Hash", "Hash");

            dataGridView1.Columns.Add("Function", "Function");
            dataGridView1.Columns.Add("Speed", "Speed Mb/s");
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
            var alghoritm = new SHA2Managed(224);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
        }

        public static string GetHashSha256(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(256);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString))); 
        }

        public static string GetHashSha384(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(384);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
        }

        public static string GetHashSha512(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(512);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
        }

        public static string GetHashSha3_512(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA3Managed(512);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)));
        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA1.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA1", GetHashSha1(hashField));
            }

            if (checkBoxSHA1.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA1"),2);
                dataGridView1.Rows.Add("SHA1", result);
            }
        }

        private void checkBoxSHA224_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA224.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA224", GetHashSha224(hashField));
            }

            if (checkBoxSHA224.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA224"), 2);
                dataGridView1.Rows.Add("SHA224", result);
            }
        }

        private void checkBoxSHA256_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA256.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA256", GetHashSha256(hashField));
            }

            if (checkBoxSHA256.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA256"), 2);
                dataGridView1.Rows.Add("SHA256", result);
            }
        }

        private void checkBoxSHA384_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA384.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA384", GetHashSha384(hashField));
            }

            if (checkBoxSHA384.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA384"), 2);
                dataGridView1.Rows.Add("SHA384", result);
            }
        }

        private void checkBoxSHA512_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA512.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA512", GetHashSha512(hashField));
            }

            if (checkBoxSHA512.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA512"), 2);
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value = "SHA512";
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = result;
            }
        }

        private void checkBoxSHA3512_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA3512.Checked && _generateTextHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                dataGridViewHashCalculate.Rows.Add("SHA3-512", GetHashSha3_512(hashField));
            }

            if (checkBoxSHA3512.Checked && _speedTestHashBtnClicked)
            {
                var hashField = hashTextFiled.Text;
                double result = Math.Round(speedTestOfHashFunctions("SHA3-512"), 2);
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex+1].Cells[0].Value = "SHA3-512";
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex+1].Cells[1].Value = result;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
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

        private void generateFileHashBtn_Click(object sender, EventArgs e)
        {
            var stopwatch = new Stopwatch();
            var stopwatchSHA224 = new Stopwatch();
            var stopwatchSHA256 = new Stopwatch();
            var stopwatchSHA384 = new Stopwatch();
            var stopwatchSHA512 = new Stopwatch();


            Stream fileStream = null;
            var openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "\\";
            openFileDialog.Filter = @"All files (*.*)|*.*";
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
                            var hashSha224 = new SHA2Managed(224);
                            var hashSha256 = new SHA2Managed(256);
                            var hashSha384 = new SHA2Managed(384);
                            var hashSha512 = new SHA2Managed(512);
                            var hashSha3 = new SHA3Managed();

                            stopwatch.Start();
                            Console.WriteLine("FILE HASH SHA1: " +
                                              UintArrayToString(hashSha1.Hash(FileToByteArray(fs.Name))));
                            stopwatch.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatch.Elapsed} s");

                            stopwatchSHA224.Start();
                            Console.WriteLine("FILE HASH SHA224: " +
                                              ByteArrayToString(hashSha224.ComputeHash(FileToByteArray(fs.Name))));
                            stopwatchSHA224.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA224.Elapsed} s");

                            stopwatchSHA256.Start();
                            Console.WriteLine("FILE HASH SHA256: " +
                                              ByteArrayToString(hashSha256.ComputeHash(FileToByteArray(fs.Name))));
                            stopwatchSHA256.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA256.Elapsed} s");

                            stopwatchSHA384.Start();
                            Console.WriteLine("FILE HASH SHA384: " +
                                              ByteArrayToString(hashSha384.ComputeHash(FileToByteArray(fs.Name))));
                            stopwatchSHA384.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA384.Elapsed} s");


                            stopwatchSHA512.Start();
                            Console.WriteLine("FILE HASH SHA512: " +
                                              ByteArrayToString(hashSha512.ComputeHash(FileToByteArray(fs.Name))));
                            stopwatchSHA512.Stop();
                            Console.WriteLine($"Data hashed in: {stopwatchSHA512.Elapsed} s");


                            stopwatchSHA512.Reset();
                            stopwatchSHA512.Start();
                            Console.WriteLine("FILE HASH SHA3-512: " +
                                              ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
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

        private void dataGridViewHashCalculate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private double speedTestOfHashFunctions(string hashName)
        {
            var someData = new byte[1000000];


            //randomize data
            for(int i=0; i<someData.Length;i++)
                someData[i] = Convert.ToByte(randomizeValue());

            var times = 100;
            var stopWatch = new Stopwatch();
            double result;
            int collumnCounter;


            for (int i = 0; i < times; i++)
                if (i % 5 == 0)
                    dataGridView1.Columns.Add($"{i} Mb", $"{i} Mb");
           
            
            switch (hashName)
            {
                case "SHA1":
                    var alghorithmSha1 = new Sha1();
                    dataGridView1.Rows.Add();
                    collumnCounter = 2;
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha1.Hash(someData);

                        if (i % 5 == 0)
                        {
                            double secondsy = (double)stopWatch.ElapsedMilliseconds / 1000;
                            result = (double)(i / secondsy);
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex+(dataGridView1.RowCount-1)].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                    }
                    stopWatch.Stop();
                    break;
                case "SHA224":
                    var alghorithmSha224 = new SHA2Managed(224);
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha224.ComputeHash(someData);
                    }
                    stopWatch.Stop();
                    break;
                case "SHA256":
                    var alghorithmSha256 = new SHA2Managed(256);
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha256.ComputeHash(someData);
                    }
                    stopWatch.Stop();
                    break;
                case "SHA384":
                    var alghorithmSha384 = new SHA2Managed(384);
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha384.ComputeHash(someData);
                    }
                    stopWatch.Stop();
                    break;
                case "SHA512":
                    var alghorithmSha512 = new SHA2Managed(512);
                    dataGridView1.Rows.Add();
                    collumnCounter = 2;
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha512.ComputeHash(someData);

                        if (i % 5 == 0)
                        {
                            double secondsy = (double)stopWatch.ElapsedMilliseconds / 1000;
                            result = (double)(i / secondsy); 
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + (dataGridView1.RowCount-1)].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                    }
                    stopWatch.Stop();
                    break;
                case "SHA3-512":
                    var alghorithmSha3_512 = new SHA3Managed();
                    dataGridView1.Rows.Add();
                    collumnCounter = 2;
                    stopWatch.Reset();
                    stopWatch.Start();
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha3_512.ComputeHash(someData);

                        if (i % 5 == 0)
                        {
                            double secondsy = (double)stopWatch.ElapsedMilliseconds / 1000;
                            result = (double)(i / secondsy);
                            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex + (dataGridView1.RowCount-1)].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                    }
                    stopWatch.Stop();
                    break;
                default:
                     
                    break;
            }

            
            double seconds = (double)stopWatch.ElapsedMilliseconds/1000;

            Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}",hashName, times, seconds);

            result =(double)(times / seconds);

            return result;
        }

        private void speedTestBtn_Click(object sender, EventArgs e)
        {
            _speedTestHashBtnClicked = true;
            checkBoxSHA1_CheckedChanged(sender, e);
            checkBoxSHA224_CheckedChanged(sender, e);
            checkBoxSHA256_CheckedChanged(sender, e);
            checkBoxSHA384_CheckedChanged(sender, e);
            checkBoxSHA512_CheckedChanged(sender, e);
            checkBoxSHA3512_CheckedChanged(sender, e);
            _speedTestHashBtnClicked = false;
        }

        private int randomizeValue()
        {
            Random rnd = new Random();
            return rnd.Next(100);
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            int length;

            if (ba.Length == 64) length = 8;
            else length = 4;

            for (var x = 0; x < ba.Length; x += length)
                for (var i = length - 1; i >= 0; i--)
                {
                    hex.AppendFormat("{0:X2}", ba[x + i]);
                }
            return hex.ToString();
        }

    }
}