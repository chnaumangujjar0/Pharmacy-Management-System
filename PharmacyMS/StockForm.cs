using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyMS
{
    public partial class StockForm : Form
    {
        public StockForm()
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
        private void StockForm_Load(object sender, EventArgs e)
        {
            StyleGrid(dgvStock);
            LoadMedicinesDropdown(); // ← Fill combobox
            LoadStockGrid();         // ← Load stock table
            LoadStockHistory();      // ← Load history table
        }

        // ── Load Medicines into Dropdown ──────────────────────
        private void LoadMedicinesDropdown()
        {
            try
            {
                string query = "SELECT MedicineId, Name, Stock FROM Medicines ORDER BY Name ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    cmbMedicine.DataSource = table;
                    cmbMedicine.DisplayMember = "Name";       // ← Shows medicine name
                    cmbMedicine.ValueMember = "MedicineId"; // ← Stores ID
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error loading medicines:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Stock Grid ───────────────────────────────────
        private void LoadStockGrid()
        {
            try
            {
                string query = @"SELECT 
                                    Name        AS 'Medicine',
                                    Category    AS 'Category',
                                    Stock       AS 'Current Stock',
                                    ExpiryDate  AS 'Expiry Date',
                                    Supplier    AS 'Supplier',
                                    CASE 
                                        WHEN Stock < 10 THEN ' Low'
                                        WHEN Stock < 30 THEN ' Medium'
                                        ELSE ' Good'
                                    END AS 'Status'
                                FROM Medicines
                                ORDER BY Stock ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvStock.DataSource = table;
                }

                // ← Update low stock count label
                UpdateLowStockLabel();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error loading stock:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Stock History ────────────────────────────────
        private void LoadStockHistory()
        {
            try
            {
                string query = @"SELECT 
                                    m.Name       AS 'Medicine',
                                    h.AddedStock AS 'Stock Added',
                                    h.AddedBy    AS 'Added By',
                                    h.Remarks    AS 'Remarks',
                                    h.AddedDate  AS 'Date & Time'
                                FROM StockHistory h
                                JOIN Medicines m ON h.MedicineId = m.MedicineId
                                ORDER BY h.AddedDate DESC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvHistory.DataSource = table;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error loading history:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Update Low Stock Label ────────────────────────────
        private void UpdateLowStockLabel()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Medicines WHERE Stock < 10";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    lblLowStock.Text = "⚠️ Low Stock Medicines: " + count;
                    lblLowStock.ForeColor = count > 0
                        ? System.Drawing.Color.FromArgb(231, 76, 60)   // ← Red
                        : System.Drawing.Color.FromArgb(79, 195, 161); // ← Teal
                }
            }
            catch { }
        }

        // ── Add Stock Button ──────────────────────────────────
        private void btnAddStock_Click_1(object sender, EventArgs e)
        {
            // ✅ Validation
            if (cmbMedicine.SelectedValue == null)
            {
                MessageBox.Show("Please select a Medicine!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
            {
                MessageBox.Show("Please enter Quantity!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid Quantity (must be greater than 0)!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            int medicineId = (int)cmbMedicine.SelectedValue;
            string medicineName = cmbMedicine.Text;
            string remarks = string.IsNullOrEmpty(txtRemarks.Text.Trim())
                             ? "Stock added" : txtRemarks.Text.Trim();

            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();

                    // ✅ Update Medicine Stock
                    string updateQuery = "UPDATE Medicines SET Stock = Stock + @qty WHERE MedicineId = @id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@id", medicineId);
                        cmd.ExecuteNonQuery();
                    }

                    // ✅ Insert into Stock History
                    string historyQuery = @"INSERT INTO StockHistory 
                                           (MedicineId, AddedStock, Remarks, AddedBy)
                                           VALUES (@id, @qty, @remarks, @by)";
                    using (SqlCommand cmd = new SqlCommand(historyQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@id", medicineId);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@remarks", remarks);
                        cmd.Parameters.AddWithValue("@by", "Admin");
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show($"✅ {qty} units added to {medicineName} successfully!",
                                "Stock Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Clear & Refresh
                txtQuantity.Clear();
                txtRemarks.Clear();
                LoadMedicinesDropdown();
                LoadStockGrid();
                LoadStockHistory();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error updating stock:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}