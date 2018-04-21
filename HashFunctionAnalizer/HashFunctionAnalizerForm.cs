using HashFunctionAnalizer.HashFunctions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HashFunctionAnalizer
{
    public partial class HashFunctionAnalizerForm : Form
    {


        public HashFunctionAnalizerForm()
        {
            InitializeComponent();
        }

        private void HashFunctionAnalizerForm_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            dataGridViewHashCalculate.Columns.Add("Function", "Function");
            dataGridViewHashCalculate.Columns.Add("Hash", "Hash");
            dataGridViewHashCalculate.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dataGridViewSpeedTest.Columns.Add("Function", "Function");
            dataGridViewSpeedTest.Columns.Add("Speed", "Speed Mb/s");
            dataSizeBox.Text = dataSizeBar.Value.ToString();

            dataGridAvalancheTest.Columns.Add("Function", "Function");
            dataGridAvalancheTest.Columns.Add(new DataGridViewImageColumn());
            dataGridAvalancheTest.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        #region Buttons

        private void SpeedTestBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = SpeedTestOfHashFunctions;
            ManageButtonActions(action);
        }

        private void AvalancheTestStartBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = AvalancheTestOfHashFunctions;
            ManageButtonActions(action);
        }

        private void GenerateTextHashBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = GeneratingTextHash;
            ManageButtonActions(action);
        }

        private void generateFileHashBtn_Click(object sender, EventArgs e)
        {
            Action<string> action = HashAlghorithmSelectedFile;
            ManageButtonActions(action);
        }

        public void ManageButtonActions(Action<string> action)
        {
            if (checkBoxSHA1.Checked)
            { Task.Run(() => { action("SHA1"); }); }

            if (checkBoxSHA224.Checked)
            { Task.Run(() => { action("SHA224"); }); }

            if (checkBoxSHA256.Checked)
            { Task.Run(() => { action("SHA256"); }); }

            if (checkBoxSHA384.Checked)
            { Task.Run(() => { action("SHA384"); }); }

            if (checkBoxSHA512.Checked)
            { Task.Run(() => { action("SHA512"); }); }

            if (checkBoxSHA3224.Checked)
            { Task.Run(() => { action("SHA3-224"); }); }

            if (checkBoxSHA3256.Checked)
            { Task.Run(() => { action("SHA3-256"); }); }

            if (checkBoxSHA3384.Checked)
            { Task.Run(() => { action("SHA3-384"); }); }

            if (checkBoxSHA3512.Checked)
            { Task.Run(() => { action("SHA3-512"); }); }
        }

        private void hashKeyFileChooseBtn_Click(object sender, EventArgs e)
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
                hashFilePath.Text = openFileDialog.FileName;
            }

        }

        #endregion

        #region HashingFile
        public void HashAlghorithmSelectedFile(string hashName)
        {
            HashAlgorithm alghorithm;

            switch (hashName)
            {
                case "SHA1":
                    alghorithm = new HashFunctions.SHA1();
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA224":
                    alghorithm = new SHA2Managed(224);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA256":
                    alghorithm = new SHA2Managed(256);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA384":
                    alghorithm = new SHA2Managed(384);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA512":
                    alghorithm = new SHA2Managed(512);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA3-224":
                    alghorithm = new SHA3(224);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3(256);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3(384);
                    HashSelectedFile(hashName, alghorithm);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3(512);
                    HashSelectedFile(hashName, alghorithm);
                    break;
            }
        }

        public void HashSelectedFile(string hashName, HashAlgorithm alghoritm)
        {
            var openFileDialog = new OpenFileDialog
            {
                FileName = hashFilePath.Text
            };
            try
            {
                var byteData = FileToByteArray(openFileDialog.FileName);
                var index = dataGridViewHashCalculate.NewRowIndex;
                dataGridViewHashCalculate.Invoke(new Action(AddRowHashCalculate));

                dataGridViewHashCalculate.Rows[index].Cells[0].Value = hashName;
                dataGridViewHashCalculate.Rows[index].Cells[1].Value = ByteArrayToString(alghoritm.ComputeHash(byteData));
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: Could not read file from disk. Original error: " + ex.Message);
            }
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
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }

        private void clrHashsListBtn_Click(object sender, EventArgs e)
        {
            dataGridViewHashCalculate.Rows.Clear();
        }

        #endregion

        #region Speed Testing
        internal void SpeedTestOfHashFunctions(string hashName)
        {
            HashAlgorithm alghorithm;

            //generating randomize data
            var someData = new byte[1048576];
            for (var i = 0; i < someData.Length; i++)
                someData[i] = Convert.ToByte(RandomizeValue());

            var dataSize = Convert.ToInt32(dataSizeBar.Invoke(new Func<int>(DataSizeBarValue)));

            //generating missing collumns
            if (dataGridViewSpeedTest.ColumnCount <= 2 || dataGridViewSpeedTest.ColumnCount < (dataSize/5))
                dataGridViewSpeedTest.Invoke(new Action<int>(AddCollumn), new object[] { dataSize });
           
            switch (hashName)
            {
                case "SHA1":
                    alghorithm = new HashFunctions.SHA1();
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA224":
                    alghorithm = new SHA2Managed(224);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA256":
                    alghorithm = new SHA2Managed(256);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA384":
                    alghorithm = new SHA2Managed(384);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA512":
                    alghorithm = new SHA2Managed(512);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA3-224":
                    alghorithm = new SHA3(224);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3(256);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3(384);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3(512);
                    SpeedCounting(alghorithm, hashName, someData, dataSize);
                    break;
            }

        }

        private int RandomizeValue()
        {
            var rnd = new Random();
            return rnd.Next(100);
        }

        public void SpeedCounting(HashAlgorithm alghorithm, string hashName, byte[] someData, int dataSize)
        {
            clearData.Invoke(new Action<bool>(ClearDataBtnState), false);

            var rowIndex = dataGridViewSpeedTest.NewRowIndex;
            dataGridViewSpeedTest.Invoke(new Action(AddRowSpeedTest));


            TimeSpan time;
            var collumnCounter = 2;
            var begin = DateTime.UtcNow;
            var result = 0.0;

            hashName += $"({ begin})";
            
            for (var i = 0; i <= dataSize; i++)
            {
                alghorithm.ComputeHash(someData);

                time = DateTime.UtcNow - begin;
                result = someData.Length * i / (1024 * 1024) / time.TotalSeconds;

                if (i % 5 == 0 && i != 0)
                {
                    dataGridViewSpeedTest.Rows[rowIndex].Cells[collumnCounter++].Value = $"{result:f2}";
                }
                ChartUpdate(hashName, i, result);
            }
            time = DateTime.UtcNow - begin;
            dataGridViewSpeedTest.Rows[rowIndex].Cells[0].Value = hashName;
            dataGridViewSpeedTest.Rows[rowIndex].Cells[1].Value = $"{result:f2}";

            Console.WriteLine($@"HASH {hashName} with speed: {someData.Length * dataSize / (1024 * 1024)} Mb data in {time.TotalSeconds:f2}s");
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

        public void AddRowSpeedTest()
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
            if (Process.GetCurrentProcess().Threads.Count < 2)
            {
                dataGridViewSpeedTest.Rows.Clear();
                chartOfSpeed.Series.Clear();
            }
            else MessageBox.Show("There is still work in progress, can't clear", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public int ColumnCounter()
        {
            return dataGridViewSpeedTest.Rows.Count;
        }

        public void ClearDataBtnState(bool state)
        {
            clearData.Enabled = state;
        }
#endregion

        #region Avalanche testing
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
                    alghorithm = new SHA3(224);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3(256);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3(384);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3(512);
                    CreateAvalancheBitmapAtRuntime(hashName, alghorithm);
                    break;
            }
        }

        public void CreateAvalancheBitmapAtRuntime(string hashName, HashAlgorithm alghorithm)
        {
            var image = new Bitmap(800, 200);
            var imageGraphics = Graphics.FromImage(image);
            var width = 0;
            var height = 0;
            imageGraphics.FillRectangle(Brushes.Yellow, width, height, 800, 200);

            var index = dataGridAvalancheTest.NewRowIndex;
            dataGridAvalancheTest.Invoke(new Action(AddRowAvalancheTest));

            dataGridAvalancheTest.Rows[index].Cells[0].Value = hashName;

            width = 10;
            var probe = image.Height;

            for (var i = image.Width; i >= 5; i -= 5)
            {
                while (height < 200)
                {
                    var brush = new SolidBrush(Color.FromArgb(BitConverter.ToInt32(alghorithm.ComputeHash(BitConverter.GetBytes(image.GetPixel(width, height).ToArgb())), 0)));
                    HashingImageProcess(image, brush, width, height, image.Height);
                    height += probe;

                }
                probe = probe / 2 + probe % 2;
                width += 10;
                height = 0;
                if (width == image.Width) break;
            }
        }

        public void AddRowAvalancheTest()
        {
            dataGridAvalancheTest.Rows.Add();

        }

        public void HashingImageProcess(Bitmap image, Brush brush, int width, int height, int imageHeight)
        {
            var imageGraphics = Graphics.FromImage(image);
            imageGraphics.FillRectangle(brush, width, 0, 10, imageHeight - height);
            Thread.Sleep(10);
            dataGridAvalancheTest.Invoke(new Action<Bitmap>(ImageDynamicFiller), image);
        }

        public void ImageDynamicFiller(Bitmap image)
        {
            dataGridAvalancheTest.Rows[dataGridAvalancheTest.NewRowIndex-1].Cells[1].Value = image;
            dataGridAvalancheTest.Refresh();
        }
        private void clrAvalacheBtn_Click(object sender, EventArgs e)
        {
            if (Process.GetCurrentProcess().Threads.Count < 2)
                dataGridAvalancheTest.Rows.Clear();
            else MessageBox.Show("There is still work in progress, can't clear", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region GeneratingTextHash

        internal void GeneratingTextHash(string hashName)
        {
            HashAlgorithm alghorithm;

            switch (hashName)
            {
                case "SHA1":
                    alghorithm = new HashFunctions.SHA1();
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA224":
                    alghorithm = new SHA2Managed(224);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA256":
                    alghorithm = new SHA2Managed(256);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA384":
                    alghorithm = new SHA2Managed(384);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA512":
                    alghorithm = new SHA2Managed(512);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA3-224":
                    alghorithm = new SHA3(224);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA3-256":
                    alghorithm = new SHA3(256);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA3-384":
                    alghorithm = new SHA3(384);
                    HashingText(hashName, alghorithm);
                    break;
                case "SHA3-512":
                    alghorithm = new SHA3(512);
                    HashingText(hashName, alghorithm);
                    break;
            }
        }

        public void HashingText(string hashName, HashAlgorithm alghoritm)
        {
            var index = dataGridViewHashCalculate.NewRowIndex;
            dataGridViewHashCalculate.Invoke(new Action(AddRowHashCalculate));

            dataGridViewHashCalculate.Rows[index].Cells[0].Value = hashName;
            dataGridViewHashCalculate.Rows[index].Cells[1].Value = ByteArrayToString(alghoritm.ComputeHash(Encoding.UTF8.GetBytes(hashTextFiled.Text)));
        }

        public static string ByteArrayToString(byte[] ba)
        {
            var hex = new StringBuilder(ba.Length * 2);

            foreach (byte t in ba)
            {
                hex.AppendFormat("{0:X2}", t);
            }
            return hex.ToString();
        }

        public void AddRowHashCalculate()
        {
            dataGridViewHashCalculate.Rows.Add();
        }

        #endregion

    }
}