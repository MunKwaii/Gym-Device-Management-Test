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
using Guna.Charts.WinForms;
using Guna.UI2.WinForms;

namespace QLTB
{
    public partial class UserControl_VeSinh : UserControl
    {
        public UserControl_VeSinh()
        {
            InitializeComponent();
        }

        private void UserControl_VeSinh_Load(object sender, EventArgs e)
        {
            LoadTinhTrangVeSinh();
            LoadTinhThongKe();
            LoadThongKe();
            ApplyCustomTheme(dgvThongKe);
            ApplyCustomTheme(dgvTinhTrangVeSinh);

        }

        private void LoadTinhTrangVeSinh()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string sql = "SELECT * FROM v_ThietBi_VeSinh";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTinhTrangVeSinh.DataSource = dt;
            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (dgvTinhTrangVeSinh.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần cập nhật.");
                return;
            }

            string maTB = dgvTinhTrangVeSinh.CurrentRow.Cells["MaTB"].Value.ToString();
            string newStatus = cboTinhTrang.SelectedItem?.ToString();
            DateTime ngayVeSinh = dtNgayVeSinh.Value;

            if (string.IsNullOrEmpty(newStatus))
            {
                MessageBox.Show("Vui lòng chọn tình trạng mới.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CapNhatVeSinh", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTB", maTB);
                    cmd.Parameters.AddWithValue("@TinhTrang", newStatus);
                    cmd.Parameters.AddWithValue("@NgayVeSinh", ngayVeSinh);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cập nhật thành công!");
            LoadTinhTrangVeSinh();
        }

        private void dgvTinhTrangVeSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTinhTrangVeSinh.Rows[e.RowIndex];
                string tinhTrang = row.Cells["TinhTrangVeSinh"].Value?.ToString();

                cboTinhTrang.SelectedItem = tinhTrang;

                if (row.Cells["NgayVeSinh"].Value != DBNull.Value)
                {
                    dtNgayVeSinh.Value = Convert.ToDateTime(row.Cells["NgayVeSinh"].Value);
                }
                else
                {
                    dtNgayVeSinh.Value = DateTime.Today;
                }
            }
        }


        private void LoadTinhThongKe()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string sql = "SELECT Nam, Thang, SoLan FROM v_VeSinhTheoThang ORDER BY Nam DESC, Thang DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvThongKe.DataSource = dt;
            }
        }

        private void LoadThongKe()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                string sql = "SELECT * FROM v_VeSinhTheoThang ORDER BY Nam, Thang";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThongKe.DataSource = dt;
                LoadChart(dt);
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
