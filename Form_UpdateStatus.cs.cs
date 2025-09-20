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
    public partial class Form_UpdateStatus : Form
    {
        private string _maTB;
        private string _tenTB;

        public Form_UpdateStatus(string maTB, string tenTB)
        {
            InitializeComponent();
            _maTB = maTB;
            _tenTB = tenTB;
        }

        

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTB.Text))
            {
                MessageBox.Show("Chưa chọn thiết bị.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.sp_UpdateTinhTrang", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaTB", txtMaTB.Text);
                        cmd.Parameters.AddWithValue("@TinhTrang", cboTinhTrang.Text);

                        int rows = cmd.ExecuteNonQuery();
                        MessageBox.Show(rows > 0 ? "Cập nhật thành công!" : "Không tìm thấy thiết bị.");
                    }
                }
                this.Close();
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
        private void Form_UpdateStatus_Load(object sender, EventArgs e)
        {
            txtMaTB.Text = _maTB;
            txtTenTB.Text = _tenTB;
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

