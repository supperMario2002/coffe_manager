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
    public partial class fmTTNV : Form
    {
        public fmTTNV()
        {
            InitializeComponent();
            LoadData();
        }

        private string userID = SessionLogin.userID;
        public void LoadData()
        {
            using (QuanLyQuanCafeEntities db = new QuanLyQuanCafeEntities())
            {
                var data = (from a in db.Accounts where a.UserName == userID select new { a.DisplayName, a.genner, a.address, a.phone }).FirstOrDefault();
                txtName.Text = data.DisplayName;
                txtGender.Text = data.genner;
                txtAddres.Text = data.address;
                txtPhone.Text = data.phone;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            using (QuanLyQuanCafeEntities db = new QuanLyQuanCafeEntities())
            {
                var updateUser = db.Accounts.Find(userID);
                updateUser.DisplayName = txtName.Text;
                updateUser.genner = (string) txtGender.SelectedItem;
                updateUser.address = txtAddres.Text;
                updateUser.phone = txtPhone.Text;
                db.SaveChanges();
                MessageBox.Show("Cập Nhật thành công");
                LoadData();
            }
        }
    }
}
