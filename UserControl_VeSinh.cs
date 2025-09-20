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
            ApplyCustomTheme(dgvTinhTrangVeSinh);
        }

        private void LoadTinhTrangVeSinh()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    string sql = "SELECT * FROM dbo.v_ThietBi_VeSinh";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTinhTrangVeSinh.DataSource = dt;
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

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_CapNhatVeSinh", conn))
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtSearch.Text.Trim();

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_TimKiemThietBiVeSinh", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (string.IsNullOrEmpty(tuKhoa))
                            cmd.Parameters.AddWithValue("@TuKhoa", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvTinhTrangVeSinh.DataSource = dt;
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
