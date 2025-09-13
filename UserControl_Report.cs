using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace QLTB
{
    public partial class UserControl_Report : UserControl
    {
        private string connStr = "Data Source=.;Initial Catalog=QLGYM;User ID=sa;Password=1234;TrustServerCertificate=True";

        public UserControl_Report()
        {
            InitializeComponent();
            dgvCanBaoTri.ColumnHeadersHeight = 30;
            dgvTongChiPhi.ColumnHeadersHeight = 30;
            dgvTopChiPhi.ColumnHeadersHeight = 30;

        }

        private void UserControl_Report_Load(object sender, EventArgs e)
        {
            LoadCanBaoTri();
            LoadTongChiPhi();
            LoadTopChiPhi();

            lblCountCanBaoTri.Text = GetCountCanBaoTri().ToString(); ;
            lblTongChiPhi.Text = GetTongChiPhiThietBi("TB01").ToString(); ;
            lblAvgChiPhi.Text = GetAvgChiPhiBaoTri("TB01").ToString();
            ApplyCustomTheme(dgvCanBaoTri);
            ApplyCustomTheme(dgvTongChiPhi);
            ApplyCustomTheme(dgvTopChiPhi);

        }

        private void LoadCanBaoTri()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //string sql = "SELECT * FROM dbo.fn_GetCanBaoTri()";
                string sql = "SELECT * FROM dbo.v_GetCanBaoTri";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCanBaoTri.DataSource = dt;
            }
        }



        private void LoadTongChiPhi()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM dbo.fn_ReportTongChiPhi()";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTongChiPhi.DataSource = dt;
            }
        }

        private void LoadTopChiPhi()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM dbo.fn_ReportTopChiPhi_Multi() ORDER BY TongChiPhi DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTopChiPhi.DataSource = dt;
            }
        }

        private void btnReloadTopChiPhi_Click(object sender, EventArgs e)
        {
            LoadTopChiPhi();
        }

        private void btnReloadCanBaoTri_Click(object sender, EventArgs e)
        {
            LoadCanBaoTri();
        }

        private void btnReloadTongChiPhi_Click(object sender, EventArgs e)
        {
            LoadTongChiPhi();
        }

        private double GetTongChiPhiThietBi(string maTB)
        {
            double result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT dbo.fn_TongChiPhiThietBi(@MaTB)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTB", maTB);
                    object val = cmd.ExecuteScalar();
                    if (val != DBNull.Value) result = Convert.ToDouble(val);
                }
            }
            return result;
        }

        private double GetAvgChiPhiBaoTri(string maTB)
        {
            double result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT dbo.fn_AvgChiPhiBaoTri(@MaTB)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaTB", maTB);
                    object val = cmd.ExecuteScalar();
                    if (val != DBNull.Value) result = Convert.ToDouble(val);
                }
            }
            return result;
        }

        private int GetCountCanBaoTri()
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT dbo.fn_CountCanBaoTri()";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object val = cmd.ExecuteScalar();
                    if (val != DBNull.Value) result = Convert.ToInt32(val);
                }
            }
            return result;
        }

        private void dgvCanBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh header
            {
                string maTB = dgvCanBaoTri.Rows[e.RowIndex].Cells["MaTB"].Value.ToString();

                double tong = GetTongChiPhiThietBi(maTB);
                double avg = GetAvgChiPhiBaoTri(maTB);

                lblTongChiPhi.Text = $"{tong:#,##0.##}";
                lblAvgChiPhi.Text = $"{avg:#,##0.##}";
            }
        }
        private void ApplyCustomTheme(Guna2DataGridView dgv)
        {
            // Theme chung
            dgv.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgv.EnableHeadersVisualStyles = false;

            // Header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 126, 234);   // xanh tím nhạt
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Dòng bình thường
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 104, 200); // tím nhạt khi chọn
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Dòng xen kẽ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250); // xám rất nhạt

            // DGV chung
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowTemplate.Height = 35;

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
