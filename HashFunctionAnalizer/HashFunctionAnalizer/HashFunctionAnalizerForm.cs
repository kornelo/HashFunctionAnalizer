using System;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using HashFunctionAnalizer.HashFunctions;

namespace HashFunctionAnalizer
{
    public partial class HashFunctionAnalizerForm : Form
    {
        private bool generateTextHashBtnClicked = false;

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
            generateTextHashBtnClicked = true;
            checkBoxSHA1_CheckedChanged(sender, e);
            generateTextHashBtnClicked = false;
        }

        public static uint[] GetHashSHA1(string inputString)
        {
            var alghoritm = new SHA1();
            return inputString != null ? alghoritm.Hash(Encoding.UTF8.GetBytes(inputString)) : null;
        }

        public static string GetHashString(string inputString)
        {
            var sb = new StringBuilder();
            foreach (var b in GetHashSHA1(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSHA1.Checked && generateTextHashBtnClicked)
            {
                if (hashTextFiled.Text != "")
                {
                    var hashField = hashTextFiled.Text;
                    dataGridViewHashCalculate.Rows.Add("SHA1",GetHashString(hashField));
                }
                else
                {
                    hashTextFiled.Text = "You must write something here!!!";
                }
            }
        }
    }
}