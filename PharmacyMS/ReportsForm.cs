using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
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
        private void ReportsForm_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyFormTheme(this);
            ThemeHelper.ApplyHeader(pnlHeader, lblTitle);
            ThemeHelper.ApplyButton(btnLoadToday, ThemeHelper.AccentPink);
            ThemeHelper.ApplyButton(btnDateRange, ThemeHelper.AccentPurple);
            ThemeHelper.ApplyButton(btnBestSelling, ThemeHelper.AccentGold);
            ThemeHelper.ApplyButton(btnLowStock, ColorTranslator.FromHtml("#E74C3C"));
            ThemeHelper.ApplyButton(btnExpiry, ThemeHelper.AccentGreen);
            ThemeHelper.ApplyButton(btnExport, ColorTranslator.FromHtml("#27AE60"));
            ThemeHelper.ApplyGrid(dgvTodayReport);
            ThemeHelper.ApplyGrid(dgvDateRange);
            ThemeHelper.ApplyGrid(dgvBestSelling);
            ThemeHelper.ApplyGrid(dgvLowStock);
            ThemeHelper.ApplyGrid(dgvExpiry);
            ThemeHelper.FadeIn(this);
            // ← Set default dates
            dtFrom.Value = DateTime.Now.AddDays(-30);
            dtTo.Value = DateTime.Now;

            // ← Auto load today's report
            StyleGrid(dgvTodayReport);
            LoadTodayReport();
        }

        // ── TAB 1: Today's Sales Report ───────────────────────
        private void btnLoadToday_Click_1(object sender, EventArgs e)
        {
            LoadTodayReport();
        }

        private void LoadTodayReport()
        {
            try
            {
                string query = @"SELECT
                                    m.Name         AS 'Medicine',
                                    s.Quantity     AS 'Quantity',
                                    s.UnitPrice    AS 'Unit Price (Rs)',
                                    s.TotalPrice   AS 'Total (Rs)',
                                    s.CustomerName AS 'Customer',
                                    CONVERT(VARCHAR, s.SaleDate, 108) AS 'Time'
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
                    dgvTodayReport.DataSource = table;

                    // ← Update summary labels
                    lblTodaySalesCount.Text =  table.Rows.Count.ToString();
                    lblTodaySalesCount.ForeColor = System.Drawing.Color.FromArgb(79, 195, 161);
                }

                // ← Get today's revenue
                string revenueQuery = @"SELECT ISNULL(SUM(TotalPrice), 0)
                                        FROM Sales
                                        WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(revenueQuery, con))
                {
                    con.Open();
                    decimal revenue = (decimal)cmd.ExecuteScalar();
                    lblTodayRevenue.Text = revenue.ToString("0.00");
                    lblTodayRevenue.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── TAB 2: Date Range Report ──────────────────────────
        private void btnDateRange_Click_1(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtFrom.Value.Date;
                DateTime toDate = dtTo.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("'From' date cannot be after 'To' date!",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"SELECT
                                    m.Name         AS 'Medicine',
                                    s.Quantity     AS 'Quantity',
                                    s.UnitPrice    AS 'Unit Price (Rs)',
                                    s.TotalPrice   AS 'Total (Rs)',
                                    s.CustomerName AS 'Customer',
                                    CONVERT(VARCHAR, s.SaleDate, 106) AS 'Date'
                                FROM Sales s
                                JOIN Medicines m ON s.MedicineId = m.MedicineId
                                WHERE CAST(s.SaleDate AS DATE)
                                      BETWEEN @from AND @to
                                ORDER BY s.SaleDate DESC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvDateRange.DataSource = table;

                    // ← Calculate total revenue for range
                    decimal total = 0;
                    foreach (DataRow r in table.Rows)
                        total += Convert.ToDecimal(r["Total (Rs)"]);

                    lblRangeRevenue.Text = "Total: Rs. " + total.ToString("0.00");
                    lblRangeRevenue.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── TAB 3: Best Selling Medicines ─────────────────────
        private void btnBestSelling_Click_1(object sender, EventArgs e)
        {
            try
            {
                string query = @"SELECT TOP 10
                                    m.Name              AS 'Medicine',
                                    m.Category          AS 'Category',
                                    SUM(s.Quantity)     AS 'Total Sold',
                                    SUM(s.TotalPrice)   AS 'Total Revenue (Rs)',
                                    COUNT(s.SaleId)     AS 'No of Sales'
                                FROM Sales s
                                JOIN Medicines m ON s.MedicineId = m.MedicineId
                                GROUP BY m.Name, m.Category
                                ORDER BY SUM(s.Quantity) DESC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvBestSelling.DataSource = table;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── TAB 4: Low Stock Alert ────────────────────────────
        private void btnLowStock_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStockLimit.Text, out int limit) || limit <= 0)
            {
                MessageBox.Show("Please enter a valid stock limit!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT
                                    Name        AS 'Medicine',
                                    Category    AS 'Category',
                                    Stock       AS 'Current Stock',
                                    Supplier    AS 'Supplier',
                                    ExpiryDate  AS 'Expiry Date',
                                    CASE
                                        WHEN Stock = 0 THEN ' OUT OF STOCK'
                                        WHEN Stock < 5 THEN ' Critical'
                                        ELSE ' Low'
                                    END AS 'Status'
                                FROM Medicines
                                WHERE Stock <= @limit
                                ORDER BY Stock ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@limit", limit);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLowStock.DataSource = table;

                    if (table.Rows.Count == 0)
                        MessageBox.Show("✅ All medicines have sufficient stock!",
                                        "Good News", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── TAB 5: Expiry Alert ───────────────────────────────
        private void btnExpiry_Click_1(object sender, EventArgs e)
        {
            if (!int.TryParse(txtExpiryDays.Text, out int days) || days <= 0)
            {
                MessageBox.Show("Please enter valid number of days!",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"SELECT
                                    Name        AS 'Medicine',
                                    Category    AS 'Category',
                                    Stock       AS 'Stock',
                                    ExpiryDate  AS 'Expiry Date',
                                    Supplier    AS 'Supplier',
                                    DATEDIFF(DAY, GETDATE(), ExpiryDate) AS 'Days Left',
                                    CASE
                                        WHEN ExpiryDate < GETDATE()
                                             THEN ' EXPIRED'
                                        WHEN DATEDIFF(DAY, GETDATE(), ExpiryDate) <= 7
                                             THEN ' Expires This Week'
                                        WHEN DATEDIFF(DAY, GETDATE(), ExpiryDate) <= 30
                                             THEN ' Expires This Month'
                                        ELSE ' Expiring Soon'
                                    END AS 'Status'
                                FROM Medicines
                                WHERE ExpiryDate <= DATEADD(DAY, @days, GETDATE())
                                ORDER BY ExpiryDate ASC";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@days", days);

                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvExpiry.DataSource = table;

                    if (table.Rows.Count == 0)
                        MessageBox.Show($"✅ No medicines expiring within {days} days!",
                                        "Good News", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Export Active Tab to CSV ──────────────────────────
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // ← Get active grid
                DataGridView activeGrid = null;
                string fileName = "Report";

                if (tabReports.SelectedTab == tabToday)
                { activeGrid = dgvTodayReport; fileName = "TodaySales"; }
                else if (tabReports.SelectedTab == tabDateRange)
                { activeGrid = dgvDateRange; fileName = "DateRangeReport"; }
                else if (tabReports.SelectedTab == tabBestSelling)
                { activeGrid = dgvBestSelling; fileName = "BestSelling"; }
                else if (tabReports.SelectedTab == tabLowStock)
                { activeGrid = dgvLowStock; fileName = "LowStock"; }
                else if (tabReports.SelectedTab == tabExpiry)
                { activeGrid = dgvExpiry; fileName = "ExpiryAlert"; }

                if (activeGrid == null || activeGrid.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Export",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ← Save file dialog
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "CSV Files|*.csv",
                    FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd")
                };

                if (save.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(save.FileName))
                    {
                        // ← Write headers
                        string[] headers = new string[activeGrid.Columns.Count];
                        for (int i = 0; i < activeGrid.Columns.Count; i++)
                            headers[i] = activeGrid.Columns[i].HeaderText;
                        sw.WriteLine(string.Join(",", headers));

                        // ← Write rows
                        foreach (DataGridViewRow row in activeGrid.Rows)
                        {
                            string[] cells = new string[activeGrid.Columns.Count];
                            for (int i = 0; i < activeGrid.Columns.Count; i++)
                                cells[i] = row.Cells[i].Value?.ToString() ?? "";
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    MessageBox.Show("✅ Report exported successfully!\n" + save.FileName,
                                    "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Export Error:\n" + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}