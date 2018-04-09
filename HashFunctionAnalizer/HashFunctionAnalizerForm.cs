using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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
            dataSizeBox.Text = dataSizeBar.Value.ToString();

            dataGridViewSpeedTest.Columns.Add("Function", "Function");
            dataGridViewSpeedTest.Columns.Add("Speed", "Speed Mb/s");

            //CreateAvalancheBitmapAtRuntime("SHA3-512",new SHA3Managed(512));

        }

        private void hashKeyFileChooseBtn_Click(object sender, EventArgs e)
        {
        }

        private void generateTextHashBtn_Click(object sender, EventArgs e)
        {
            _generateTextHashBtnClicked = true;
            //CheckBoxSHA1_CheckedChanged(sender, e);
            //CheckBoxSHA224_CheckedChanged(sender,e);
            //CheckBoxSHA256_CheckedChanged(sender,e);
            //CheckBoxSHA384_CheckedChanged(sender,e);
            //CheckBoxSHA512_CheckedChanged(sender,e);
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

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
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
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "\\",
                Filter = @"All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream fileStream = null;
                    if ((fileStream = openFileDialog.OpenFile()) == null) return;
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
                    MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void DataGridViewHashCalculate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        internal void SpeedTestOfHashFunctions(string hashName)
        {
            HashAlgorithm alghorithm;

            //randomize data
            var someData = new byte[1000000];
            for (var i = 0; i < someData.Length; i++)
                someData[i] = Convert.ToByte(randomizeValue());


            var times = Convert.ToInt32(dataSizeBar.Invoke(new Func<int>(DataSizeBarValue)));

            
                if (dataGridViewSpeedTest.ColumnCount <= 2 || dataGridViewSpeedTest.ColumnCount < (times/5))
                    dataGridViewSpeedTest.Invoke(new Action<int>(AddCollumn), new object[] { times });
           
            switch (hashName)
            {
                case "SHA1":
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


        private void speedTestBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = SpeedTestOfHashFunctions;
            
            if (checkBoxSHA1.Checked)
            { var t = Task.Run(() => { action("SHA1"); }); }

            if (checkBoxSHA224.Checked)
            { var t = Task.Run(() => { action("SHA224"); }); }

            if (checkBoxSHA256.Checked)
            { var t = Task.Run(() => { action("SHA256"); }); }

            if (checkBoxSHA384.Checked)
            { var t = Task.Run(() => { action("SHA384"); }); }

            if (checkBoxSHA512.Checked)
            { var t = Task.Run(() => { action("SHA512"); }); }
            
            if (checkBoxSHA3224.Checked)
            { var t = Task.Run(() => { action("SHA3-224"); }); }

            if (checkBoxSHA3256.Checked)
            { var t = Task.Run(() => { action("SHA3-256"); }); }

            if (checkBoxSHA3384.Checked)
            { var t = Task.Run(() => { action("SHA3-384"); }); }

            if (checkBoxSHA3512.Checked)
            { var t = Task.Run(() => { action("SHA3-512"); }); }
            
        }

        private int randomizeValue()
        {
            var rnd = new Random();
            return rnd.Next(100);
        }

        public static string ByteArrayToString(byte[] ba, object hash)
        {
            var hex = new StringBuilder(ba.Length * 2);

            int length;

            length = ba.Length > 32 ? 8 : 4;

            for (var x = 0; x < ba.Length; x += length)
                for (var i = length - 1; i >= 0; i--)
                {
                    hex.AppendFormat("{0:X2}", ba[x + i]);
                }
            return hex.ToString();
        }

        public void SpeedCounting(HashAlgorithm alghorithm, string hashName, byte[] someData, int dataSize)
        {
            clearData.Invoke(new Action<bool>(ClearDataBtnState), false);
            var rowIndex = ColumnCounter();

            dataGridViewSpeedTest.Invoke(new Action(AddRow));
            
            var collumnCounter = 2;
            var begin = DateTime.UtcNow;
            var result = 0.0;

            hashName += $"({ begin})";

            TimeSpan time;

            for (var i = 0; i <= dataSize; i++)
            {
                alghorithm.ComputeHash(someData);

                time = DateTime.UtcNow - begin;
                result = someData.Length * i / (1024 * 1024) / time.TotalSeconds;

                if (i % 5 == 0 && i != 0)
                {
                    dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[collumnCounter++].Value = $"{result:f2}";
                }
                ChartUpdate(hashName, i, result);
            }
            time = DateTime.UtcNow - begin;
            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[0].Value = hashName;
            dataGridViewSpeedTest.Rows[rowIndex - 1].Cells[1].Value = $"{result:f2}";

            Console.WriteLine($"HASH {hashName} with speed: {someData.Length * dataSize / (1024 * 1024)} Mb data in {time.TotalSeconds:f2}s");
            rowIndex++;
            clearData.Invoke(new Action<bool>(ClearDataBtnState), true);
        }

        public void ChartUpdate(string hashName, double x, double y)
        {
            var series = new Series(hashName) {ChartType = SeriesChartType.Spline};

            if (chartOfSpeed.Series.FindByName(hashName) != null)
                chartOfSpeed.Invoke(new Action<string,double,double>(AddingPoints), new object[] { hashName, x, y });
           else
             chartOfSpeed.Invoke(new Action<Series>(AddSeries), new object[] { series });
        }

        public void AddCollumn(int times)
        {
           
            for (int i = (dataGridViewSpeedTest.Columns.Count - 1 ) * 5; i <= times; i++)
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
            chartOfSpeed.Series[chartOfSpeed.Series.IndexOf(hashName)].Points.AddXY(x, y);
        }

        private void dataSizeBar_Scroll(object sender, EventArgs e)
        {
            dataSizeBox.Text = dataSizeBar.Value.ToString();
        }

        public int DataSizeBarValue()
        {
           return dataSizeBar.Value;
        }

        private void ClearData_Click(object sender, EventArgs e)
        {
            dataGridViewSpeedTest.Rows.Clear();
            chartOfSpeed.Series.Clear();
        }

        public int ColumnCounter()
        {
            return dataGridViewSpeedTest.Rows.Count;
        }

        public void ClearDataBtnState(bool state)
        {
            clearData.Enabled = state;
        }


        public void CreateAvalancheBitmapAtRuntime(string hashName, HashAlgorithm alghorithm)
        {
            var flag = new Bitmap(800, 200);
            var flagGraphics = Graphics.FromImage(flag);
            var width = 0;
            var height = 0;
            flagGraphics.FillRectangle(Brushes.Yellow, width, height, 800, 200);
            //dataGridAvalancheTest.Rows[0].Cells[1].Value = flag;
            width = 10;
            var probe = flag.Height;

            for (var i = flag.Width; i >= 5; i -= 5)
            {
                while (height < 200)
                {
                    var brush = new SolidBrush(Color.FromArgb(BitConverter.ToInt32(alghorithm.ComputeHash(BitConverter.GetBytes(flag.GetPixel(width, height).ToArgb())), 0)));
                    flagGraphics.FillRectangle(brush, width, 0, 10, flag.Height - height);
                    height += probe;
                   
                }
                probe = probe / 2 + probe % 2;
                width += 10;
                height = 0;
               if (width == flag.Width) break;
             }

            dataGridAvalancheTest.Rows[0].Cells[0].Value = hashName;
            dataGridAvalancheTest.Rows[0].Cells[1].Value = flag;
        }


        internal void AvalancheTestOfHashFunctions(string hashName)
        {
            HashAlgorithm alghorithm;

            switch (hashName)
            {
                case "SHA1":
                    alghorithm = new HashFunctions.SHA1();
                    CreateAvalancheBitmapAtRuntime(hashName,alghorithm);
                    break;
                case "SHA224":
                    alghorithm = new SHA2Managed(224);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA256":
                    alghorithm = new SHA2Managed(256);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA384":
                    alghorithm = new SHA2Managed(384);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA512":
                    alghorithm = new SHA2Managed(512);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-224":
                    alghorithm = new SHA3Managed(224);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3Managed(256);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3Managed(384);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3Managed(512);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                default:

                    break;
            }

        }

        private void avalancheTestStartBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = AvalancheTestOfHashFunctions;

            if (checkBoxSHA1.Checked)
            { var t = Task.Run(() => { action("SHA1"); }); }

            if (checkBoxSHA224.Checked)
            { var t = Task.Run(() => { action("SHA224"); }); }

            if (checkBoxSHA256.Checked)
            { var t = Task.Run(() => { action("SHA256"); }); }

            if (checkBoxSHA384.Checked)
            { var t = Task.Run(() => { action("SHA384"); }); }

            if (checkBoxSHA512.Checked)
            { var t = Task.Run(() => { action("SHA512"); }); }

            if (checkBoxSHA3224.Checked)
            { var t = Task.Run(() => { action("SHA3-224"); }); }

            if (checkBoxSHA3256.Checked)
            { var t = Task.Run(() => { action("SHA3-256"); }); }

            if (checkBoxSHA3384.Checked)
            { var t = Task.Run(() => { action("SHA3-384"); }); }

            if (checkBoxSHA3512.Checked)
            { var t = Task.Run(() => { action("SHA3-512"); }); }
        }

        public void HashingImageProcess(HashAlgorithm algorithm)
        {
            
        }
    }
}