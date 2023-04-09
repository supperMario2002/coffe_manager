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
            InitializeComponent();
            OpenChildForm(new fmBan());
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

        private void datban_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fmBan());
        }
    }
}
