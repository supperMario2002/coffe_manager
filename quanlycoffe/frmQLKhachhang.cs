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
    public partial class frmQLKhachhang : Form
    {
        public frmQLKhachhang()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            dtgv.Rows.Clear();
            using (var tk = new QuanLyQuanCafeEntities())
            {
                var load = (from a in tk.Customers
                            select a
                              ).ToList();
                foreach (var a in load)
                {
                    dtgv.Rows.Add(a.id, a.name, a.phone, a.point);
                }
            }
        }

        void edit()
        {
            int id = Convert.ToInt32(txtID.Text);
            using (var db = new QuanLyQuanCafeEntities())
            {
                var findId = db.Customers.Find(id);
                findId.name = txtName.Text;
                findId.phone = txtSDT.Text;
                db.SaveChanges();
            }
        }
        void reset()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtPoint.Text = "";

        }

        private int validate()
        {
            string Username = txtName.Text;
            string Phone = txtSDT.Text;

            if (Username == "")
            {
                MessageBox.Show("Tên không được để trống");
                return 0;
            }
            if (Phone == "")
            {
                MessageBox.Show("Số điện thoại không được để trống");
                return 0;
            }
            
            return 1;
        }
        void add()
        {
            using(var db = new QuanLyQuanCafeEntities())
            {
                Customer fd = new Customer()
                { name = txtName.Text, phone = txtSDT.Text, point = 0 };
                db.Customers.Add(fd);
                db.SaveChanges();
            }
            
        }

        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dtgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSDT.Text = dtgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPoint.Text = dtgv.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            if(validate() == 1)
            {
                add();
                LoadData();
                reset();
            }
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
            if(validate() == 1)
            {
                edit();
                LoadData();
                reset();
            }
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            using(var db = new QuanLyQuanCafeEntities())
            {
                int idCus = Convert.ToInt32(txtID.Text);
                db.Customers.Remove(db.Customers.Where(p => p.id == idCus).SingleOrDefault());
                db.SaveChanges();
                LoadData();
                reset();
            }
        }
    }
}
