using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
        }

        private void LoadCanBaoTri()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
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

                lblTongChiPhi.Text = $"{maTB}: {tong:#,##0.##}";
                lblAvgChiPhi.Text = $"{maTB}: {avg:#,##0.##}";
            }
        }
    }
}
