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
    public partial class Form_BaoTriLog : Form
    {
        private string _maTB;
        private string _tenTB;

        public Form_BaoTriLog(string maTB, string tenTB)
        {
            InitializeComponent();
            _maTB = maTB;
            _tenTB = tenTB;
            dgvBaoTri.ColumnHeadersHeight = 30;
            ApplyCustomTheme();

        }

        private void Form_BaoTriLog_Load(object sender, EventArgs e)
        {
            // Gán giá trị vào các TextBox
            txtMaTB.Text = _maTB;
            txtTenTB.Text = _tenTB;

            // Thiết lập ComboBox kết quả bảo trì
            cboKetQua.Items.Clear();
            cboKetQua.Items.AddRange(new object[] { "Sửa xong", "Không sửa được", "Hỏng" });
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;

            // Load lịch sử bảo trì
            LoadBaoTriHistory();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_ThemBaoTri", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text);
                    cmd.Parameters.AddWithValue("@NgayBaoTri", dtNgayBaoTri.Value.Date);
                    cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                    cmd.Parameters.AddWithValue("@ChiPhi", double.TryParse(txtChiPhi.Text, out double cp) ? cp : 0);
                    cmd.Parameters.AddWithValue("@KetQua", cboKetQua.Text);

                    int rows = cmd.ExecuteNonQuery();
                    MessageBox.Show(rows > 0 ? "Lưu log bảo trì thành công!" : "Không thể lưu log bảo trì.");
                }
            }
            LoadBaoTriHistory();
        }

        private void LoadBaoTriHistory()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_GetBaoTriByMaTB", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTB", _maTB);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBaoTri.DataSource = dt;
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyCustomTheme()
        {
            // Theme chung
            dgvBaoTri.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            dgvBaoTri.EnableHeadersVisualStyles = false;

            // Header
            dgvBaoTri.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(102, 126, 234);   // xanh tím nhạt
            dgvBaoTri.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoTri.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBaoTri.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBaoTri.ColumnHeadersHeight = 40;

            // Dòng bình thường
            dgvBaoTri.DefaultCellStyle.BackColor = Color.White;
            dgvBaoTri.DefaultCellStyle.ForeColor = Color.Black;
            dgvBaoTri.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvBaoTri.DefaultCellStyle.SelectionBackColor = Color.FromArgb(186, 104, 200); // tím nhạt khi chọn
            dgvBaoTri.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvBaoTri.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Dòng xen kẽ
            dgvBaoTri.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 250); // xám rất nhạt

            // DGV chung
            dgvBaoTri.BackgroundColor = Color.White;
            dgvBaoTri.BorderStyle = BorderStyle.None;
            dgvBaoTri.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvBaoTri.RowTemplate.Height = 35;

            dgvBaoTri.ReadOnly = true;
            dgvBaoTri.AllowUserToAddRows = false;
            dgvBaoTri.AllowUserToResizeRows = false;
            dgvBaoTri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoTri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
