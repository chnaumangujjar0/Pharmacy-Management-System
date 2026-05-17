using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class SalesForm : Form
    {
        // ✅ Cart stored in memory as DataTable
        private DataTable cartTable = new DataTable();

        public SalesForm()
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
        private void SalesForm_Load_1(object sender, EventArgs e)
        {
            ThemeHelper.ApplyFormTheme(this);
            ThemeHelper.ApplyHeader(pnlHeader, lblTitle);
            ThemeHelper.ApplyButton(btnAddToCart, ThemeHelper.AccentPurple);
            ThemeHelper.ApplyButton(btnCompleteSale, ThemeHelper.AccentPink);
            ThemeHelper.ApplyButton(btnRemoveItem, ColorTranslator.FromHtml("#E74C3C"));
            ThemeHelper.ApplyComboBox(cmbMedicine);
            ThemeHelper.ApplyTextBox(txtCustomer);
            ThemeHelper.ApplyTextBox(txtQuantity);
            ThemeHelper.ApplyGrid(dgvCart);
            ThemeHelper.ApplyGrid(dgvSales);
            ThemeHelper.FadeIn(this);
            StyleGrid(dgvCart);
            SetupCartTable();          // ← Create cart columns
            LoadMedicinesDropdown();   // ← Fill dropdown
            LoadTodaySales();          // ← Load today's sales
            LoadTodayRevenue();        // ← Show revenue

            cmbMedicine.SelectedIndexChanged += CmbMedicine_SelectedIndexChanged;
            txtQuantity.TextChanged += TxtQuantity_TextChanged;
        }

        // ── Setup Cart DataTable Columns ──────────────────────
        private void SetupCartTable()
        {
            cartTable.Columns.Add("MedicineId", typeof(int));
            cartTable.Columns.Add("Medicine", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Unit Price", typeof(decimal));
            cartTable.Columns.Add("Total", typeof(decimal));

            dgvCart.DataSource = cartTable;

            // ← Hide MedicineId column from user
            dgvCart.Columns["MedicineId"].Visible = false;
        }

        // ── Load Medicines Dropdown ───────────────────────────
        private void LoadMedicinesDropdown()
        {
            try
            {
                string query = "SELECT MedicineId, Name, Price, Stock FROM Medicines ORDER BY Name ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    cmbMedicine.DataSource = table;
                    cmbMedicine.DisplayMember = "Name";
                    cmbMedicine.ValueMember = "MedicineId";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Auto Show Price ───────────────────────────────────
        private void CmbMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void TxtQuantity_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            try
            {
                if (cmbMedicine.SelectedValue == null) return;

                DataRowView row = (DataRowView)cmbMedicine.SelectedItem;
                decimal unitPrice = Convert.ToDecimal(row["Price"]);
                int availStock = Convert.ToInt32(row["Stock"]);

                lblUnitPrice.Text = "Rs. " + unitPrice.ToString("0.00");

                if (int.TryParse(txtQuantity.Text, out int qty) && qty > 0)
                {
                    decimal total = unitPrice * qty;
                    lblTotalPrice.Text = "Rs. " + total.ToString("0.00");

                    if (qty > availStock)
                    {
                        lblTotalPrice.Text = "⚠️ Only " + availStock + " available!";
                        lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
                    }
                    else
                    {
                        lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
                    }
                }
                else
                {
                    lblTotalPrice.Text = "Rs. 0.00";
                }
            }
            catch { }
        }

        // ── Add to Cart Button ────────────────────────────────
        private void btnAddToCart_Click_1(object sender, EventArgs e)
        {
            if (cmbMedicine.SelectedValue == null)
            {
                MessageBox.Show("Please select a Medicine!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Please enter a valid Quantity!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            DataRowView row = (DataRowView)cmbMedicine.SelectedItem;
            int medicineId = (int)cmbMedicine.SelectedValue;
            string medicineName = row["Name"].ToString();
            decimal unitPrice = Convert.ToDecimal(row["Price"]);
            int availStock = Convert.ToInt32(row["Stock"]);
            decimal total = unitPrice * qty;

            // ✅ Check stock
            if (qty > availStock)
            {
                MessageBox.Show($"❌ Only {availStock} units available!",
                                "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ✅ Check if medicine already in cart
            foreach (DataRow r in cartTable.Rows)
            {
                if ((int)r["MedicineId"] == medicineId)
                {
                    MessageBox.Show($"{medicineName} is already in cart!\nRemove it first to change quantity.",
                                    "Already Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // ✅ Add to cart table
            cartTable.Rows.Add(medicineId, medicineName, qty, unitPrice, total);

            UpdateGrandTotal();        // ← Refresh grand total
            btnCompleteSale.Enabled = true; // ← Enable complete button

            // ← Clear for next item
            txtQuantity.Clear();
            lblTotalPrice.Text = "Rs. 0.00";
            cmbMedicine.Focus();
        }

        // ── Remove Item from Cart ─────────────────────────────
        private void btnRemoveItem_Click_1(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an item to remove!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedIndex = dgvCart.SelectedRows[0].Index;
            cartTable.Rows[selectedIndex].Delete();

            UpdateGrandTotal();

            // ← Disable complete if cart empty
            if (cartTable.Rows.Count == 0)
                btnCompleteSale.Enabled = false;
        }

        // ── Update Grand Total ────────────────────────────────
        private void UpdateGrandTotal()
        {
            decimal grandTotal = 0;
            foreach (DataRow r in cartTable.Rows)
                grandTotal += Convert.ToDecimal(r["Total"]);

            lblGrandTotal.Text = $"Grand Total: Rs. {grandTotal:0.00}";
        }

        // ── Complete Sale Button ──────────────────────────────
        private void btnCompleteSale_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomer.Text.Trim()))
            {
                MessageBox.Show("Please enter Customer Name!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomer.Focus();
                return;
            }

            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty! Add medicines first.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ← Build receipt summary
            string receipt = $"Customer: {txtCustomer.Text.Trim()}\n";
            receipt += "─────────────────────────\n";

            decimal grandTotal = 0;
            foreach (DataRow r in cartTable.Rows)
            {
                receipt += $"{r["Medicine"]} x{r["Quantity"]} = Rs. {r["Total"]}\n";
                grandTotal += Convert.ToDecimal(r["Total"]);
            }

            receipt += "─────────────────────────\n";
            receipt += $"Grand Total: Rs. {grandTotal:0.00}";

            DialogResult confirm = MessageBox.Show(
                receipt + "\n\nConfirm Sale?",
                "Confirm Sale",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No) return;

            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();

                    // ✅ Save each cart item as a sale
                    foreach (DataRow r in cartTable.Rows)
                    {
                        int medicineId = (int)r["MedicineId"];
                        int qty = (int)r["Quantity"];
                        decimal unitPrice = (decimal)r["Unit Price"];
                        decimal total = (decimal)r["Total"];

                        // ← Insert Sale
                        string saleQuery = @"INSERT INTO Sales
                                            (MedicineId, Quantity, UnitPrice, TotalPrice, CustomerName)
                                            VALUES (@mid, @qty, @unit, @total, @customer)";

                        using (SqlCommand cmd = new SqlCommand(saleQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@mid", medicineId);
                            cmd.Parameters.AddWithValue("@qty", qty);
                            cmd.Parameters.AddWithValue("@unit", unitPrice);
                            cmd.Parameters.AddWithValue("@total", total);
                            cmd.Parameters.AddWithValue("@customer", txtCustomer.Text.Trim());
                            cmd.ExecuteNonQuery();
                        }

                        // ← Reduce Stock
                        string stockQuery = "UPDATE Medicines SET Stock = Stock - @qty WHERE MedicineId = @id";

                        using (SqlCommand cmd = new SqlCommand(stockQuery, con))
                        {
                            cmd.Parameters.AddWithValue("@qty", qty);
                            cmd.Parameters.AddWithValue("@id", medicineId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    $"✅ Sale Completed!\n\nGrand Total: Rs. {grandTotal:0.00}\n\nThank you, {txtCustomer.Text.Trim()}!",
                    "Sale Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ← Clear everything
                clearFields();
                cartTable.Rows.Clear();
                txtCustomer.Clear();
                txtQuantity.Clear();
                lblUnitPrice.Text = "Rs. 0.00";
                lblTotalPrice.Text = "Rs. 0.00";
                lblGrandTotal.Text = "Grand Total: Rs. 0.00";
                btnCompleteSale.Enabled = false;

                LoadMedicinesDropdown();
                LoadTodaySales();
                LoadTodayRevenue();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Today's Sales Grid ───────────────────────────
        private void LoadTodaySales()
        {
            try
            {
                string query = @"SELECT
                                    m.Name         AS 'Medicine',
                                    s.Quantity     AS 'Qty',
                                    s.UnitPrice    AS 'Unit Price',
                                    s.TotalPrice   AS 'Total (Rs)',
                                    s.CustomerName AS 'Customer',
                                    s.SaleDate     AS 'Time'
                                FROM Sales s
                                JOIN Medicines m ON s.MedicineId = m.MedicineId
                                WHERE CAST(s.SaleDate AS DATE) = CAST(GETDATE() AS DATE)
                                ORDER BY s.SaleDate DESC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvSales.DataSource = table;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Load Today's Revenue ──────────────────────────────
        private void LoadTodayRevenue()
        {
            try
            {
                string query = @"SELECT ISNULL(SUM(TotalPrice),0)
                                 FROM Sales
                                 WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    decimal revenue = (decimal)cmd.ExecuteScalar();
                    lblRevenue.Text = "💰 Today's Revenue: Rs. " + revenue.ToString("0.00");
                }
            }
            catch { }
        }

        // ── Clear Button ──────────────────────────────────────
        private void clearFields()
        {
            txtCustomer.Clear();
            txtQuantity.Clear();
            cartTable.Rows.Clear();
            lblUnitPrice.Text = "Rs. 0.00";
            lblTotalPrice.Text = "Rs. 0.00";
            lblGrandTotal.Text = "Grand Total: Rs. 0.00";
            btnCompleteSale.Enabled = false;
        }

        // ── Get Payment Method ────────────────────────────────
        private string GetPaymentMethod()
        {
            if (rbCard.Checked) return "Card";
            if (rbInsurance.Checked) return "Insurance";
            return "Cash";
        }

        // ── Print Receipt ─────────────────────────────────────
        private void PrintReceipt(string customerName, decimal grandTotal)
        {
            System.Text.StringBuilder receipt = new System.Text.StringBuilder();

            receipt.AppendLine("╔══════════════════════════════════╗");
            receipt.AppendLine("║      PHARMACY MANAGEMENT SYSTEM  ║");
            receipt.AppendLine("║         Sales Receipt            ║");
            receipt.AppendLine("╚══════════════════════════════════╝");
            receipt.AppendLine($"Date     : {DateTime.Now:dd/MM/yyyy HH:mm}");
            receipt.AppendLine($"Customer : {customerName}");
            receipt.AppendLine($"Payment  : {GetPaymentMethod()}");
            receipt.AppendLine("──────────────────────────────────");

            foreach (DataRow r in cartTable.Rows)
            {
                receipt.AppendLine($"{r["Medicine"],-20} x{r["Quantity"]}");
                receipt.AppendLine($"  @ Rs.{r["Unit Price"]} = Rs.{r["Total"]}");
            }

            receipt.AppendLine("──────────────────────────────────");
            receipt.AppendLine($"Grand Total : Rs. {grandTotal:0.00}");
            receipt.AppendLine("══════════════════════════════════");
            receipt.AppendLine("    Thank you for your purchase!   ");
            receipt.AppendLine("══════════════════════════════════");

            // ← Show receipt in a message box
            MessageBox.Show(receipt.ToString(), "🧾 Receipt",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ← Call PrintReceipt after successful sale
        private void btnPrintReceipt_Click_1(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("No items in cart!", "Empty Cart",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal total = 0;
            foreach (DataRow r in cartTable.Rows)
                total += Convert.ToDecimal(r["Total"]);

            PrintReceipt(txtCustomer.Text.Trim(), total);
        }

        
    }
}