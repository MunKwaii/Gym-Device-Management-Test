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
    public partial class Form_ThietBiList : Form
    {
        public Form_ThietBiList()
        {

            InitializeComponent();
            LoadLoaiThietBi();
            LoadThietBi();
            dgvThietBi.ColumnHeadersHeight = 30;


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLGYM;Persist Security Info=True;User ID=sa;Password=1234;TrustServerCertificate=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ThemThietBi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text);
                cmd.Parameters.AddWithValue("@TenTB", txtTenTB.Text);
                cmd.Parameters.AddWithValue("@MaLoai", cboLoaiTB.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayNhap", dtNgayNhap.Value);
                cmd.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.Text);
                cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text);

                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show(rows > 0 ? "Thêm thành công!" : "Thêm thất bại!");
            }
            LoadThietBi();

        }

        private void LoadThietBi()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLGYM;Persist Security Info=True;User ID=sa;Password=1234;TrustServerCertificate=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetThietBi", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvThietBi.DataSource = dt; // dgvThietBi = DataGridView
            }
        }

        private void LoadLoaiThietBi()
        {
            try
            {
                string cs = "Data Source=.;Initial Catalog=QLGYM;User ID=sa;Password=1234;TrustServerCertificate=True;Connection Timeout=3";
                using (var conn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter("SELECT MaLoai, TenLoai FROM LoaiThietBi", conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    cboLoaiTB.DisplayMember = "TenLoai";
                    cboLoaiTB.ValueMember = "MaLoai";
                    cboLoaiTB.DataSource = dt;
                    cboLoaiTB.SelectedIndex = -1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load LoaiThietBi lỗi: " + ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadThietBi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLGYM;Persist Security Info=True;User ID=sa;Password=1234;TrustServerCertificate=True"))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_SuaThietBi", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text);
                    cmd.Parameters.AddWithValue("@TenTB", txtTenTB.Text);
                    cmd.Parameters.AddWithValue("@MaLoai", cboLoaiTB.SelectedValue ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayNhap", dtNgayNhap.Value);
                    cmd.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.Text);
                    cmd.Parameters.AddWithValue("@ViTri", txtViTri.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Sửa thành công!" : "Không có dữ liệu nào được sửa.");
                }
            }
            LoadThietBi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTB.Text))
            {
                MessageBox.Show("Vui lòng chọn thiết bị cần xoá.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xoá thiết bị này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLGYM;Persist Security Info=True;User ID=sa;Password=1234;TrustServerCertificate=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_XoaThietBi", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Xoá thành công!" : "Không tìm thấy thiết bị.");
                    }
                }
                LoadThietBi();
            }
        }

        private void dgvThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThietBi.Rows[e.RowIndex];
                txtMaTB.Text = row.Cells["MaTB"].Value.ToString();
                txtTenTB.Text = row.Cells["TenTB"].Value.ToString();
                cboLoaiTB.SelectedValue = row.Cells["MaLoai"].Value;
                dtNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                cboTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
                txtViTri.Text = row.Cells["ViTri"].Value.ToString();
            }
        }

     

        private void dgvThietBi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvThietBi.Rows[e.RowIndex];
                string maTB = row.Cells["MaTB"].Value.ToString();
                string tenTB = row.Cells["TenTB"].Value.ToString();

                Form_UpdateStatus frm = new Form_UpdateStatus(maTB, tenTB);
                frm.ShowDialog();

                LoadThietBi(); // refresh lại sau khi update
            }
        }

        private void btnXemBaoTri_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu dòng đã được chọn
            if (dgvThietBi.CurrentRow != null)
            {
                // Lấy Mã thiết bị và Tên thiết bị từ DataGridView
                string maTB = dgvThietBi.CurrentRow.Cells["MaTB"].Value.ToString();
                string tenTB = dgvThietBi.CurrentRow.Cells["TenTB"].Value.ToString();

                // Mở Form_BaoTriLog và truyền tham số vào
                Form_BaoTriLog frmBaoTri = new Form_BaoTriLog(maTB, tenTB);
                frmBaoTri.ShowDialog();  // Hiển thị Form_BaoTriLog
            }
        }


        private void tabReport_Click(object sender, EventArgs e)
        {
       
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == tabReport)
            {
                tabReport.Controls.Clear();
                UserControl_Report uc = new UserControl_Report();
                uc.Dock = DockStyle.Fill;
                tabReport.Controls.Add(uc);
            }
        }
    }
}
