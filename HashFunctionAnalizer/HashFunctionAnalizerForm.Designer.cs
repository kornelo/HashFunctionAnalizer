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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
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
            this.clearData = new System.Windows.Forms.Button();
            this.dataSizeBox = new System.Windows.Forms.TextBox();
            this.dataSizeBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.chartOfSpeed = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.speedTestBtn = new System.Windows.Forms.Button();
            this.dataGridViewSpeedTest = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabAvalancheTest = new System.Windows.Forms.TabPage();
            this.dataGridAvalancheTest = new System.Windows.Forms.DataGridView();
            this.avalancheTestStartBtn = new System.Windows.Forms.Button();
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
            this.Hash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvalancheImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.HashTests.SuspendLayout();
            this.tabSpeedTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSizeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOfSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpeedTest)).BeginInit();
            this.tabAvalancheTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAvalancheTest)).BeginInit();
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
            this.HashTests.Controls.Add(this.tabAvalancheTest);
            this.HashTests.Controls.Add(this.tabPage3);
            this.HashTests.Location = new System.Drawing.Point(141, 12);
            this.HashTests.Name = "HashTests";
            this.HashTests.SelectedIndex = 0;
            this.HashTests.Size = new System.Drawing.Size(1035, 613);
            this.HashTests.TabIndex = 10;
            // 
            // tabSpeedTest
            // 
            this.tabSpeedTest.Controls.Add(this.clearData);
            this.tabSpeedTest.Controls.Add(this.dataSizeBox);
            this.tabSpeedTest.Controls.Add(this.dataSizeBar);
            this.tabSpeedTest.Controls.Add(this.label3);
            this.tabSpeedTest.Controls.Add(this.chartOfSpeed);
            this.tabSpeedTest.Controls.Add(this.speedTestBtn);
            this.tabSpeedTest.Controls.Add(this.dataGridViewSpeedTest);
            this.tabSpeedTest.Location = new System.Drawing.Point(4, 22);
            this.tabSpeedTest.Name = "tabSpeedTest";
            this.tabSpeedTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpeedTest.Size = new System.Drawing.Size(1027, 587);
            this.tabSpeedTest.TabIndex = 0;
            this.tabSpeedTest.Text = "SpeedTest [MB/s]";
            this.tabSpeedTest.UseVisualStyleBackColor = true;
            // 
            // clearData
            // 
            this.clearData.Location = new System.Drawing.Point(927, 57);
            this.clearData.Name = "clearData";
            this.clearData.Size = new System.Drawing.Size(88, 34);
            this.clearData.TabIndex = 6;
            this.clearData.Text = "Clear";
            this.clearData.UseVisualStyleBackColor = true;
            this.clearData.Click += new System.EventHandler(this.ClearData_Click);
            // 
            // dataSizeBox
            // 
            this.dataSizeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataSizeBox.Location = new System.Drawing.Point(927, 126);
            this.dataSizeBox.Name = "dataSizeBox";
            this.dataSizeBox.Size = new System.Drawing.Size(88, 35);
            this.dataSizeBox.TabIndex = 5;
            this.dataSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataSizeBar
            // 
            this.dataSizeBar.Location = new System.Drawing.Point(950, 167);
            this.dataSizeBar.Maximum = 500;
            this.dataSizeBar.Minimum = 1;
            this.dataSizeBar.Name = "dataSizeBar";
            this.dataSizeBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.dataSizeBar.Size = new System.Drawing.Size(45, 380);
            this.dataSizeBar.TabIndex = 4;
            this.dataSizeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.dataSizeBar.Value = 100;
            this.dataSizeBar.Scroll += new System.EventHandler(this.dataSizeBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(916, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "DATA SIZE [MB]";
            // 
            // chartOfSpeed
            // 
            chartArea3.Name = "ChartArea1";
            this.chartOfSpeed.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartOfSpeed.Legends.Add(legend3);
            this.chartOfSpeed.Location = new System.Drawing.Point(0, 289);
            this.chartOfSpeed.Name = "chartOfSpeed";
            this.chartOfSpeed.Size = new System.Drawing.Size(917, 300);
            this.chartOfSpeed.TabIndex = 2;
            this.chartOfSpeed.Text = "chartOfSpeed";
            // 
            // speedTestBtn
            // 
            this.speedTestBtn.Location = new System.Drawing.Point(927, 17);
            this.speedTestBtn.Name = "speedTestBtn";
            this.speedTestBtn.Size = new System.Drawing.Size(88, 34);
            this.speedTestBtn.TabIndex = 1;
            this.speedTestBtn.Text = "Start";
            this.speedTestBtn.UseVisualStyleBackColor = true;
            this.speedTestBtn.Click += new System.EventHandler(this.speedTestBtn_Click);
            // 
            // dataGridViewSpeedTest
            // 
            this.dataGridViewSpeedTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpeedTest.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSpeedTest.Name = "dataGridViewSpeedTest";
            this.dataGridViewSpeedTest.Size = new System.Drawing.Size(917, 282);
            this.dataGridViewSpeedTest.TabIndex = 0;
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
            // tabAvalancheTest
            // 
            this.tabAvalancheTest.Controls.Add(this.dataGridAvalancheTest);
            this.tabAvalancheTest.Controls.Add(this.avalancheTestStartBtn);
            this.tabAvalancheTest.Location = new System.Drawing.Point(4, 22);
            this.tabAvalancheTest.Name = "tabAvalancheTest";
            this.tabAvalancheTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvalancheTest.Size = new System.Drawing.Size(1027, 587);
            this.tabAvalancheTest.TabIndex = 2;
            this.tabAvalancheTest.Text = "Avalanche Test";
            this.tabAvalancheTest.UseVisualStyleBackColor = true;
            // 
            // dataGridAvalancheTest
            // 
            this.dataGridAvalancheTest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridAvalancheTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAvalancheTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hash,
            this.AvalancheImg});
            this.dataGridAvalancheTest.Location = new System.Drawing.Point(-4, 0);
            this.dataGridAvalancheTest.Name = "dataGridAvalancheTest";
            this.dataGridAvalancheTest.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridAvalancheTest.Size = new System.Drawing.Size(921, 581);
            this.dataGridAvalancheTest.TabIndex = 3;
            // 
            // avalancheTestStartBtn
            // 
            this.avalancheTestStartBtn.Location = new System.Drawing.Point(928, 43);
            this.avalancheTestStartBtn.Name = "avalancheTestStartBtn";
            this.avalancheTestStartBtn.Size = new System.Drawing.Size(86, 40);
            this.avalancheTestStartBtn.TabIndex = 2;
            this.avalancheTestStartBtn.Text = "START";
            this.avalancheTestStartBtn.UseVisualStyleBackColor = true;
            this.avalancheTestStartBtn.Click += new System.EventHandler(this.avalancheTestStartBtn_Click);
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
            this.dataGridViewHashCalculate.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewHashCalculate_CellContentClick);
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
            this.generateFileHashBtn.Click += new System.EventHandler(this.generateFileHashBtn_Click);
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
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // Hash
            // 
            this.Hash.HeaderText = "Hash";
            this.Hash.Name = "Hash";
            // 
            // AvalancheImg
            // 
            this.AvalancheImg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AvalancheImg.HeaderText = "AvalancheImg";
            this.AvalancheImg.MinimumWidth = 255;
            this.AvalancheImg.Name = "AvalancheImg";
            this.AvalancheImg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AvalancheImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
            this.tabSpeedTest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSizeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartOfSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpeedTest)).EndInit();
            this.tabAvalancheTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAvalancheTest)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewSpeedTest;
        private System.Windows.Forms.Button speedTestBtn;
        private System.Windows.Forms.TabPage tabAvalancheTest;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartOfSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar dataSizeBar;
        private System.Windows.Forms.TextBox dataSizeBox;
        private System.Windows.Forms.Button clearData;
        private System.Windows.Forms.Button avalancheTestStartBtn;
        private System.Windows.Forms.DataGridView dataGridAvalancheTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hash;
        private System.Windows.Forms.DataGridViewImageColumn AvalancheImg;
    }
}

