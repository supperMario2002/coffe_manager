using CoffeManager;
using Form_DangNhap;
using quanlycaffe;
using QuanLyDoAn;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace quanlycoffe
{
    public partial class fmMainAdmin : Form
    {
        public fmMainAdmin()
        {
            InitializeComponent();
            OpenChildForm(new fmQLTK());
            set();
            qlnv.BackColor = Color.CadetBlue;
        }
        private Form currenFormChid;

        private void OpenChildForm(Form childForm)
        {
            if (currenFormChid != null)
            {
                currenFormChid.Close();
            }
            currenFormChid = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        void set()
        {
            qlnv.BackColor = Color.White;
            thongke.BackColor = Color.White;
            ban.BackColor = Color.White;
            qldoan.BackColor = Color.White;
            qldanhmuc.BackColor = Color.White;
            
        }
        

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmQLTK());
            set();
            qlnv.BackColor = Color.CadetBlue;
        }

        private void quảnLýBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmQLBan());
            set();
            ban.BackColor = Color.CadetBlue;
        }

        private void quảnLýĐồĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLDoAn());
            set();
            qldoan.BackColor = Color.CadetBlue;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            fmDangNhap dn = new fmDangNhap();
            dn.Show();
            this.Hide();
        }

        private void qldanhmuc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmQLDanhMuc());
            set();
            qldanhmuc.BackColor = Color.CadetBlue;
        }

        private void tkMonAn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKeDoAn());
        }

        private void Tkhoadon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe());
        }

        private void qlkhachhang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQLKhachhang());
        }
    }
}
