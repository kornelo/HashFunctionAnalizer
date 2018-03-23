using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;
using System.Windows.Forms.DataVisualization.Charting;

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

            dataGridViewSpeedTest.Columns.Add("Function", "Function");
            dataGridViewSpeedTest.Columns.Add("Speed", "Speed Mb/s");
            
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
                dataGridViewHashCalculate.Rows.Add("SHA1", GetHashSha1(hashTextFiled.Text));

            if (checkBoxSHA1.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA1");
        }

        private void checkBoxSHA224_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA224.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA224", GetHashSha224(hashTextFiled.Text));

            if (checkBoxSHA224.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA224");
        }

        private void checkBoxSHA256_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA256.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA256", GetHashSha256(hashTextFiled.Text));
        
            if (checkBoxSHA256.Checked && _speedTestHashBtnClicked)
                 speedTestOfHashFunctions("SHA256");
        }

        private void checkBoxSHA384_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA384.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA384", GetHashSha384(hashTextFiled.Text));

            if (checkBoxSHA384.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA384");
        }

        private void checkBoxSHA512_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA512.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA512", GetHashSha512(hashTextFiled.Text));

            if (checkBoxSHA512.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA512");
        }

        private void checkBoxSHA3512_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA3512.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA3-512", GetHashSha3_512(hashTextFiled.Text));
            
            if (checkBoxSHA3512.Checked && _speedTestHashBtnClicked)
               speedTestOfHashFunctions("SHA3-512");
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


        private void generateFileHashBtn_Click(object sender, EventArgs e)
        {


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
                            var hashSha2 = new SHA2Managed();
                            var hashSha3 = new SHA3Managed();

                            //SHA1
                            DateTime begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA1: " +
                                              UintArrayToString(hashSha1.Hash(FileToByteArray(fs.Name))));
                            TimeSpan time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length/(1024*1024)} hashed in: {time.TotalSeconds} s. {fs.Length/(1024*1024)/time.TotalSeconds} Mb/s");

                            //SHA224
                            hashSha2 = new SHA2Managed(224);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA224: " +
                                              ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA256
                            hashSha2 = new SHA2Managed(256);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA256: " +
                                              ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA84
                            hashSha2 = new SHA2Managed(384);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA384: " +
                                              ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA512
                            hashSha2 = new SHA2Managed(512);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA512: " +
                                              ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA3-224
                            hashSha3 = new SHA3Managed(224);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA3-224: " +
                                              ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA3-256
                            hashSha3 = new SHA3Managed(256);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA3-256: " +
                                              ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA3-384
                            hashSha3 = new SHA3Managed(384);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA3-385: " +
                                              ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            //SHA3-512
                            hashSha3 = new SHA3Managed(512);
                            begin = DateTime.UtcNow;
                            Console.WriteLine("FILE HASH SHA3-512: " +
                                              ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            time = DateTime.UtcNow - begin;
                            Console.WriteLine($"Data {fs.Length / (1024 * 1024)}:X2 hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");


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

        private void speedTestOfHashFunctions(string hashName)
        {
            var someData = new byte[1000000];


            //randomize data
            for(int i=0; i<someData.Length;i++)
                someData[i] = Convert.ToByte(randomizeValue());

            var times = 100;
            DateTime begin;
            TimeSpan time;
            Stopwatch stopWatch = new Stopwatch();
            double result =0.0;
            int collumnCounter;
            var rowIndex = dataGridViewSpeedTest.Rows.Count;

            if(dataGridViewSpeedTest.ColumnCount <= 2)
            for (int i = 0; i <= times; i++)
                if (i % 5 == 0)
                    dataGridViewSpeedTest.Columns.Add($"{i} Mb", $"{i} Mb");
           
            
            switch (hashName)
            {
                case "SHA1":
                    var alghorithmSha1 = new Sha1();
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";
                        
                    for (int i = 0; i <= times; i++)
                    {
                        alghorithmSha1.Hash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                           dataGridViewSpeedTest.Rows[rowIndex-1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex -1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex -1].Cells[1].Value = $"{result:f2}";
                    
                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length*times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                case "SHA224":
                    var alghorithmSha224 = new SHA2Managed(224);
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";

                    for (int i = 0; i <= times; i++)
                    {
                        alghorithmSha224.ComputeHash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                case "SHA256":
                    var alghorithmSha256 = new SHA2Managed(256);
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";

                    for (int i = 0; i <= times; i++)
                    {
                        alghorithmSha256.ComputeHash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                case "SHA384":
                    var alghorithmSha384 = new SHA2Managed(384);
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha384.ComputeHash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                case "SHA512":
                    var alghorithmSha512 = new SHA2Managed(512);
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha512.ComputeHash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                case "SHA3-512":
                    var alghorithmSha3_512 = new SHA3Managed();
                    collumnCounter = 2;
                    begin = DateTime.UtcNow;
                    dataGridViewSpeedTest.Rows.Add();
                    hashName += $"({ begin})";
                    for (int i = 0; i < times; i++)
                    {
                        alghorithmSha3_512.ComputeHash(someData);

                        time = DateTime.UtcNow - begin;
                        result = (double)(someData.Length * i / (1024 * 1024) / time.TotalSeconds);

                        if (i % 5 == 0)
                        {
                            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                        }
                        ChartUpdate(hashName, i, result);
                    }
                    time = DateTime.UtcNow - begin;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

                    Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * times / (1024 * 1024), time.TotalSeconds);
                    rowIndex++;
                    break;
                default:
                     
                    break;
            }

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

        public void ChartUpdate(string hashName, double x, double y)
        {
            var series = new Series(hashName);
            series.ChartType = SeriesChartType.Spline;

            if (chartOfSpeed.Series.FindByName(hashName) != null)
                chartOfSpeed.Series[chartOfSpeed.Series.IndexOf(hashName)].Points.AddXY(x, y);
            else
             chartOfSpeed.Series.Add(series);
                
        }
    }
}