using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;
using System.Threading;
using HashFunctionAnalizer.TestsClass;
using System.Threading.Tasks;

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
            var alghoritm = new HashFunctions.SHA1();
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)), alghoritm);
        }

        public static string GetHashSha224(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(224);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)),alghoritm);
        }

        public static string GetHashSha256(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(256);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)), alghoritm);
        }

        public static string GetHashSha384(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(384);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)), alghoritm);
        }

        public static string GetHashSha512(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA2Managed(512);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)), alghoritm);
        }

        public static string GetHashSha3_512(string inputString)
        {
            var sb = new StringBuilder();
            var alghoritm = new SHA3Managed(512);
            return ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(inputString)), alghoritm);
        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA1.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA1", GetHashSha1(hashTextFiled.Text));
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



        private void checkBoxSHA3224_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA3224.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA3-224", GetHashSha3_512(hashTextFiled.Text));

            if (checkBoxSHA3224.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA3-224");
        }

        private void checkBoxSHA3256_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA3256.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA3-256", GetHashSha3_512(hashTextFiled.Text));

            if (checkBoxSHA3256.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA3-256");
        }

        private void checkBoxSHA3384_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA3384.Checked && _generateTextHashBtnClicked)
                dataGridViewHashCalculate.Rows.Add("SHA3-384", GetHashSha3_512(hashTextFiled.Text));

            if (checkBoxSHA3384.Checked && _speedTestHashBtnClicked)
                speedTestOfHashFunctions("SHA3-384");
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

                           
                            var hashSha1 = new HashFunctions.SHA1();
                            var hashSha2 = new SHA2Managed();
                            var hashSha3 = new SHA3Managed();

                            ////SHA1
                            //DateTime begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA1: " +
                            //                  ByteArrayToString(hashSha1.ComputeHash(FileToByteArray(fs.Name)),hash));
                            //TimeSpan time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length/(1024*1024)} hashed in: {time.TotalSeconds} s. {fs.Length/(1024*1024)/time.TotalSeconds} Mb/s");

                            ////SHA224
                            //hashSha2 = new SHA2Managed(224);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA224: " +
                            //                  ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA256
                            //hashSha2 = new SHA2Managed(256);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA256: " +
                            //                  ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA84
                            //hashSha2 = new SHA2Managed(384);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA384: " +
                            //                  ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA512
                            //hashSha2 = new SHA2Managed(512);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA512: " +
                            //                  ByteArrayToString(hashSha2.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA3-224
                            //hashSha3 = new SHA3Managed(224);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA3-224: " +
                            //                  ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA3-256
                            //hashSha3 = new SHA3Managed(256);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA3-256: " +
                            //                  ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA3-384
                            //hashSha3 = new SHA3Managed(384);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA3-385: " +
                            //                  ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)} hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");

                            ////SHA3-512
                            //hashSha3 = new SHA3Managed(512);
                            //begin = DateTime.UtcNow;
                            //Console.WriteLine("FILE HASH SHA3-512: " +
                            //                  ByteArrayToString(hashSha3.ComputeHash(FileToByteArray(fs.Name))));
                            //time = DateTime.UtcNow - begin;
                            //Console.WriteLine($"Data {fs.Length / (1024 * 1024)}:X2 hashed in: {time.TotalSeconds} s. {fs.Length / (1024 * 1024) / time.TotalSeconds} Mb/s");


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
            HashAlgorithm alghorithm;
            int times;

            //randomize data
            var someData = new byte[1000000];
            for (int i = 0; i < someData.Length; i++)
                someData[i] = Convert.ToByte(randomizeValue());

            if (dataSize != null)
                times = Convert.ToInt32(dataSize.Text);
            else
                times = 10;

            
                if (this.dataGridViewSpeedTest.ColumnCount <= 2 || this.dataGridViewSpeedTest.ColumnCount < (times/5))
                    dataGridViewSpeedTest.Invoke(new Action<int>(AddCollumn), new object[] { times });
            
            Thread th;
            SpeedOfHash speedTestRunner;
            

            switch (hashName)
            {
                case "SHA1":
                    //speedTestRunner = new SpeedOfHash();
                    alghorithm = new HashFunctions.SHA1();
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA224":
                    alghorithm = new SHA2Managed(224);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA256":
                    alghorithm = new SHA2Managed(256);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA384":
                    alghorithm = new SHA2Managed(384);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA512":
                    alghorithm = new SHA2Managed(512);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA3-224":
                    alghorithm = new SHA3Managed(224);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3Managed(256);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3Managed(384);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3Managed(512);
                    SpeedCounting(alghorithm, hashName, someData, times);
                    break;
                default:
                     
                    break;
            }

        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void speedTestBtn_Click(object sender, EventArgs e)
        {
            Action<string> act = speedTestOfHashFunctions;
            Task t;

            if (checkBoxSHA1.Checked)
            { t = Task.Run(() => { act("SHA1"); }); }

            if (checkBoxSHA224.Checked)
            { t = Task.Run(() => { act("SHA224"); }); }

            if (checkBoxSHA256.Checked)
            { t = Task.Run(() => { act("SHA256"); }); }

            if (checkBoxSHA384.Checked)
            { t = Task.Run(() => { act("SHA384"); }); }

            if (checkBoxSHA512.Checked)
            { t = Task.Run(() => { act("SHA512"); }); }
            
            if (checkBoxSHA3224.Checked)
            { t = Task.Run(() => { act("SHA3-224"); }); }

            if (checkBoxSHA3256.Checked)
            { t = Task.Run(() => { act("SHA3-256"); }); }

            if (checkBoxSHA3384.Checked)
            { t = Task.Run(() => { act("SHA3-384"); }); }

            if (checkBoxSHA3512.Checked)
            { t = Task.Run(() => { act("SHA3-512"); }); }

        }

        private int randomizeValue()
        {
            Random rnd = new Random();
            return rnd.Next(100);
        }

        public static string ByteArrayToString(byte[] ba, object hash)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);

            int length;

            if (ba.Length > 32)
                length = 8;
            else
                length = 4;

            for (var x = 0; x < ba.Length; x += length)
                for (var i = length - 1; i >= 0; i--)
                {
                    hex.AppendFormat("{0:X2}", ba[x + i]);
                }
            return hex.ToString();
        }

        public void SpeedCounting(HashAlgorithm alghorithm, string hashName, byte[] someData, int dataSize)
        {
            var rowIndex = this.dataGridViewSpeedTest.Rows.Count;
            var collumnCounter = 2;
            var begin = DateTime.UtcNow;
            var time = DateTime.UtcNow - begin;
            double result = 0.0;

            dataGridViewSpeedTest.Invoke(new Action(AddRow));
            hashName += $"({ begin})";

            for (int i = 0; i <= dataSize; i++)
            {
                alghorithm.ComputeHash(someData);

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

            Console.WriteLine("HASH {0} with speed: {1} Mb data in {2:f2}s", hashName, someData.Length * dataSize / (1024 * 1024), time.TotalSeconds);
            rowIndex++;
        }

        public void ChartUpdate(string hashName, double x, double y)
        {
            var series = new Series(hashName);
            series.ChartType = SeriesChartType.Spline;

           if (chartOfSpeed.Series.FindByName(hashName) != null)
                chartOfSpeed.Invoke(new Action<string,double,double>(AddingPoints), new object[] { hashName, x, y });
           else
             chartOfSpeed.Invoke(new Action<Series>(AddSeries), new object[] { series });
        }

        public void AddCollumn(int times)
        {
            for (int i = 0; i <= times; i++)
                if (i % 5 == 0)
                    dataGridViewSpeedTest.Columns.Add($"{i} Mb", $"{i} Mb");
        }

        public void AddRow()
        {
            dataGridViewSpeedTest.Rows.Add();
        }

        public void AddSeries(Series series)
        {
            chartOfSpeed.Series.Add(series);
        }

        public void AddingPoints(string hashName, double x, double y)
        {
            chartOfSpeed.Series[this.chartOfSpeed.Series.IndexOf(hashName)].Points.AddXY(x, y);
        }
    }
}