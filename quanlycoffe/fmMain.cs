using Form_DangNhap;
using quanlycoffe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycoffe
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            SessionLogin a = new SessionLogin();
            InitializeComponent();
            OpenChildForm(new fmBan());
            reset();
            datban.BackColor = Color.CadetBlue;
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
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        void reset()
        {
            datban.BackColor = Color.White;
            ttcn.BackColor = Color.White;
        }
        private void datban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmBan());
            reset();
            datban.BackColor = Color.CadetBlue;
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            fmDangNhap dn = new fmDangNhap();
            dn.Show();
            this.Hide();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmTTNV());
            reset();
            ttcn.BackColor = Color.CadetBlue;
        }
    }
}
