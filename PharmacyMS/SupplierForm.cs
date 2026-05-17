using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PharmacyMS
{
    public partial class SupplierForm : Form
    {
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            ThemeHelper.ApplyFormTheme(this);
            ThemeHelper.ApplyHeader(pnlHeader, lblTitle);
            ThemeHelper.ApplyButton(btnAdd, ThemeHelper.AccentGreen);
            ThemeHelper.ApplyButton(btnUpdate, ThemeHelper.AccentPurple);
            ThemeHelper.ApplyButton(btnDelete, ThemeHelper.AccentPink);
            ThemeHelper.ApplyButton(btnClear, System.Drawing.ColorTranslator.FromHtml("#7F8C8D"));
            ThemeHelper.ApplyTextBox(txtName);
            ThemeHelper.ApplyTextBox(txtContact);
            ThemeHelper.ApplyTextBox(txtPhone);
            ThemeHelper.ApplyTextBox(txtEmail);
            ThemeHelper.ApplyTextBox(txtAddress);
            ThemeHelper.ApplyTextBox(txtCity);
            ThemeHelper.ApplyTextBox(txtSearch);
            ThemeHelper.ApplyGrid(dgvSuppliers);
            ThemeHelper.FadeIn(this);
            LoadSuppliers();
        }

        private void LoadSuppliers(string search = "")
        {
            try
            {
                string query = string.IsNullOrEmpty(search)
                    ? "SELECT * FROM Suppliers ORDER BY SupplierName"
                    : "SELECT * FROM Suppliers WHERE SupplierName LIKE @s OR City LIKE @s ORDER BY SupplierName";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(search))
                        cmd.Parameters.AddWithValue("@s", "%" + search + "%");

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSuppliers.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Validation Helper ─────────────────────────────────
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Supplier Name is required!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus(); return false;
            }

            if (!string.IsNullOrEmpty(txtPhone.Text) &&
                txtPhone.Text.Trim().Length < 11)
            {
                MessageBox.Show("Phone Number must be at least 11 digits!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus(); return false;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text) &&
                !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid Email address!", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus(); return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            ThemeHelper.AnimateButton(btnAdd);

            try
            {
                string query = @"INSERT INTO Suppliers
                                (SupplierName, ContactPerson, PhoneNumber, Email, Address, City, Status)
                                VALUES (@name, @contact, @phone, @email, @address, @city, 'Active')";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Supplier Added Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadSuppliers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) { MessageBox.Show("Select a supplier first!"); return; }
            if (!ValidateFields()) return;
            ThemeHelper.AnimateButton(btnUpdate);

            try
            {
                string query = @"UPDATE Suppliers SET
                                 SupplierName=@name, ContactPerson=@contact,
                                 PhoneNumber=@phone, Email=@email,
                                 Address=@address, City=@city
                                 WHERE SupplierId=@id";

                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", txtCity.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Supplier Updated!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadSuppliers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) { MessageBox.Show("Select a supplier first!"); return; }

            if (MessageBox.Show("Delete this supplier?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            ThemeHelper.AnimateButton(btnDelete);

            try
            {
                using (SqlConnection con = DBHelper.GetConnection())
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Suppliers WHERE SupplierId=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Supplier Deleted!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadSuppliers();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvSuppliers.Rows[e.RowIndex];
            txtId.Text = row.Cells["SupplierId"].Value?.ToString();
            txtName.Text = row.Cells["SupplierName"].Value?.ToString();
            txtContact.Text = row.Cells["ContactPerson"].Value?.ToString();
            txtPhone.Text = row.Cells["PhoneNumber"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            txtCity.Text = row.Cells["City"].Value?.ToString();
            btnUpdate.Enabled = btnDelete.Enabled = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers(txtSearch.Text.Trim());
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtId.Clear(); txtName.Clear(); txtContact.Clear();
            txtPhone.Clear(); txtEmail.Clear(); txtAddress.Clear();
            txtCity.Clear(); txtName.Focus();
            btnUpdate.Enabled = btnDelete.Enabled = false;
        }
    }
}