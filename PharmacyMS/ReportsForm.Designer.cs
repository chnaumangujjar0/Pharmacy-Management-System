namespace PharmacyMS
{
    partial class ReportsForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabToday = new System.Windows.Forms.TabPage();
            this.dgvTodayReport = new System.Windows.Forms.DataGridView();
            this.btnLoadToday = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTodaySalesCount = new System.Windows.Forms.Label();
            this.tabDateRange = new System.Windows.Forms.TabPage();
            this.dgvDateRange = new System.Windows.Forms.DataGridView();
            this.lblRangeRevenue = new System.Windows.Forms.Label();
            this.btnDateRange = new System.Windows.Forms.Button();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabBestSelling = new System.Windows.Forms.TabPage();
            this.dgvBestSelling = new System.Windows.Forms.DataGridView();
            this.btnBestSelling = new System.Windows.Forms.Button();
            this.tabLowStock = new System.Windows.Forms.TabPage();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.btnLowStock = new System.Windows.Forms.Button();
            this.txtStockLimit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabExpiry = new System.Windows.Forms.TabPage();
            this.dgvExpiry = new System.Windows.Forms.DataGridView();
            this.btnExpiry = new System.Windows.Forms.Button();
            this.txtExpiryDays = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabToday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayReport)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabDateRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateRange)).BeginInit();
            this.tabBestSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).BeginInit();
            this.tabLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.tabExpiry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.pnlHeader.Controls.Add(this.btnExport);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Location = new System.Drawing.Point(0, 1);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1171, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(943, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(192, 32);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "📥 Export to CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(20, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "📊 Reports And Analytics";
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabToday);
            this.tabReports.Controls.Add(this.tabDateRange);
            this.tabReports.Controls.Add(this.tabBestSelling);
            this.tabReports.Controls.Add(this.tabLowStock);
            this.tabReports.Controls.Add(this.tabExpiry);
            this.tabReports.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabReports.Location = new System.Drawing.Point(44, 90);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(1091, 524);
            this.tabReports.TabIndex = 1;
            // 
            // tabToday
            // 
            this.tabToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.tabToday.Controls.Add(this.dgvTodayReport);
            this.tabToday.Controls.Add(this.btnLoadToday);
            this.tabToday.Controls.Add(this.panel2);
            this.tabToday.Controls.Add(this.panel1);
            this.tabToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.tabToday.Location = new System.Drawing.Point(4, 28);
            this.tabToday.Name = "tabToday";
            this.tabToday.Padding = new System.Windows.Forms.Padding(3);
            this.tabToday.Size = new System.Drawing.Size(1083, 492);
            this.tabToday.TabIndex = 0;
            this.tabToday.Text = "📅 Today\'s Sales";
            // 
            // dgvTodayReport
            // 
            this.dgvTodayReport.AllowUserToAddRows = false;
            this.dgvTodayReport.AllowUserToDeleteRows = false;
            this.dgvTodayReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTodayReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.dgvTodayReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayReport.ColumnHeadersVisible = false;
            this.dgvTodayReport.Location = new System.Drawing.Point(29, 172);
            this.dgvTodayReport.Name = "dgvTodayReport";
            this.dgvTodayReport.ReadOnly = true;
            this.dgvTodayReport.RowHeadersWidth = 51;
            this.dgvTodayReport.RowTemplate.Height = 24;
            this.dgvTodayReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTodayReport.Size = new System.Drawing.Size(1021, 289);
            this.dgvTodayReport.TabIndex = 7;
            // 
            // btnLoadToday
            // 
            this.btnLoadToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnLoadToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadToday.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadToday.ForeColor = System.Drawing.Color.White;
            this.btnLoadToday.Location = new System.Drawing.Point(842, 74);
            this.btnLoadToday.Name = "btnLoadToday";
            this.btnLoadToday.Size = new System.Drawing.Size(179, 57);
            this.btnLoadToday.TabIndex = 6;
            this.btnLoadToday.Text = "🔄 Refresh";
            this.btnLoadToday.UseVisualStyleBackColor = false;
            this.btnLoadToday.Click += new System.EventHandler(this.btnLoadToday_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblTodayRevenue);
            this.panel2.Location = new System.Drawing.Point(304, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 104);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Revenue";
            // 
            // lblTodayRevenue
            // 
            this.lblTodayRevenue.AutoSize = true;
            this.lblTodayRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblTodayRevenue.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTodayRevenue.Location = new System.Drawing.Point(16, 54);
            this.lblTodayRevenue.Name = "lblTodayRevenue";
            this.lblTodayRevenue.Size = new System.Drawing.Size(21, 24);
            this.lblTodayRevenue.TabIndex = 3;
            this.lblTodayRevenue.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTodaySalesCount);
            this.panel1.Location = new System.Drawing.Point(29, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 104);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Sales ";
            // 
            // lblTodaySalesCount
            // 
            this.lblTodaySalesCount.AutoSize = true;
            this.lblTodaySalesCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTodaySalesCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodaySalesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblTodaySalesCount.Location = new System.Drawing.Point(15, 54);
            this.lblTodaySalesCount.Name = "lblTodaySalesCount";
            this.lblTodaySalesCount.Size = new System.Drawing.Size(21, 24);
            this.lblTodaySalesCount.TabIndex = 1;
            this.lblTodaySalesCount.Text = "0";
            // 
            // tabDateRange
            // 
            this.tabDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.tabDateRange.Controls.Add(this.dgvDateRange);
            this.tabDateRange.Controls.Add(this.lblRangeRevenue);
            this.tabDateRange.Controls.Add(this.btnDateRange);
            this.tabDateRange.Controls.Add(this.dtTo);
            this.tabDateRange.Controls.Add(this.dtFrom);
            this.tabDateRange.Controls.Add(this.label5);
            this.tabDateRange.Controls.Add(this.label3);
            this.tabDateRange.Location = new System.Drawing.Point(4, 28);
            this.tabDateRange.Name = "tabDateRange";
            this.tabDateRange.Padding = new System.Windows.Forms.Padding(3);
            this.tabDateRange.Size = new System.Drawing.Size(1083, 492);
            this.tabDateRange.TabIndex = 1;
            this.tabDateRange.Text = "📅 Date Range";
            // 
            // dgvDateRange
            // 
            this.dgvDateRange.AllowUserToAddRows = false;
            this.dgvDateRange.AllowUserToDeleteRows = false;
            this.dgvDateRange.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.dgvDateRange.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDateRange.Location = new System.Drawing.Point(35, 191);
            this.dgvDateRange.Name = "dgvDateRange";
            this.dgvDateRange.ReadOnly = true;
            this.dgvDateRange.RowHeadersWidth = 51;
            this.dgvDateRange.RowTemplate.Height = 24;
            this.dgvDateRange.Size = new System.Drawing.Size(1012, 269);
            this.dgvDateRange.TabIndex = 6;
            // 
            // lblRangeRevenue
            // 
            this.lblRangeRevenue.AutoSize = true;
            this.lblRangeRevenue.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRangeRevenue.Location = new System.Drawing.Point(31, 128);
            this.lblRangeRevenue.Name = "lblRangeRevenue";
            this.lblRangeRevenue.Size = new System.Drawing.Size(130, 27);
            this.lblRangeRevenue.TabIndex = 5;
            this.lblRangeRevenue.Text = "Revenue : ";
            // 
            // btnDateRange
            // 
            this.btnDateRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnDateRange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDateRange.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDateRange.ForeColor = System.Drawing.Color.White;
            this.btnDateRange.Location = new System.Drawing.Point(824, 58);
            this.btnDateRange.Name = "btnDateRange";
            this.btnDateRange.Size = new System.Drawing.Size(223, 42);
            this.btnDateRange.TabIndex = 4;
            this.btnDateRange.Text = "Generate Report";
            this.btnDateRange.UseVisualStyleBackColor = false;
            this.btnDateRange.Click += new System.EventHandler(this.btnDateRange_Click_1);
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(402, 58);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(178, 27);
            this.dtTo.TabIndex = 3;
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(120, 58);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(178, 27);
            this.dtFrom.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(358, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "From:";
            // 
            // tabBestSelling
            // 
            this.tabBestSelling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.tabBestSelling.Controls.Add(this.dgvBestSelling);
            this.tabBestSelling.Controls.Add(this.btnBestSelling);
            this.tabBestSelling.Location = new System.Drawing.Point(4, 28);
            this.tabBestSelling.Name = "tabBestSelling";
            this.tabBestSelling.Padding = new System.Windows.Forms.Padding(3);
            this.tabBestSelling.Size = new System.Drawing.Size(1083, 492);
            this.tabBestSelling.TabIndex = 2;
            this.tabBestSelling.Text = "🏆 Best Selling";
            // 
            // dgvBestSelling
            // 
            this.dgvBestSelling.AllowUserToAddRows = false;
            this.dgvBestSelling.AllowUserToDeleteRows = false;
            this.dgvBestSelling.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.dgvBestSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBestSelling.Location = new System.Drawing.Point(32, 108);
            this.dgvBestSelling.Name = "dgvBestSelling";
            this.dgvBestSelling.ReadOnly = true;
            this.dgvBestSelling.RowHeadersWidth = 51;
            this.dgvBestSelling.RowTemplate.Height = 24;
            this.dgvBestSelling.Size = new System.Drawing.Size(1018, 349);
            this.dgvBestSelling.TabIndex = 1;
            // 
            // btnBestSelling
            // 
            this.btnBestSelling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnBestSelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBestSelling.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBestSelling.ForeColor = System.Drawing.Color.White;
            this.btnBestSelling.Location = new System.Drawing.Point(895, 39);
            this.btnBestSelling.Name = "btnBestSelling";
            this.btnBestSelling.Size = new System.Drawing.Size(155, 34);
            this.btnBestSelling.TabIndex = 0;
            this.btnBestSelling.Text = "Refresh";
            this.btnBestSelling.UseVisualStyleBackColor = false;
            this.btnBestSelling.Click += new System.EventHandler(this.btnBestSelling_Click_1);
            // 
            // tabLowStock
            // 
            this.tabLowStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.tabLowStock.Controls.Add(this.dgvLowStock);
            this.tabLowStock.Controls.Add(this.btnLowStock);
            this.tabLowStock.Controls.Add(this.txtStockLimit);
            this.tabLowStock.Controls.Add(this.label6);
            this.tabLowStock.Location = new System.Drawing.Point(4, 28);
            this.tabLowStock.Name = "tabLowStock";
            this.tabLowStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabLowStock.Size = new System.Drawing.Size(1083, 492);
            this.tabLowStock.TabIndex = 3;
            this.tabLowStock.Text = "⚠️ Low Stock";
            // 
            // dgvLowStock
            // 
            this.dgvLowStock.AllowUserToAddRows = false;
            this.dgvLowStock.AllowUserToDeleteRows = false;
            this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLowStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLowStock.Location = new System.Drawing.Point(31, 130);
            this.dgvLowStock.Name = "dgvLowStock";
            this.dgvLowStock.ReadOnly = true;
            this.dgvLowStock.RowHeadersWidth = 51;
            this.dgvLowStock.RowTemplate.Height = 24;
            this.dgvLowStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLowStock.Size = new System.Drawing.Size(1015, 335);
            this.dgvLowStock.TabIndex = 3;
            // 
            // btnLowStock
            // 
            this.btnLowStock.BackColor = System.Drawing.Color.Coral;
            this.btnLowStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLowStock.ForeColor = System.Drawing.Color.White;
            this.btnLowStock.Location = new System.Drawing.Point(885, 57);
            this.btnLowStock.Name = "btnLowStock";
            this.btnLowStock.Size = new System.Drawing.Size(161, 43);
            this.btnLowStock.TabIndex = 2;
            this.btnLowStock.Text = "Check Stock";
            this.btnLowStock.UseVisualStyleBackColor = false;
            this.btnLowStock.Click += new System.EventHandler(this.btnLowStock_Click_1);
            // 
            // txtStockLimit
            // 
            this.txtStockLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.txtStockLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockLimit.ForeColor = System.Drawing.Color.White;
            this.txtStockLimit.Location = new System.Drawing.Point(239, 62);
            this.txtStockLimit.Name = "txtStockLimit";
            this.txtStockLimit.Size = new System.Drawing.Size(116, 27);
            this.txtStockLimit.TabIndex = 1;
            this.txtStockLimit.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Stock Alert Below:";
            // 
            // tabExpiry
            // 
            this.tabExpiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.tabExpiry.Controls.Add(this.dgvExpiry);
            this.tabExpiry.Controls.Add(this.btnExpiry);
            this.tabExpiry.Controls.Add(this.txtExpiryDays);
            this.tabExpiry.Controls.Add(this.label7);
            this.tabExpiry.Location = new System.Drawing.Point(4, 28);
            this.tabExpiry.Name = "tabExpiry";
            this.tabExpiry.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpiry.Size = new System.Drawing.Size(1083, 492);
            this.tabExpiry.TabIndex = 4;
            this.tabExpiry.Text = "💊 Expiry Alert";
            // 
            // dgvExpiry
            // 
            this.dgvExpiry.AllowUserToAddRows = false;
            this.dgvExpiry.AllowUserToDeleteRows = false;
            this.dgvExpiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpiry.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.dgvExpiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpiry.Location = new System.Drawing.Point(38, 125);
            this.dgvExpiry.Name = "dgvExpiry";
            this.dgvExpiry.ReadOnly = true;
            this.dgvExpiry.RowHeadersWidth = 51;
            this.dgvExpiry.RowTemplate.Height = 24;
            this.dgvExpiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpiry.Size = new System.Drawing.Size(1010, 335);
            this.dgvExpiry.TabIndex = 3;
            // 
            // btnExpiry
            // 
            this.btnExpiry.BackColor = System.Drawing.Color.Coral;
            this.btnExpiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpiry.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpiry.ForeColor = System.Drawing.Color.White;
            this.btnExpiry.Location = new System.Drawing.Point(857, 62);
            this.btnExpiry.Name = "btnExpiry";
            this.btnExpiry.Size = new System.Drawing.Size(191, 39);
            this.btnExpiry.TabIndex = 2;
            this.btnExpiry.Text = "Check Expiry";
            this.btnExpiry.UseVisualStyleBackColor = false;
            this.btnExpiry.Click += new System.EventHandler(this.btnExpiry_Click_1);
            // 
            // txtExpiryDays
            // 
            this.txtExpiryDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.txtExpiryDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExpiryDays.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpiryDays.ForeColor = System.Drawing.Color.White;
            this.txtExpiryDays.Location = new System.Drawing.Point(283, 62);
            this.txtExpiryDays.Name = "txtExpiryDays";
            this.txtExpiryDays.Size = new System.Drawing.Size(194, 27);
            this.txtExpiryDays.TabIndex = 1;
            this.txtExpiryDays.Text = "30";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Expiring within (days):";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(46)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1171, 655);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports & Analytics";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabToday.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayReport)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabDateRange.ResumeLayout(false);
            this.tabDateRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDateRange)).EndInit();
            this.tabBestSelling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSelling)).EndInit();
            this.tabLowStock.ResumeLayout(false);
            this.tabLowStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.tabExpiry.ResumeLayout(false);
            this.tabExpiry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabToday;
        private System.Windows.Forms.TabPage tabDateRange;
        private System.Windows.Forms.TabPage tabBestSelling;
        private System.Windows.Forms.TabPage tabLowStock;
        private System.Windows.Forms.TabPage tabExpiry;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTodaySalesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTodayReport;
        private System.Windows.Forms.Button btnLoadToday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDateRange;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.DataGridView dgvDateRange;
        private System.Windows.Forms.Label lblRangeRevenue;
        private System.Windows.Forms.DataGridView dgvBestSelling;
        private System.Windows.Forms.Button btnBestSelling;
        private System.Windows.Forms.TextBox txtStockLimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnLowStock;
        private System.Windows.Forms.TextBox txtExpiryDays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvExpiry;
        private System.Windows.Forms.Button btnExpiry;
    }
}