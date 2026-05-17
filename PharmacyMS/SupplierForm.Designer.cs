namespace PharmacyMS
{
    partial class SupplierForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();

            // ── pnlHeader ────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.ColorTranslator.FromHtml("#16213E");
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(960, 60);
            this.pnlHeader.TabIndex = 0;

            // ── lblTitle ──────────────────────────────────────
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#E94560");
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(340, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Text = "🏭 Supplier Management";

            // ── txtId (Hidden) ────────────────────────────────
            this.txtId.Location = new System.Drawing.Point(0, 0);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(1, 1);
            this.txtId.Visible = false;
            this.txtId.TabIndex = 99;

            // ── lblSearch ─────────────────────────────────────
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblSearch.BackColor = System.Drawing.Color.Transparent;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSearch.Location = new System.Drawing.Point(15, 75);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "🔍 Search:";

            // ── txtSearch ─────────────────────────────────────
            this.txtSearch.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(15, 95);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(240, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // ── lblName ───────────────────────────────────────
            this.lblName.AutoSize = true;
            this.lblName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblName.Location = new System.Drawing.Point(15, 135);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Supplier Name *";

            // ── txtName ───────────────────────────────────────
            this.txtName.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(15, 153);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 26);
            this.txtName.TabIndex = 2;

            // ── lblContact ────────────────────────────────────
            this.lblContact.AutoSize = true;
            this.lblContact.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblContact.Location = new System.Drawing.Point(15, 190);
            this.lblContact.Name = "lblContact";
            this.lblContact.Text = "Contact Person";

            // ── txtContact ────────────────────────────────────
            this.txtContact.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtContact.ForeColor = System.Drawing.Color.White;
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContact.Location = new System.Drawing.Point(15, 208);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(240, 26);
            this.txtContact.TabIndex = 3;

            // ── lblPhone ──────────────────────────────────────
            this.lblPhone.AutoSize = true;
            this.lblPhone.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhone.Location = new System.Drawing.Point(15, 245);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone Number *";

            // ── txtPhone ──────────────────────────────────────
            this.txtPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(15, 263);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(115, 26);
            this.txtPhone.TabIndex = 4;

            // ── lblCity ───────────────────────────────────────
            this.lblCity.AutoSize = true;
            this.lblCity.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblCity.BackColor = System.Drawing.Color.Transparent;
            this.lblCity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCity.Location = new System.Drawing.Point(140, 245);
            this.lblCity.Name = "lblCity";
            this.lblCity.Text = "City";

            // ── txtCity ───────────────────────────────────────
            this.txtCity.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtCity.ForeColor = System.Drawing.Color.White;
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Location = new System.Drawing.Point(140, 263);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(115, 26);
            this.txtCity.TabIndex = 5;

            // ── lblEmail ──────────────────────────────────────
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.Location = new System.Drawing.Point(15, 300);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email Address";

            // ── txtEmail ──────────────────────────────────────
            this.txtEmail.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(15, 318);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(240, 26);
            this.txtEmail.TabIndex = 6;

            // ── lblAddress ────────────────────────────────────
            this.lblAddress.AutoSize = true;
            this.lblAddress.ForeColor = System.Drawing.ColorTranslator.FromHtml("#A8A8B3");
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddress.Location = new System.Drawing.Point(15, 355);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address";

            // ── txtAddress ────────────────────────────────────
            this.txtAddress.BackColor = System.Drawing.ColorTranslator.FromHtml("#0F3460");
            this.txtAddress.ForeColor = System.Drawing.Color.White;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(15, 373);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(240, 55);
            this.txtAddress.TabIndex = 7;

            // ── btnAdd ────────────────────────────────────────
            this.btnAdd.BackColor = System.Drawing.ColorTranslator.FromHtml("#00B4D8");
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(15, 445);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "➕ Add";
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // ── btnUpdate ─────────────────────────────────────
            this.btnUpdate.BackColor = System.Drawing.ColorTranslator.FromHtml("#7B2FBE");
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(140, 445);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "✏️ Update";
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // ── btnDelete ─────────────────────────────────────
            this.btnDelete.BackColor = System.Drawing.ColorTranslator.FromHtml("#E94560");
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(15, 492);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 36);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ── btnClear ──────────────────────────────────────
            this.btnClear.BackColor = System.Drawing.ColorTranslator.FromHtml("#555555");
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(140, 492);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 36);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "🔄 Clear";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── dgvSuppliers ──────────────────────────────────
            this.dgvSuppliers.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#1A1A2E");
            this.dgvSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSuppliers.AllowUserToAddRows = false;
            this.dgvSuppliers.AllowUserToDeleteRows = false;
            this.dgvSuppliers.ReadOnly = true;
            this.dgvSuppliers.RowHeadersVisible = false;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.MultiSelect = false;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.Location = new System.Drawing.Point(275, 70);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.Size = new System.Drawing.Size(665, 490);
            this.dgvSuppliers.TabIndex = 12;
            this.dgvSuppliers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSuppliers_CellClick);

            // ── SupplierForm ──────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#1A1A2E");
            this.ClientSize = new System.Drawing.Size(960, 580);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Management — Pharmacy MS";
            this.Load += new System.EventHandler(this.SupplierForm_Load);

            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblCity);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvSuppliers);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Control Declarations ──────────────────────────────
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSuppliers;
    }
}