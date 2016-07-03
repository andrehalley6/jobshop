namespace JobShop
{
    partial class FormJobShop
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
            this.LblJudul = new System.Windows.Forms.Label();
            this.OFDJadwal = new System.Windows.Forms.OpenFileDialog();
            this.PnlKonfigurasi = new System.Windows.Forms.Panel();
            this.TCtrlKonfigurasi = new System.Windows.Forms.TabControl();
            this.TPageJS = new System.Windows.Forms.TabPage();
            this.BtnNewJadwal = new System.Windows.Forms.Button();
            this.BtnSaveJadwal = new System.Windows.Forms.Button();
            this.BtnLoadJadwal = new System.Windows.Forms.Button();
            this.NUDJmlMesin = new System.Windows.Forms.NumericUpDown();
            this.NUDJmlJob = new System.Windows.Forms.NumericUpDown();
            this.DGVJobShop = new System.Windows.Forms.DataGridView();
            this.Job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReadyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operation1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblMaxMesin = new System.Windows.Forms.Label();
            this.LblMaxJob = new System.Windows.Forms.Label();
            this.LblJmlMesin = new System.Windows.Forms.Label();
            this.LblJmlJob = new System.Windows.Forms.Label();
            this.TPageMA = new System.Windows.Forms.TabPage();
            this.LblJdlGenerate = new System.Windows.Forms.Label();
            this.BtnGenerateJadwal = new System.Windows.Forms.Button();
            this.LblJdlTS = new System.Windows.Forms.Label();
            this.LblJdlGenetik = new System.Windows.Forms.Label();
            this.NUDIterasiTS = new System.Windows.Forms.NumericUpDown();
            this.NUDTabuList = new System.Windows.Forms.NumericUpDown();
            this.LblUkrIterasi = new System.Windows.Forms.Label();
            this.LblUkrTabuList = new System.Windows.Forms.Label();
            this.LblJmlIter = new System.Windows.Forms.Label();
            this.LblTabuList = new System.Windows.Forms.Label();
            this.NUDGeneticPm = new System.Windows.Forms.NumericUpDown();
            this.NUDGeneticPc = new System.Windows.Forms.NumericUpDown();
            this.NUDGeneticMaxGenerasi = new System.Windows.Forms.NumericUpDown();
            this.NUDGeneticJmlPopulasi = new System.Windows.Forms.NumericUpDown();
            this.LblNilaiPm = new System.Windows.Forms.Label();
            this.LblNilaiPc = new System.Windows.Forms.Label();
            this.LblNilaiGenerasi = new System.Windows.Forms.Label();
            this.LblNilaiPopulasi = new System.Windows.Forms.Label();
            this.LblPM = new System.Windows.Forms.Label();
            this.LblPC = new System.Windows.Forms.Label();
            this.LblMaxGenerasi = new System.Windows.Forms.Label();
            this.LblJmlPopulasi = new System.Windows.Forms.Label();
            this.SFDJadwal = new System.Windows.Forms.SaveFileDialog();
            this.PnlKonfigurasi.SuspendLayout();
            this.TCtrlKonfigurasi.SuspendLayout();
            this.TPageJS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDJmlMesin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDJmlJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVJobShop)).BeginInit();
            this.TPageMA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDIterasiTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTabuList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticPm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticPc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticMaxGenerasi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticJmlPopulasi)).BeginInit();
            this.SuspendLayout();
            // 
            // LblJudul
            // 
            this.LblJudul.AutoSize = true;
            this.LblJudul.Font = new System.Drawing.Font("Garamond", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJudul.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.LblJudul.Location = new System.Drawing.Point(30, 30);
            this.LblJudul.Name = "LblJudul";
            this.LblJudul.Size = new System.Drawing.Size(527, 24);
            this.LblJudul.TabIndex = 1;
            this.LblJudul.Text = "Penjadwalan Job Shop Menggunakan Algoritma  Memetic";
            // 
            // OFDJadwal
            // 
            this.OFDJadwal.FileName = "OpenFileJadwal";
            this.OFDJadwal.Filter = "JobTextFile(*.job)|*.job";
            // 
            // PnlKonfigurasi
            // 
            this.PnlKonfigurasi.Controls.Add(this.TCtrlKonfigurasi);
            this.PnlKonfigurasi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlKonfigurasi.Location = new System.Drawing.Point(0, 93);
            this.PnlKonfigurasi.Name = "PnlKonfigurasi";
            this.PnlKonfigurasi.Size = new System.Drawing.Size(608, 393);
            this.PnlKonfigurasi.TabIndex = 3;
            // 
            // TCtrlKonfigurasi
            // 
            this.TCtrlKonfigurasi.AccessibleRole = System.Windows.Forms.AccessibleRole.DropList;
            this.TCtrlKonfigurasi.Controls.Add(this.TPageJS);
            this.TCtrlKonfigurasi.Controls.Add(this.TPageMA);
            this.TCtrlKonfigurasi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCtrlKonfigurasi.Location = new System.Drawing.Point(0, 0);
            this.TCtrlKonfigurasi.Name = "TCtrlKonfigurasi";
            this.TCtrlKonfigurasi.SelectedIndex = 0;
            this.TCtrlKonfigurasi.Size = new System.Drawing.Size(608, 393);
            this.TCtrlKonfigurasi.TabIndex = 0;
            // 
            // TPageJS
            // 
            this.TPageJS.Controls.Add(this.BtnNewJadwal);
            this.TPageJS.Controls.Add(this.BtnSaveJadwal);
            this.TPageJS.Controls.Add(this.BtnLoadJadwal);
            this.TPageJS.Controls.Add(this.NUDJmlMesin);
            this.TPageJS.Controls.Add(this.NUDJmlJob);
            this.TPageJS.Controls.Add(this.DGVJobShop);
            this.TPageJS.Controls.Add(this.LblMaxMesin);
            this.TPageJS.Controls.Add(this.LblMaxJob);
            this.TPageJS.Controls.Add(this.LblJmlMesin);
            this.TPageJS.Controls.Add(this.LblJmlJob);
            this.TPageJS.Location = new System.Drawing.Point(4, 22);
            this.TPageJS.Name = "TPageJS";
            this.TPageJS.Padding = new System.Windows.Forms.Padding(3);
            this.TPageJS.Size = new System.Drawing.Size(600, 367);
            this.TPageJS.TabIndex = 0;
            this.TPageJS.Text = "Konfigurasi Job Shop";
            this.TPageJS.UseVisualStyleBackColor = true;
            // 
            // BtnNewJadwal
            // 
            this.BtnNewJadwal.Location = new System.Drawing.Point(422, 13);
            this.BtnNewJadwal.Name = "BtnNewJadwal";
            this.BtnNewJadwal.Size = new System.Drawing.Size(75, 23);
            this.BtnNewJadwal.TabIndex = 11;
            this.BtnNewJadwal.Text = "&New";
            this.BtnNewJadwal.UseVisualStyleBackColor = true;
            this.BtnNewJadwal.Click += new System.EventHandler(this.BtnNewJadwal_Click);
            // 
            // BtnSaveJadwal
            // 
            this.BtnSaveJadwal.Location = new System.Drawing.Point(341, 13);
            this.BtnSaveJadwal.Name = "BtnSaveJadwal";
            this.BtnSaveJadwal.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveJadwal.TabIndex = 10;
            this.BtnSaveJadwal.Text = "&Save";
            this.BtnSaveJadwal.UseVisualStyleBackColor = true;
            this.BtnSaveJadwal.Click += new System.EventHandler(this.BtnSaveJadwal_Click);
            // 
            // BtnLoadJadwal
            // 
            this.BtnLoadJadwal.Location = new System.Drawing.Point(260, 13);
            this.BtnLoadJadwal.Name = "BtnLoadJadwal";
            this.BtnLoadJadwal.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadJadwal.TabIndex = 9;
            this.BtnLoadJadwal.Text = "&Load";
            this.BtnLoadJadwal.UseVisualStyleBackColor = true;
            this.BtnLoadJadwal.Click += new System.EventHandler(this.BtnLoadJadwal_Click);
            // 
            // NUDJmlMesin
            // 
            this.NUDJmlMesin.Location = new System.Drawing.Point(103, 37);
            this.NUDJmlMesin.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.NUDJmlMesin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDJmlMesin.Name = "NUDJmlMesin";
            this.NUDJmlMesin.Size = new System.Drawing.Size(50, 20);
            this.NUDJmlMesin.TabIndex = 8;
            this.NUDJmlMesin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDJmlMesin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDJmlMesin.ValueChanged += new System.EventHandler(this.NUDJmlMesin_ValueChanged);
            // 
            // NUDJmlJob
            // 
            this.NUDJmlJob.Location = new System.Drawing.Point(103, 13);
            this.NUDJmlJob.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.NUDJmlJob.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDJmlJob.Name = "NUDJmlJob";
            this.NUDJmlJob.Size = new System.Drawing.Size(50, 20);
            this.NUDJmlJob.TabIndex = 7;
            this.NUDJmlJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDJmlJob.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDJmlJob.ValueChanged += new System.EventHandler(this.NUDJmlJob_ValueChanged);
            // 
            // DGVJobShop
            // 
            this.DGVJobShop.AllowUserToAddRows = false;
            this.DGVJobShop.AllowUserToDeleteRows = false;
            this.DGVJobShop.AllowUserToResizeColumns = false;
            this.DGVJobShop.AllowUserToResizeRows = false;
            this.DGVJobShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVJobShop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Job,
            this.ReadyTime,
            this.Operation1});
            this.DGVJobShop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVJobShop.Location = new System.Drawing.Point(3, 63);
            this.DGVJobShop.Name = "DGVJobShop";
            this.DGVJobShop.RowHeadersVisible = false;
            this.DGVJobShop.Size = new System.Drawing.Size(594, 301);
            this.DGVJobShop.TabIndex = 6;
            // 
            // Job
            // 
            this.Job.HeaderText = "Job";
            this.Job.Name = "Job";
            this.Job.Width = 79;
            // 
            // ReadyTime
            // 
            this.ReadyTime.HeaderText = "Ready Time";
            this.ReadyTime.Name = "ReadyTime";
            this.ReadyTime.Width = 78;
            // 
            // Operation1
            // 
            this.Operation1.HeaderText = "M1,P1";
            this.Operation1.Name = "Operation1";
            // 
            // LblMaxMesin
            // 
            this.LblMaxMesin.AutoSize = true;
            this.LblMaxMesin.Location = new System.Drawing.Point(157, 40);
            this.LblMaxMesin.Name = "LblMaxMesin";
            this.LblMaxMesin.Size = new System.Drawing.Size(70, 13);
            this.LblMaxMesin.TabIndex = 5;
            this.LblMaxMesin.Text = "(1 - 15) mesin";
            // 
            // LblMaxJob
            // 
            this.LblMaxJob.AutoSize = true;
            this.LblMaxJob.Location = new System.Drawing.Point(157, 16);
            this.LblMaxJob.Name = "LblMaxJob";
            this.LblMaxJob.Size = new System.Drawing.Size(57, 13);
            this.LblMaxJob.TabIndex = 4;
            this.LblMaxJob.Text = "(1 - 20) job";
            // 
            // LblJmlMesin
            // 
            this.LblJmlMesin.AutoSize = true;
            this.LblJmlMesin.Location = new System.Drawing.Point(27, 40);
            this.LblJmlMesin.Name = "LblJmlMesin";
            this.LblJmlMesin.Size = new System.Drawing.Size(77, 13);
            this.LblJmlMesin.TabIndex = 1;
            this.LblJmlMesin.Text = "Jumlah Mesin :";
            // 
            // LblJmlJob
            // 
            this.LblJmlJob.AutoSize = true;
            this.LblJmlJob.Location = new System.Drawing.Point(27, 16);
            this.LblJmlJob.Name = "LblJmlJob";
            this.LblJmlJob.Size = new System.Drawing.Size(66, 13);
            this.LblJmlJob.TabIndex = 0;
            this.LblJmlJob.Text = "Jumlah Job :";
            // 
            // TPageMA
            // 
            this.TPageMA.Controls.Add(this.LblJdlGenerate);
            this.TPageMA.Controls.Add(this.BtnGenerateJadwal);
            this.TPageMA.Controls.Add(this.LblJdlTS);
            this.TPageMA.Controls.Add(this.LblJdlGenetik);
            this.TPageMA.Controls.Add(this.NUDIterasiTS);
            this.TPageMA.Controls.Add(this.NUDTabuList);
            this.TPageMA.Controls.Add(this.LblUkrIterasi);
            this.TPageMA.Controls.Add(this.LblUkrTabuList);
            this.TPageMA.Controls.Add(this.LblJmlIter);
            this.TPageMA.Controls.Add(this.LblTabuList);
            this.TPageMA.Controls.Add(this.NUDGeneticPm);
            this.TPageMA.Controls.Add(this.NUDGeneticPc);
            this.TPageMA.Controls.Add(this.NUDGeneticMaxGenerasi);
            this.TPageMA.Controls.Add(this.NUDGeneticJmlPopulasi);
            this.TPageMA.Controls.Add(this.LblNilaiPm);
            this.TPageMA.Controls.Add(this.LblNilaiPc);
            this.TPageMA.Controls.Add(this.LblNilaiGenerasi);
            this.TPageMA.Controls.Add(this.LblNilaiPopulasi);
            this.TPageMA.Controls.Add(this.LblPM);
            this.TPageMA.Controls.Add(this.LblPC);
            this.TPageMA.Controls.Add(this.LblMaxGenerasi);
            this.TPageMA.Controls.Add(this.LblJmlPopulasi);
            this.TPageMA.Location = new System.Drawing.Point(4, 22);
            this.TPageMA.Name = "TPageMA";
            this.TPageMA.Padding = new System.Windows.Forms.Padding(3);
            this.TPageMA.Size = new System.Drawing.Size(600, 367);
            this.TPageMA.TabIndex = 1;
            this.TPageMA.Text = "Konfigurasi Algoritma Memetic";
            this.TPageMA.UseVisualStyleBackColor = true;
            // 
            // LblJdlGenerate
            // 
            this.LblJdlGenerate.AutoSize = true;
            this.LblJdlGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJdlGenerate.Location = new System.Drawing.Point(164, 290);
            this.LblJdlGenerate.Name = "LblJdlGenerate";
            this.LblJdlGenerate.Size = new System.Drawing.Size(273, 24);
            this.LblJdlGenerate.TabIndex = 29;
            this.LblJdlGenerate.Text = "Generate Hasil Penjadwalan";
            // 
            // BtnGenerateJadwal
            // 
            this.BtnGenerateJadwal.Location = new System.Drawing.Point(263, 325);
            this.BtnGenerateJadwal.Name = "BtnGenerateJadwal";
            this.BtnGenerateJadwal.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerateJadwal.TabIndex = 28;
            this.BtnGenerateJadwal.Text = "&Generate";
            this.BtnGenerateJadwal.UseVisualStyleBackColor = true;
            this.BtnGenerateJadwal.Click += new System.EventHandler(this.BtnGenerateJadwal_Click_1);
            // 
            // LblJdlTS
            // 
            this.LblJdlTS.AutoSize = true;
            this.LblJdlTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJdlTS.Location = new System.Drawing.Point(180, 166);
            this.LblJdlTS.Name = "LblJdlTS";
            this.LblJdlTS.Size = new System.Drawing.Size(240, 24);
            this.LblJdlTS.TabIndex = 27;
            this.LblJdlTS.Text = "Konfigurasi Tabu Search";
            // 
            // LblJdlGenetik
            // 
            this.LblJdlGenetik.AutoSize = true;
            this.LblJdlGenetik.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJdlGenetik.Location = new System.Drawing.Point(158, 16);
            this.LblJdlGenetik.Name = "LblJdlGenetik";
            this.LblJdlGenetik.Size = new System.Drawing.Size(285, 24);
            this.LblJdlGenetik.TabIndex = 26;
            this.LblJdlGenetik.Text = "Konfigurasi Algoritma Genetik";
            // 
            // NUDIterasiTS
            // 
            this.NUDIterasiTS.Location = new System.Drawing.Point(168, 237);
            this.NUDIterasiTS.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUDIterasiTS.Name = "NUDIterasiTS";
            this.NUDIterasiTS.Size = new System.Drawing.Size(85, 20);
            this.NUDIterasiTS.TabIndex = 25;
            this.NUDIterasiTS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NUDTabuList
            // 
            this.NUDTabuList.Location = new System.Drawing.Point(168, 209);
            this.NUDTabuList.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.NUDTabuList.Name = "NUDTabuList";
            this.NUDTabuList.Size = new System.Drawing.Size(85, 20);
            this.NUDTabuList.TabIndex = 24;
            this.NUDTabuList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblUkrIterasi
            // 
            this.LblUkrIterasi.AutoSize = true;
            this.LblUkrIterasi.Location = new System.Drawing.Point(259, 240);
            this.LblUkrIterasi.Name = "LblUkrIterasi";
            this.LblUkrIterasi.Size = new System.Drawing.Size(40, 13);
            this.LblUkrIterasi.TabIndex = 23;
            this.LblUkrIterasi.Text = "(0 - 50)";
            // 
            // LblUkrTabuList
            // 
            this.LblUkrTabuList.AutoSize = true;
            this.LblUkrTabuList.Location = new System.Drawing.Point(259, 216);
            this.LblUkrTabuList.Name = "LblUkrTabuList";
            this.LblUkrTabuList.Size = new System.Drawing.Size(34, 13);
            this.LblUkrTabuList.TabIndex = 22;
            this.LblUkrTabuList.Text = "(0 - 7)";
            // 
            // LblJmlIter
            // 
            this.LblJmlIter.AutoSize = true;
            this.LblJmlIter.Location = new System.Drawing.Point(26, 240);
            this.LblJmlIter.Name = "LblJmlIter";
            this.LblJmlIter.Size = new System.Drawing.Size(77, 13);
            this.LblJmlIter.TabIndex = 21;
            this.LblJmlIter.Text = "Jumlah Iterasi :";
            // 
            // LblTabuList
            // 
            this.LblTabuList.AutoSize = true;
            this.LblTabuList.Location = new System.Drawing.Point(26, 216);
            this.LblTabuList.Name = "LblTabuList";
            this.LblTabuList.Size = new System.Drawing.Size(95, 13);
            this.LblTabuList.TabIndex = 20;
            this.LblTabuList.Text = "Ukuran Tabu List :";
            // 
            // NUDGeneticPm
            // 
            this.NUDGeneticPm.Location = new System.Drawing.Point(168, 130);
            this.NUDGeneticPm.Name = "NUDGeneticPm";
            this.NUDGeneticPm.Size = new System.Drawing.Size(85, 20);
            this.NUDGeneticPm.TabIndex = 19;
            this.NUDGeneticPm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NUDGeneticPc
            // 
            this.NUDGeneticPc.Location = new System.Drawing.Point(168, 104);
            this.NUDGeneticPc.Name = "NUDGeneticPc";
            this.NUDGeneticPc.Size = new System.Drawing.Size(85, 20);
            this.NUDGeneticPc.TabIndex = 18;
            this.NUDGeneticPc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NUDGeneticMaxGenerasi
            // 
            this.NUDGeneticMaxGenerasi.Location = new System.Drawing.Point(168, 80);
            this.NUDGeneticMaxGenerasi.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NUDGeneticMaxGenerasi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUDGeneticMaxGenerasi.Name = "NUDGeneticMaxGenerasi";
            this.NUDGeneticMaxGenerasi.Size = new System.Drawing.Size(85, 20);
            this.NUDGeneticMaxGenerasi.TabIndex = 16;
            this.NUDGeneticMaxGenerasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDGeneticMaxGenerasi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDGeneticJmlPopulasi
            // 
            this.NUDGeneticJmlPopulasi.Location = new System.Drawing.Point(168, 56);
            this.NUDGeneticJmlPopulasi.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NUDGeneticJmlPopulasi.Name = "NUDGeneticJmlPopulasi";
            this.NUDGeneticJmlPopulasi.Size = new System.Drawing.Size(85, 20);
            this.NUDGeneticJmlPopulasi.TabIndex = 15;
            this.NUDGeneticJmlPopulasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NUDGeneticJmlPopulasi.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // LblNilaiPm
            // 
            this.LblNilaiPm.AutoSize = true;
            this.LblNilaiPm.Location = new System.Drawing.Point(259, 130);
            this.LblNilaiPm.Name = "LblNilaiPm";
            this.LblNilaiPm.Size = new System.Drawing.Size(57, 13);
            this.LblNilaiPm.TabIndex = 13;
            this.LblNilaiPm.Text = "% (0 - 100)";
            // 
            // LblNilaiPc
            // 
            this.LblNilaiPc.AutoSize = true;
            this.LblNilaiPc.Location = new System.Drawing.Point(259, 106);
            this.LblNilaiPc.Name = "LblNilaiPc";
            this.LblNilaiPc.Size = new System.Drawing.Size(57, 13);
            this.LblNilaiPc.TabIndex = 12;
            this.LblNilaiPc.Text = "% (0 - 100)";
            // 
            // LblNilaiGenerasi
            // 
            this.LblNilaiGenerasi.AutoSize = true;
            this.LblNilaiGenerasi.Location = new System.Drawing.Point(259, 82);
            this.LblNilaiGenerasi.Name = "LblNilaiGenerasi";
            this.LblNilaiGenerasi.Size = new System.Drawing.Size(52, 13);
            this.LblNilaiGenerasi.TabIndex = 11;
            this.LblNilaiGenerasi.Text = "(1 - 1000)";
            // 
            // LblNilaiPopulasi
            // 
            this.LblNilaiPopulasi.AutoSize = true;
            this.LblNilaiPopulasi.Location = new System.Drawing.Point(259, 58);
            this.LblNilaiPopulasi.Name = "LblNilaiPopulasi";
            this.LblNilaiPopulasi.Size = new System.Drawing.Size(46, 13);
            this.LblNilaiPopulasi.TabIndex = 10;
            this.LblNilaiPopulasi.Text = "(2 - 100)";
            // 
            // LblPM
            // 
            this.LblPM.AutoSize = true;
            this.LblPM.Location = new System.Drawing.Point(26, 130);
            this.LblPM.Name = "LblPM";
            this.LblPM.Size = new System.Drawing.Size(125, 13);
            this.LblPM.TabIndex = 3;
            this.LblPM.Text = "Probabilitas Mutasi (Pm) :";
            // 
            // LblPC
            // 
            this.LblPC.AutoSize = true;
            this.LblPC.Location = new System.Drawing.Point(26, 106);
            this.LblPC.Name = "LblPC";
            this.LblPC.Size = new System.Drawing.Size(139, 13);
            this.LblPC.TabIndex = 2;
            this.LblPC.Text = "Probabilitas Crossover (Pc) :";
            // 
            // LblMaxGenerasi
            // 
            this.LblMaxGenerasi.AutoSize = true;
            this.LblMaxGenerasi.Location = new System.Drawing.Point(26, 82);
            this.LblMaxGenerasi.Name = "LblMaxGenerasi";
            this.LblMaxGenerasi.Size = new System.Drawing.Size(108, 13);
            this.LblMaxGenerasi.TabIndex = 1;
            this.LblMaxGenerasi.Text = "Maksimum Generasi :";
            // 
            // LblJmlPopulasi
            // 
            this.LblJmlPopulasi.AutoSize = true;
            this.LblJmlPopulasi.Location = new System.Drawing.Point(26, 58);
            this.LblJmlPopulasi.Name = "LblJmlPopulasi";
            this.LblJmlPopulasi.Size = new System.Drawing.Size(89, 13);
            this.LblJmlPopulasi.TabIndex = 0;
            this.LblJmlPopulasi.Text = "Jumlah Populasi :";
            // 
            // SFDJadwal
            // 
            this.SFDJadwal.FileName = "SaveFileJadwal";
            this.SFDJadwal.Filter = "JobTextFile(*.job)|*.job";
            // 
            // FormJobShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 486);
            this.Controls.Add(this.PnlKonfigurasi);
            this.Controls.Add(this.LblJudul);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormJobShop";
            this.Text = "Job Shop Scheduling";
            this.PnlKonfigurasi.ResumeLayout(false);
            this.TCtrlKonfigurasi.ResumeLayout(false);
            this.TPageJS.ResumeLayout(false);
            this.TPageJS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDJmlMesin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDJmlJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVJobShop)).EndInit();
            this.TPageMA.ResumeLayout(false);
            this.TPageMA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDIterasiTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTabuList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticPm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticPc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticMaxGenerasi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDGeneticJmlPopulasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblJudul;
        private System.Windows.Forms.OpenFileDialog OFDJadwal;
        private System.Windows.Forms.Panel PnlKonfigurasi;
        private System.Windows.Forms.SaveFileDialog SFDJadwal;
        private System.Windows.Forms.TabControl TCtrlKonfigurasi;
        private System.Windows.Forms.TabPage TPageJS;
        private System.Windows.Forms.Button BtnNewJadwal;
        private System.Windows.Forms.Button BtnSaveJadwal;
        private System.Windows.Forms.Button BtnLoadJadwal;
        private System.Windows.Forms.NumericUpDown NUDJmlMesin;
        private System.Windows.Forms.NumericUpDown NUDJmlJob;
        private System.Windows.Forms.DataGridView DGVJobShop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Job;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReadyTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operation1;
        private System.Windows.Forms.Label LblMaxMesin;
        private System.Windows.Forms.Label LblMaxJob;
        private System.Windows.Forms.Label LblJmlMesin;
        private System.Windows.Forms.Label LblJmlJob;
        private System.Windows.Forms.TabPage TPageMA;
        private System.Windows.Forms.Button BtnGenerateJadwal;
        private System.Windows.Forms.Label LblJdlTS;
        private System.Windows.Forms.Label LblJdlGenetik;
        private System.Windows.Forms.NumericUpDown NUDIterasiTS;
        private System.Windows.Forms.NumericUpDown NUDTabuList;
        private System.Windows.Forms.Label LblUkrIterasi;
        private System.Windows.Forms.Label LblUkrTabuList;
        private System.Windows.Forms.Label LblJmlIter;
        private System.Windows.Forms.Label LblTabuList;
        private System.Windows.Forms.NumericUpDown NUDGeneticPm;
        private System.Windows.Forms.NumericUpDown NUDGeneticPc;
        private System.Windows.Forms.NumericUpDown NUDGeneticMaxGenerasi;
        private System.Windows.Forms.NumericUpDown NUDGeneticJmlPopulasi;
        private System.Windows.Forms.Label LblNilaiPm;
        private System.Windows.Forms.Label LblNilaiPc;
        private System.Windows.Forms.Label LblNilaiGenerasi;
        private System.Windows.Forms.Label LblNilaiPopulasi;
        private System.Windows.Forms.Label LblPM;
        private System.Windows.Forms.Label LblPC;
        private System.Windows.Forms.Label LblMaxGenerasi;
        private System.Windows.Forms.Label LblJmlPopulasi;
        private System.Windows.Forms.Label LblJdlGenerate;
    }
}

