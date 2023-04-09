using quanlycoffe;
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

namespace Form_DangNhap
{
    public partial class fmDangNhap : Form
    {

        public fmDangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (QuanLyQuanCafeEntities qlcf = new QuanLyQuanCafeEntities())
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
                {
                    Account acc = qlcf.Accounts.FirstOrDefault(x => x.UserName == textBox1.Text && x.PassWord == textBox2.Text);
                    if (acc != null)
                    {
                        if(acc.Type == 0)
                        {
                            fmMainAdmin fmMainAdmin = new fmMainAdmin();
                            fmMainAdmin.Show();
                        }
                        else
                        {
                            fmMain fmMain = new fmMain();
                            fmMain.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoăc mật khẩu vui lòng đăng nhập lại");
                    }
                }
                else
                {
                    MessageBox.Show("Trống thông tin");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
