using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;

namespace QLTB
{
    public partial class UserControl_Report : UserControl
    {

        public UserControl_Report()
        {
            InitializeComponent();
            dgvCanBaoTri.ColumnHeadersHeight = 30;
            dgvTongChiPhi.ColumnHeadersHeight = 30;
            dgvTopChiPhi.ColumnHeadersHeight = 30;
            dgvThongKeVeSinh.ColumnHeadersHeight = 30;

        }

        private void UserControl_Report_Load(object sender, EventArgs e)
        {
            LoadCanBaoTri();
            LoadTongChiPhi();
            LoadTopChiPhi();
            LoadThongKeVeSnh();
            lblCountCanBaoTri.Text = GetCountCanBaoTri().ToString(); ;
            lblTongChiPhi.Text = GetTongChiPhiThietBi("TB01").ToString(); ;
            lblAvgChiPhi.Text = GetAvgChiPhiBaoTri("TB01").ToString();
            ApplyCustomTheme(dgvCanBaoTri);
            ApplyCustomTheme(dgvTongChiPhi);
            ApplyCustomTheme(dgvTopChiPhi);
            ApplyCustomTheme(dgvThongKeVeSinh);
        }

        private void LoadCanBaoTri()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM dbo.v_GetCanBaoTri";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvCanBaoTri.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTongChiPhi()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM dbo.fn_ReportTongChiPhi()";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTongChiPhi.DataSource = dt;
                }
            }
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTopChiPhi()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    string sql = "SELECT * FROM dbo.fn_ReportTopChiPhi_Multi() ORDER BY TongChiPhi DESC";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvTopChiPhi.DataSource = dt;
                }
                catch (SqlException ex)
                {
                    string msg = SqlErrorHandler.Translate(ex);
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
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
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private double GetAvgChiPhiBaoTri(string maTB)
        {
            double result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
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
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private int GetCountCanBaoTri()
        {
            try
            {
                int result = 0;
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
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
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void dgvCanBaoTri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                string maTB = dgvCanBaoTri.Rows[e.RowIndex].Cells["MaTB"].Value.ToString();

                double tong = GetTongChiPhiThietBi(maTB);
                double avg = GetAvgChiPhiBaoTri(maTB);

                lblTongChiPhi.Text = $"{tong:#,##0.##}";
                lblAvgChiPhi.Text = $"{avg:#,##0.##}";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_TimKiemCanBaoTri", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (string.IsNullOrEmpty(tuKhoa))
                            cmd.Parameters.AddWithValue("@TuKhoa", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvCanBaoTri.DataSource = dt;
                    }
                }
            }
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportCanBaoTri_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = "CanBaoTri.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCsv(dgvCanBaoTri, sfd.FileName);
            }
        }

        private void btnExportTongChiPhi_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = "TongChiPhi.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCsv(dgvTongChiPhi, sfd.FileName);
            }
        }

        private void btnExportTopChiPhi_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = "TopChiPhi.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCsv(dgvTopChiPhi, sfd.FileName);
            }
        }

        private void ExportToCsv(DataGridView dgv, string fileName)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                var headers = dgv.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(c => c.HeaderText)));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        sb.AppendLine(string.Join(",", cells.Select(c => "\"" + (c.Value?.ToString().Replace("\"", "\"\"")) + "\"")));
                    }
                }

                System.IO.File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Xuất CSV thành công: " + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất CSV: " + ex.Message);
            }
        }
        private void LoadThongKeVeSnh()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM dbo.v_VeSinhTheoThang ORDER BY Nam, Thang";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvThongKeVeSinh.DataSource = dt;
                    LoadChart(dt);
                }
            }
            catch (SqlException ex)
            {
                string msg = SqlErrorHandler.Translate(ex);
                MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message,
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadThongKeVeSnh();
        }

        private void btnExportExcelThongKeVeSinh_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files|*.csv";
            sfd.FileName = "ThongKeVeSinh.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCsv(dgvThongKeVeSinh, sfd.FileName);
            }
        }

        private void LoadChart(DataTable dt)
        {
            chartThongKe.Datasets.Clear();

            GunaBarDataset dataset = new GunaBarDataset();
            dataset.Label = "Số lần vệ sinh";

            foreach (DataRow row in dt.Rows)
            {
                string label = $"{row["Thang"]}/{row["Nam"]}";
                int value = Convert.ToInt32(row["SoLan"]);

                dataset.DataPoints.Add(label, value);
            }
            chartThongKe.Datasets.Add(dataset);
            chartThongKe.Update();
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
