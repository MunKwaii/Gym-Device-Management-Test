using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLTB;

namespace DBMS_Project
{
    public partial class Form_Login : Form
    {
        private bool isLogin = true;

        public Form_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu tài khoản và mật khẩu không được nhập
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Tài khoản hoặc mật khẩu không hợp lệ");
                return;
            }

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            try
            {
                // Cấu hình lại chuỗi kết nối cơ sở dữ liệu
                DatabaseConfig.SetConnection(user, pass);

                // Kiểm tra kết nối cơ sở dữ liệu
                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                }

                // Thông báo đăng nhập thành công
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form chính
                Form_ThietBiList frm = new Form_ThietBiList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Thông báo khi đăng nhập thất bại
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            isLogin = true;
            errorProvider1.SetError(txtUsername, "");
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (txtUsername.Text.Length < 8)
                {
                    errorProvider1.SetError(txtUsername, "Dài hơn 8 kí tự");
                    isLogin = false;
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            isLogin = true;
            errorProvider1.SetError(txtPassword, "");
        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ với admin", "Thông báo");
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy liên hệ với admin", "Thông báo");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
