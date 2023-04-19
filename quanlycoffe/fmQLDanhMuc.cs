using quanlycoffe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class fmQLDanhMuc : Form
    {
        QuanLyQuanCafeEntities db = new QuanLyQuanCafeEntities();
        public fmQLDanhMuc()
        {
            InitializeComponent();
            loaddata();
        }

       
       
        void reset()
        {
            txtID.Text = "";
            txtName.Text = "";
        }
        void loaddata()
        {
            dtgv.Rows.Clear();
                var result = (from c in db.FoodCategories select new { 
                    c.id, c.name,
                }).ToList();
                foreach (var c in result)
                {
                dtgv.Rows.Add(c.id,c.name);

                }  
                
        }
        void add()
        {
            
                FoodCategory fd = new FoodCategory()
                { name = txtName.Text};
                db.FoodCategories.Add(fd);
                 db.SaveChanges();


        }
        void edit()
        {
            int id = Convert.ToInt32(txtID.Text);
            using (var db = new QuanLyQuanCafeEntities())
            {
                var findId = db.FoodCategories.Find(id);
                findId.name = txtName.Text;
                db.SaveChanges();
            }
        }
       

        private void btnADD_Click(object sender, EventArgs e)
        {
            add();
            loaddata();
            reset();
        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
           edit();
            loaddata();
            reset();
        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32( txtID.Text);
            db.FoodCategories.Remove(db.FoodCategories.Where(p => p.id == idCategory).SingleOrDefault());
            db.SaveChanges();
            loaddata();
            reset();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Close();    
        }
        private void dtgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtName.Text = dtgv.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
