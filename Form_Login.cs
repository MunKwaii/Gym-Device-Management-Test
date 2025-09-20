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
         

            string user = txtUsername.Text.Trim();
            string pass = txtPassword.Text.Trim();

            try
            {
                DatabaseConfig.SetConnection(user, pass);

                using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    conn.Open();
                }

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form_ThietBiList frm = new Form_ThietBiList();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            isLogin = true;
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (txtUsername.Text.Length < 8)
                {
                    isLogin = false;
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            isLogin = true;
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

        private void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
