using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class MedicineForm : Form
    {
        public MedicineForm()
        {
            InitializeComponent();
        }
        private void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.GridColor = System.Drawing.Color.FromArgb(13, 46, 82);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowTemplate.Height = 30; // ← Taller rows
        }
        // ── Form Load ─────────────────────────────────────────
        private void MedicineForm_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyFormTheme(this);
            ThemeHelper.ApplyHeader(pnlHeader, lblTitle);
            ThemeHelper.ApplyButton(btnAdd, ThemeHelper.AccentGreen);
            ThemeHelper.ApplyButton(btnUpdate, ThemeHelper.AccentPurple);
            ThemeHelper.ApplyButton(btnDelete, ThemeHelper.AccentPink);
            ThemeHelper.ApplyButton(btnClear, ColorTranslator.FromHtml("#7F8C8D"));
            ThemeHelper.ApplyTextBox(txtName);
            ThemeHelper.ApplyTextBox(txtCategory);
            ThemeHelper.ApplyTextBox(txtPrice);
            ThemeHelper.ApplyTextBox(txtStock);
            ThemeHelper.ApplyTextBox(txtSupplier);
            ThemeHelper.ApplyTextBox(txtSearch);
            ThemeHelper.ApplyGrid(dgvMedicines);
            ThemeHelper.FadeIn(this);
            StyleGrid(dgvMedicines);        
            LoadMedicines();
            txtSearch.TextChanged += TxtSearch_TextChanged; // ← Live search
        }

        // ── Load All Medicines ────────────────────────────────
        private void LoadMedicines(string search = "")
        {
            try
            {
                string query;

                if (string.IsNullOrEmpty(search))
                {
                    // Load ALL medicines
                    query = "SELECT MedicineId   AS 'ID'," +
                                   "Name         AS 'Medicine Name'," +
                                   "Category     AS 'Category'," +
                                   "Price        AS 'Price (Rs)'," +
                                   "Stock        AS 'Stock'," +
                                   "ExpiryDate   AS 'Expiry Date'," +
                                   "Supplier     AS 'Supplier'" +
                            " FROM Medicines ORDER BY Name ASC";
                }
                else
                {
                    // Search by name
                    query = "SELECT MedicineId   AS 'ID'," +
                                   "Name         AS 'Medicine Name'," +
                                   "Category     AS 'Category'," +
                                   "Price        AS 'Price (Rs)'," +
                                   "Stock        AS 'Stock'," +
                                   "ExpiryDate   AS 'Expiry Date'," +
                                   "Supplier     AS 'Supplier'" +
                            " FROM Medicines" +
                            " WHERE Name LIKE @search" +
                            " ORDER BY Name ASC";
                }

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvMedicines.DataSource = table;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error loading medicines:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Live Search ───────────────────────────────────────
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadMedicines(txtSearch.Text.Trim());
        }

        // ── Click Row → Fill Fields ───────────────────────────
        private void dgvMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicines.Rows[e.RowIndex];

                // ✅ Store ID in hidden field
                txtId.Text = row.Cells["ID"].Value?.ToString();
                txtName.Text = row.Cells["Medicine Name"].Value?.ToString();
                txtCategory.Text = row.Cells["Category"].Value?.ToString();
                txtPrice.Text = row.Cells["Price (Rs)"].Value?.ToString();
                txtStock.Text = row.Cells["Stock"].Value?.ToString();
                txtSupplier.Text = row.Cells["Supplier"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Expiry Date"].Value?.ToString(),
                                      out DateTime expiry))
                    dtExpiry.Value = expiry;

                // ✅ Enable Update & Delete buttons
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        // ── Add Medicine ──────────────────────────────────────
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                string query = @"INSERT INTO Medicines
                                (Name, Category, Price, Stock, ExpiryDate, Supplier)
                                VALUES
                                (@name, @cat, @price, @stock, @expiry, @supplier)";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@cat", txtCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                    cmd.Parameters.AddWithValue("@expiry", dtExpiry.Value.Date);
                    cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Medicine Added Successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicines();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update Medicine ───────────────────────────────────
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a medicine from the list first!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateFields()) return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to update: " + txtName.Text + "?",
                "Confirm Update",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                string query = @"UPDATE Medicines SET
                                 Name       = @name,
                                 Category   = @cat,
                                 Price      = @price,
                                 Stock      = @stock,
                                 ExpiryDate = @expiry,
                                 Supplier   = @supplier
                                 WHERE MedicineId = @id";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@cat", txtCategory.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", decimal.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                    cmd.Parameters.AddWithValue("@expiry", dtExpiry.Value.Date);
                    cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Medicine Updated Successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicines();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete Medicine ───────────────────────────────────
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Please select a medicine from the list first!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "⚠️ Are you sure you want to DELETE: " + txtName.Text + "?\n\nThis cannot be undone!",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.No) return;

            try
            {
                string query = "DELETE FROM Medicines WHERE MedicineId = @id";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Medicine Deleted Successfully!",
                                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicines();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Clear Button ──────────────────────────────────────
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }

        // ── Helper: Clear All Fields ──────────────────────────
        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtSupplier.Clear();
            dtExpiry.Value = DateTime.Now;
            txtName.Focus();

            // ← Disable Update & Delete until row selected again
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        // ── Helper: Validate Fields ───────────────────────────
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter Medicine Name!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Please enter a valid Price!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Please enter a valid Stock quantity!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            return true;
        }

        
    }
}