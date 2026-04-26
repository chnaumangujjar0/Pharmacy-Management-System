using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        // ── Load Stats ────────────────────────────────────────
        private void LoadStats()
        {
            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();

                    // ✅ Total Medicines
                    string q1 = "SELECT COUNT(*) FROM Medicines";
                    using (SqlCommand cmd = new SqlCommand(q1, con))
                    {
                        lblTotalMedicines.Text = "💊 Total Medicines: " + cmd.ExecuteScalar();
                    }

                    // ✅ Low Stock (less than 10)
                    string q2 = "SELECT COUNT(*) FROM Medicines WHERE Stock < 10";
                    using (SqlCommand cmd = new SqlCommand(q2, con))
                    {
                        int lowStock = (int)cmd.ExecuteScalar();
                        lblLowStock.Text = "⚠️ Low Stock: " + lowStock;

                        // ← Turn red if low stock exists
                        lblLowStock.ForeColor = lowStock > 0
                            ? System.Drawing.Color.FromArgb(231, 76, 60)
                            : System.Drawing.Color.FromArgb(79, 195, 161);
                    }

                    // ✅ Today's Sales
                    string q3 = "SELECT COUNT(*) FROM Sales WHERE CAST(SaleDate AS DATE) = CAST(GETDATE() AS DATE)";
                    using (SqlCommand cmd = new SqlCommand(q3, con))
                    {
                        lblTodaySales.Text = "🧾 Today's Sales: " + cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ Error loading stats:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Navigation Buttons ────────────────────────────────

        private void btnMedicines_Click_1(object sender, EventArgs e)
        {
            MedicineForm medicineForm = new MedicineForm();
            medicineForm.Show();
            medicineForm.FormClosed += (s, args) => LoadStats(); // ← Refresh stats when closed

        }

        private void btnStock_Click_1(object sender, EventArgs e)
        {
            StockForm stockForm = new StockForm();
            stockForm.Show();
            stockForm.FormClosed += (s, args) => LoadStats();

        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            SalesForm salesForm = new SalesForm();
            salesForm.Show();
            salesForm.FormClosed += (s, args) => LoadStats();
        }

        private void btnReports_Click_1(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        // ── Logout ────────────────────────────────────────────
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Close(); // ← Close dashboard
            }
        }

        
    }
}
