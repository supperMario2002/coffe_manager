using quanlycoffe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoAn
{
    public partial class frmQLDoAn : Form
    {
        public frmQLDoAn()
        {
            InitializeComponent();
        }
        void loadTable()
        {
            dataGridView1.Rows.Clear();
            using (var db = new QuanLyQuanCafeEntities())
            {
                cbDanhMuc.DataSource = db.FoodCategories.ToList();
                cbDanhMuc.ValueMember = "id";
                cbDanhMuc.DisplayMember = "name";

                var data = (from a in db.Foods
                            join b in db.FoodCategories
                            on a.idCategory equals b.id
                            select new
                            {
                                a.id,
                                a.name,
                                nameF = b.name,
                                a.price
                            }).ToList();

                foreach (var item in data)
                {
                    dataGridView1.Rows.Add(item.id, item.name, item.nameF, item.price);
                }
            }
        }

        void reset()
        {
            txtTen.Text = "";
            txtMadoan.Text = "";
            txtGia.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db =  new QuanLyQuanCafeEntities())
            {
                var create = new Food
                {
                    name = txtTen.Text,
                    idCategory = Convert.ToInt32(cbDanhMuc.SelectedValue),
                    price = Convert.ToDouble(txtGia.Text),
                };
                db.Foods.Add(create);
                db.SaveChanges();
                loadTable();
                reset();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMadoan.Text);
            using(var db = new QuanLyQuanCafeEntities())
            {
                var findId = db.Foods.Find(id);
                findId.name = txtTen.Text;
                findId.price = Convert.ToDouble(txtGia.Text);
                db.SaveChanges();
                loadTable();
                reset();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMadoan.Text);
            using (var db = new QuanLyQuanCafeEntities())
            {
                var delete = db.Foods.Remove(db.Foods.Where(x=>x.id == id).SingleOrDefault());
                db.SaveChanges();
                loadTable();
                reset();

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMadoan.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbDanhMuc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
   
}
