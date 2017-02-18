using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

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
            dataGridViewHashCalculate.Columns.Add("Function","Function");
            dataGridViewHashCalculate.Columns.Add("Hash", "Hash");


        }

        private void hashKeyFileChooseBtn_Click(object sender, EventArgs e)
        {

        }

        private void generateTextHashBtn_Click(object sender, EventArgs e)
        {
            if (hashTextFiled.Text.ToString() != "")
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                string hashField = hashTextFiled.Text.ToString();
                string keyField = hashKeyField.Text.ToString();
                if (hashKeyField.Text.ToString() !="")
                    dataGridViewHashCalculate.Rows.Add("SHA1", GetHashString(keyField+hashField));
                else
                    dataGridViewHashCalculate.Rows.Add("SHA1", GetHashString(hashField));
            }
            else
            {
                hashTextFiled.Text = "You must write something here!!!";
            }
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
