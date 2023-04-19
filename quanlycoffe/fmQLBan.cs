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

namespace quanlycaffe
{
    public partial class fmQLBan : Form
    {
        public fmQLBan()
        {
            InitializeComponent();
            loadTable();
        }
        void loadTable()
        {
            using (var db = new QuanLyQuanCafeEntities())
            {
                dataGridView1.Rows.Clear();
                var data = db.TableFoods.ToList();

                foreach (var i in data)
                {
                    dataGridView1.Rows.Add(i.id, i.name);
                }

            }
        }

        void reset()
        {
            txtMaban.Text = "";
            txtTenban.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyQuanCafeEntities())
            {
                var create = new TableFood
                {
                    name = txtTenban.Text,
                    status = "Trống"
                };
                db.TableFoods.Add(create);
                db.SaveChanges();
                loadTable();
                reset();
            }
        }
        private void txtTenban_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMaban.Text);
            using (var db = new QuanLyQuanCafeEntities())
            {
                var findId = db.TableFoods.Find(id);
                findId.name = txtTenban.Text;
                db.SaveChanges();
                loadTable();
                reset();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtMaban.Text = id;
            txtTenban.Text = name;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMaban.Text);
            using (var db = new QuanLyQuanCafeEntities())
            {
                var delete = db.TableFoods.Remove(db.TableFoods.Where(x => x.id == id).SingleOrDefault());
                db.SaveChanges();
                loadTable();
                reset();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
