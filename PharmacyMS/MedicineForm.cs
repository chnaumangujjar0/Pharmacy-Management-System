using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyMS
{
    public partial class MedicineForm : Form
    {
        public MedicineForm()
        {
            InitializeComponent();
        }

        // ── Form Load ─────────────────────────────────────────
        private void MedicineForm_Load(object sender, EventArgs e)
        {
            LoadMedicines(); // ← Auto load when form opens
        }

        // ── Load All Medicines ────────────────────────────────
        private void LoadMedicines()
        {
            try
            {
                string query = "SELECT MedicineId   AS 'ID'," +
                                      "Name         AS 'Medicine Name'," +
                                      "Category     AS 'Category'," +
                                      "Price        AS 'Price (Rs)'," +
                                      "Stock        AS 'Stock'," +
                                      "ExpiryDate   AS 'Expiry Date'," +
                                      "Supplier     AS 'Supplier'" +
                               " FROM Medicines ORDER BY Name ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
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

        // ── Add Medicine ──────────────────────────────────────
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            // ✅ Validation
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please enter Medicine Name!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("Please enter Price!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtStock.Text.Trim()))
            {
                MessageBox.Show("Please enter Stock quantity!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }

            // ✅ Validate Price is a number
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid Price!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            // ✅ Validate Stock is a number
            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Please enter a valid Stock quantity!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return;
            }

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
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@expiry", dtExpiry.Value.Date);
                    cmd.Parameters.AddWithValue("@supplier", txtSupplier.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Medicine Added Successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadMedicines(); // ← Auto refresh grid
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error adding medicine:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        // ── Clear Fields ─────────────────────────────────────
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtStock.Clear();
            txtSupplier.Clear();
            dtExpiry.Value = DateTime.Now; // ← Reset date to today
            txtName.Focus();               // ← Focus on first field
        }

        // ── Click Row → Fill Fields (for Day 5 Update/Delete) ─
        private void dgvMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMedicines.Rows[e.RowIndex];

                txtName.Text = row.Cells["Medicine Name"].Value?.ToString();
                txtCategory.Text = row.Cells["Category"].Value?.ToString();
                txtPrice.Text = row.Cells["Price (Rs)"].Value?.ToString();
                txtStock.Text = row.Cells["Stock"].Value?.ToString();
                txtSupplier.Text = row.Cells["Supplier"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Expiry Date"].Value?.ToString(),
                                      out DateTime expiry))
                {
                    dtExpiry.Value = expiry;
                }
            }

        }

        
    }
}