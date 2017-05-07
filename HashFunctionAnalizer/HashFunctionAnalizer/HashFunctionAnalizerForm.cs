using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;

namespace HashFunctionAnalizer
{
    public partial class HashFunctionAnalizerForm : Form
    {
        private bool _generateTextHashBtnClicked;

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
            _generateTextHashBtnClicked = false;
        }

        public static uint[] GetHashSha1(string inputString)
        {
            var alghoritm = new Sha1();
            return inputString != null ? alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)) : null;
        }

        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetHashSha1(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA1.Checked && _generateTextHashBtnClicked)
            {
                if (hashTextFiled.Text != "")
                {
                    var hashField = hashTextFiled.Text;
                    dataGridViewHashCalculate.Rows.Add("SHA1", GetHashString(hashField));
                }
                else
                {
                    hashTextFiled.Text = "You must write something here!!!";
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                            Console.WriteLine("FILE HASH SHA1: " +
                                              UintArrayToString(hashSha1.Hash(FileToByteArray(fs.Name))));
                            Console.WriteLine("FILE HASH SHA224: " +
                                              UintArrayToString(hashSha224.Hash(FileToByteArray(fs.Name))));
                            Console.WriteLine("FILE HASH SHA256: " +
                                              UintArrayToString(hashSha256.Hash(FileToByteArray(fs.Name))));
                            Console.WriteLine("FILE HASH SHA384: " +
                                              UlongArrayToString(hashSha384.Hash(FileToByteArray(fs.Name))));
                            Console.WriteLine("FILE HASH SHA512: " +
                                              UlongArrayToString(hashSha512.Hash(FileToByteArray(fs.Name))));
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