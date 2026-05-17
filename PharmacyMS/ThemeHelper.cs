using System;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyMS
{
    public static class ThemeHelper
    {
        // ── Color Palette ─────────────────────────────────────
        public static Color BgPrimary = ColorTranslator.FromHtml("#1A1A2E");
        public static Color BgSecondary = ColorTranslator.FromHtml("#16213E");
        public static Color BgCard = ColorTranslator.FromHtml("#0F3460");
        public static Color AccentPink = ColorTranslator.FromHtml("#E94560");
        public static Color AccentGold = ColorTranslator.FromHtml("#F5A623");
        public static Color AccentGreen = ColorTranslator.FromHtml("#00B4D8");
        public static Color AccentPurple = ColorTranslator.FromHtml("#7B2FBE");
        public static Color TextPrimary = Color.White;
        public static Color TextSecondary = ColorTranslator.FromHtml("#A8A8B3");
        public static Color BorderColor = ColorTranslator.FromHtml("#0F3460");

        // ── Apply Form Theme ──────────────────────────────────
        public static void ApplyFormTheme(Form form)
        {
            form.BackColor = BgPrimary;
            form.ForeColor = TextPrimary;
            form.Font = new Font("Segoe UI", 9.5f);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        // ── Apply Button Theme ────────────────────────────────
        public static void ApplyButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Height = 38;

            // ✅ Hover effects
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Light(color, 0.2f);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = color;
            };
        }

        // ── Apply TextBox Theme ───────────────────────────────
        public static void ApplyTextBox(TextBox txt)
        {
            txt.BackColor = BgCard;
            txt.ForeColor = TextPrimary;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 10f);
            txt.Height = 30;
        }

        // ── Apply Panel Theme ─────────────────────────────────
        public static void ApplyHeader(Panel panel, Label title)
        {
            panel.BackColor = BgSecondary;
            title.ForeColor = AccentPink;
            title.Font = new Font("Georgia", 14f, FontStyle.Bold);
            title.BackColor = Color.Transparent;
        }

        // ── Apply DataGridView Theme ──────────────────────────
        public static void ApplyGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = BgPrimary;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = BgCard;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowTemplate.Height = 35;

            // ← Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = AccentPink;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeight = 40;

            // ← Row style
            dgv.DefaultCellStyle.BackColor = BgSecondary;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.SelectionBackColor = AccentPurple;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            // ← Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = BgCard;
        }

        // ── Animate Form Fade In ──────────────────────────────
        public static void FadeIn(Form form)
        {
            form.Opacity = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 20;
            timer.Tick += (s, e) =>
            {
                if (form.Opacity < 1)
                    form.Opacity += 0.05;
                else
                    timer.Stop();
            };
            timer.Start();
        }

        // ── Animate Button Click ──────────────────────────────
        public static void AnimateButton(Button btn)
        {
            Color original = btn.BackColor;
            btn.BackColor = ControlPaint.Dark(original, 0.1f);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 150;
            timer.Tick += (s, e) =>
            {
                btn.BackColor = original;
                timer.Stop();
            };
            timer.Start();
        }

        // ── Style ComboBox ────────────────────────────────────
        public static void ApplyComboBox(ComboBox cmb)
        {
            cmb.BackColor = BgCard;
            cmb.ForeColor = TextPrimary;
            cmb.Font = new Font("Segoe UI", 10f);
            cmb.FlatStyle = FlatStyle.Flat;
        }

        // ── Style Label ───────────────────────────────────────
        public static void ApplyLabel(Label lbl, bool isTitle = false)
        {
            lbl.ForeColor = isTitle ? AccentGold : TextSecondary;
            lbl.BackColor = Color.Transparent;
            lbl.Font = isTitle
                ? new Font("Segoe UI", 10f, FontStyle.Bold)
                : new Font("Segoe UI", 9.5f);
        }
    }
}