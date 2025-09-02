using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTB
{
    public partial class Form_Report : Form
    {
        public Form_Report()
        {
            InitializeComponent();
        }

        private string connStr = "Data Source=.;Initial Catalog=QLGYM;User ID=sa;Password=1234;TrustServerCertificate=True";

        private void Form_Report_Load(object sender, EventArgs e)
        {
            LoadCanBaoTri();
            LoadTongChiPhi();
            LoadTopChiPhi();
            lblCountCanBaoTri.Text = "Cần bảo trì: " + GetCountCanBaoTri();
            lblTongChiPhi.Text = "Tổng chi phí ML01: " + GetTongChiPhiThietBi("ML01");
            lblAvgChiPhi.Text = "Trung bình chi phí ML01: " + GetAvgChiPhiBaoTri("ML01");

        }

        private void LoadCanBaoTri()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Gọi function thay vì procedure
                string sql = "SELECT * FROM dbo.fn_GetCanBaoTri()";
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
                string sql = "SELECT * FROM dbo.fn_ReportTopChiPhi_Multi() ORDER BY TongChiPhi DESC"; // gọi function thay vì proc
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
                // Lấy MaTB từ cột "MaTB"
                string maTB = dgvCanBaoTri.Rows[e.RowIndex].Cells["MaTB"].Value.ToString();

                // Gọi function
                double tong = GetTongChiPhiThietBi(maTB);
                double avg = GetAvgChiPhiBaoTri(maTB);

                // Hiển thị
                lblTongChiPhi.Text = $"Tổng chi phí {maTB}: {tong:#,##0.##}";
                lblAvgChiPhi.Text = $"Trung bình chi phí {maTB}: {avg:#,##0.##}";
            }
        }
    }
}
