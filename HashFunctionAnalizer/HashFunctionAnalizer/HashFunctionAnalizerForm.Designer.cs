namespace HashFunctionAnalizer
{
    partial class HashFunctionAnalizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxSHA1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA224 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA384 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA512 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA3224 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA3256 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA3384 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA3512 = new System.Windows.Forms.CheckBox();
            this.HashTests = new System.Windows.Forms.TabControl();
            this.tabSpeedTest = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridViewHashCalculate = new System.Windows.Forms.DataGridView();
            this.generateTextHashBtn = new System.Windows.Forms.Button();
            this.generateFileHashBtn = new System.Windows.Forms.Button();
            this.hashKeyFileChooseBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hashTextFiled = new System.Windows.Forms.TextBox();
            this.hashFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.HashTests.SuspendLayout();
            this.tabSpeedTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHashCalculate)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxSHA1
            // 
            this.checkBoxSHA1.AutoSize = true;
            this.checkBoxSHA1.Location = new System.Drawing.Point(12, 184);
            this.checkBoxSHA1.Name = "checkBoxSHA1";
            this.checkBoxSHA1.Size = new System.Drawing.Size(57, 17);
            this.checkBoxSHA1.TabIndex = 1;
            this.checkBoxSHA1.Text = "SHA-1";
            this.checkBoxSHA1.UseVisualStyleBackColor = true;
            this.checkBoxSHA1.CheckedChanged += new System.EventHandler(this.checkBoxSHA1_CheckedChanged);
            // 
            // checkBoxSHA224
            // 
            this.checkBoxSHA224.AutoSize = true;
            this.checkBoxSHA224.Location = new System.Drawing.Point(12, 207);
            this.checkBoxSHA224.Name = "checkBoxSHA224";
            this.checkBoxSHA224.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSHA224.TabIndex = 2;
            this.checkBoxSHA224.Text = "SHA-224";
            this.checkBoxSHA224.UseVisualStyleBackColor = true;
            this.checkBoxSHA224.CheckedChanged += new System.EventHandler(this.checkBoxSHA224_CheckedChanged);
            // 
            // checkBoxSHA256
            // 
            this.checkBoxSHA256.AutoSize = true;
            this.checkBoxSHA256.Location = new System.Drawing.Point(12, 230);
            this.checkBoxSHA256.Name = "checkBoxSHA256";
            this.checkBoxSHA256.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSHA256.TabIndex = 3;
            this.checkBoxSHA256.Text = "SHA-256";
            this.checkBoxSHA256.UseVisualStyleBackColor = true;
            this.checkBoxSHA256.CheckedChanged += new System.EventHandler(this.checkBoxSHA256_CheckedChanged);
            // 
            // checkBoxSHA384
            // 
            this.checkBoxSHA384.AutoSize = true;
            this.checkBoxSHA384.Location = new System.Drawing.Point(12, 253);
            this.checkBoxSHA384.Name = "checkBoxSHA384";
            this.checkBoxSHA384.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSHA384.TabIndex = 4;
            this.checkBoxSHA384.Text = "SHA-384";
            this.checkBoxSHA384.UseVisualStyleBackColor = true;
            this.checkBoxSHA384.CheckedChanged += new System.EventHandler(this.checkBoxSHA384_CheckedChanged);
            // 
            // checkBoxSHA512
            // 
            this.checkBoxSHA512.AutoSize = true;
            this.checkBoxSHA512.Location = new System.Drawing.Point(12, 276);
            this.checkBoxSHA512.Name = "checkBoxSHA512";
            this.checkBoxSHA512.Size = new System.Drawing.Size(69, 17);
            this.checkBoxSHA512.TabIndex = 5;
            this.checkBoxSHA512.Text = "SHA-512";
            this.checkBoxSHA512.UseVisualStyleBackColor = true;
            this.checkBoxSHA512.CheckedChanged += new System.EventHandler(this.checkBoxSHA512_CheckedChanged);
            // 
            // checkBoxSHA3224
            // 
            this.checkBoxSHA3224.AutoSize = true;
            this.checkBoxSHA3224.Location = new System.Drawing.Point(12, 299);
            this.checkBoxSHA3224.Name = "checkBoxSHA3224";
            this.checkBoxSHA3224.Size = new System.Drawing.Size(75, 17);
            this.checkBoxSHA3224.TabIndex = 6;
            this.checkBoxSHA3224.Text = "SHA3-224";
            this.checkBoxSHA3224.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA3256
            // 
            this.checkBoxSHA3256.AutoSize = true;
            this.checkBoxSHA3256.Location = new System.Drawing.Point(12, 322);
            this.checkBoxSHA3256.Name = "checkBoxSHA3256";
            this.checkBoxSHA3256.Size = new System.Drawing.Size(75, 17);
            this.checkBoxSHA3256.TabIndex = 7;
            this.checkBoxSHA3256.Text = "SHA3-256";
            this.checkBoxSHA3256.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA3384
            // 
            this.checkBoxSHA3384.AutoSize = true;
            this.checkBoxSHA3384.Location = new System.Drawing.Point(12, 345);
            this.checkBoxSHA3384.Name = "checkBoxSHA3384";
            this.checkBoxSHA3384.Size = new System.Drawing.Size(75, 17);
            this.checkBoxSHA3384.TabIndex = 8;
            this.checkBoxSHA3384.Text = "SHA3-384";
            this.checkBoxSHA3384.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA3512
            // 
            this.checkBoxSHA3512.AutoSize = true;
            this.checkBoxSHA3512.Location = new System.Drawing.Point(12, 368);
            this.checkBoxSHA3512.Name = "checkBoxSHA3512";
            this.checkBoxSHA3512.Size = new System.Drawing.Size(75, 17);
            this.checkBoxSHA3512.TabIndex = 9;
            this.checkBoxSHA3512.Text = "SHA3-512";
            this.checkBoxSHA3512.UseVisualStyleBackColor = true;
            // 
            // HashTests
            // 
            this.HashTests.Controls.Add(this.tabSpeedTest);
            this.HashTests.Controls.Add(this.tabPage2);
            this.HashTests.Controls.Add(this.tabPage1);
            this.HashTests.Controls.Add(this.tabPage3);
            this.HashTests.Location = new System.Drawing.Point(141, 12);
            this.HashTests.Name = "HashTests";
            this.HashTests.SelectedIndex = 0;
            this.HashTests.Size = new System.Drawing.Size(1035, 613);
            this.HashTests.TabIndex = 10;
            // 
            // tabSpeedTest
            // 
            this.tabSpeedTest.Controls.Add(this.button1);
            this.tabSpeedTest.Controls.Add(this.dataGridView1);
            this.tabSpeedTest.Location = new System.Drawing.Point(4, 22);
            this.tabSpeedTest.Name = "tabSpeedTest";
            this.tabSpeedTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeedTest.Size = new System.Drawing.Size(1027, 587);
            this.tabSpeedTest.TabIndex = 0;
            this.tabSpeedTest.Text = "SpeedTest [MB/s]";
            this.tabSpeedTest.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(926, 587);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 587);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CPU Cycles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1027, 587);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Avalanche Test";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridViewHashCalculate);
            this.tabPage3.Controls.Add(this.generateTextHashBtn);
            this.tabPage3.Controls.Add(this.generateFileHashBtn);
            this.tabPage3.Controls.Add(this.hashKeyFileChooseBtn);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.hashTextFiled);
            this.tabPage3.Controls.Add(this.hashFilePath);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1027, 587);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Hash Calculator";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHashCalculate
            // 
            this.dataGridViewHashCalculate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHashCalculate.Location = new System.Drawing.Point(20, 100);
            this.dataGridViewHashCalculate.Name = "dataGridViewHashCalculate";
            this.dataGridViewHashCalculate.Size = new System.Drawing.Size(983, 462);
            this.dataGridViewHashCalculate.TabIndex = 9;
            // 
            // generateTextHashBtn
            // 
            this.generateTextHashBtn.Location = new System.Drawing.Point(839, 47);
            this.generateTextHashBtn.Name = "generateTextHashBtn";
            this.generateTextHashBtn.Size = new System.Drawing.Size(136, 23);
            this.generateTextHashBtn.TabIndex = 8;
            this.generateTextHashBtn.Text = "Generate (Text Hash)";
            this.generateTextHashBtn.UseVisualStyleBackColor = true;
            this.generateTextHashBtn.Click += new System.EventHandler(this.generateTextHashBtn_Click);
            // 
            // generateFileHashBtn
            // 
            this.generateFileHashBtn.Location = new System.Drawing.Point(839, 18);
            this.generateFileHashBtn.Name = "generateFileHashBtn";
            this.generateFileHashBtn.Size = new System.Drawing.Size(136, 23);
            this.generateFileHashBtn.TabIndex = 7;
            this.generateFileHashBtn.Text = "Generate (File Hash)";
            this.generateFileHashBtn.UseVisualStyleBackColor = true;
            // 
            // hashKeyFileChooseBtn
            // 
            this.hashKeyFileChooseBtn.Location = new System.Drawing.Point(786, 18);
            this.hashKeyFileChooseBtn.Name = "hashKeyFileChooseBtn";
            this.hashKeyFileChooseBtn.Size = new System.Drawing.Size(27, 23);
            this.hashKeyFileChooseBtn.TabIndex = 6;
            this.hashKeyFileChooseBtn.Text = "...";
            this.hashKeyFileChooseBtn.UseVisualStyleBackColor = true;
            this.hashKeyFileChooseBtn.Click += new System.EventHandler(this.hashKeyFileChooseBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ASCII Text :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "FILE :";
            // 
            // hashTextFiled
            // 
            this.hashTextFiled.Location = new System.Drawing.Point(99, 46);
            this.hashTextFiled.Name = "hashTextFiled";
            this.hashTextFiled.Size = new System.Drawing.Size(681, 20);
            this.hashTextFiled.TabIndex = 1;
            // 
            // hashFilePath
            // 
            this.hashFilePath.Location = new System.Drawing.Point(99, 20);
            this.hashFilePath.Name = "hashFilePath";
            this.hashFilePath.Size = new System.Drawing.Size(681, 20);
            this.hashFilePath.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // HashFunctionAnalizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 640);
            this.Controls.Add(this.HashTests);
            this.Controls.Add(this.checkBoxSHA3512);
            this.Controls.Add(this.checkBoxSHA3384);
            this.Controls.Add(this.checkBoxSHA3256);
            this.Controls.Add(this.checkBoxSHA3224);
            this.Controls.Add(this.checkBoxSHA512);
            this.Controls.Add(this.checkBoxSHA384);
            this.Controls.Add(this.checkBoxSHA256);
            this.Controls.Add(this.checkBoxSHA224);
            this.Controls.Add(this.checkBoxSHA1);
            this.Name = "HashFunctionAnalizerForm";
            this.Text = "HashFunctionAnalizer";
            this.Load += new System.EventHandler(this.HashFunctionAnalizerForm_Load);
            this.HashTests.ResumeLayout(false);
            this.tabSpeedTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHashCalculate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxSHA1;
        private System.Windows.Forms.CheckBox checkBoxSHA224;
        private System.Windows.Forms.CheckBox checkBoxSHA256;
        private System.Windows.Forms.CheckBox checkBoxSHA384;
        private System.Windows.Forms.CheckBox checkBoxSHA512;
        private System.Windows.Forms.CheckBox checkBoxSHA3224;
        private System.Windows.Forms.CheckBox checkBoxSHA3256;
        private System.Windows.Forms.CheckBox checkBoxSHA3384;
        private System.Windows.Forms.CheckBox checkBoxSHA3512;
        private System.Windows.Forms.TabControl HashTests;
        private System.Windows.Forms.TabPage tabSpeedTest;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hashTextFiled;
        private System.Windows.Forms.TextBox hashFilePath;
        private System.Windows.Forms.Button generateTextHashBtn;
        private System.Windows.Forms.Button generateFileHashBtn;
        private System.Windows.Forms.Button hashKeyFileChooseBtn;
        private System.Windows.Forms.DataGridView dataGridViewHashCalculate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

