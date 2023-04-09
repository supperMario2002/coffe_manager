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
    public partial class fmBan : Form
    {
        private static int CurrenTableId;
        public fmBan()
        {
            InitializeComponent();
            loadTable();
            checkTable(1);
        }

        private void NhanDuLieu(int nd)
        {
            loadTable();
            checkTable(nd);

        }
        private Form currenFormChid;

      

        public void loadTable()
        {
            flptable.Controls.Clear();
            using (var tf = new QuanLyQuanCafeEntities())
            {
                List<TableFood> ListTable = tf.TableFoods.ToList();

                foreach (TableFood item in ListTable)
                {
                    Button btn = new Button() { Width = 80, Height = 80 };
                    btn.Text = item.name + Environment.NewLine + item.status;
                    btn.Click += btn_Click;
                    btn.Tag = item;
                    switch (item.status)
                    {
                        case "Trống":
                            btn.BackColor = Color.LightPink;
                            break;
                        default:
                            btn.BackColor = Color.Aqua;
                            break;
                    }
                    flptable.Controls.Add(btn);

                }
            };
        }

        public void checkTable(int tableID)
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var billStatus = tf.Bills.Where(a => a.idTable == tableID && a.status == 0).FirstOrDefault();
                if (billStatus != null)
                {
                    button1.Visible = true;
                    fmGoiMon fmgoimon = new fmGoiMon(tableID);
                    if (currenFormChid != null)
                    {
                        currenFormChid.Close();
                    }
                    currenFormChid = fmgoimon;
                    fmgoimon.TopLevel = false;
                    fmgoimon.FormBorderStyle = FormBorderStyle.None;
                    fmgoimon.Dock = DockStyle.Fill;
                    panel1.Controls.Add(fmgoimon);
                    panel1.Tag = fmgoimon;
                    fmgoimon.BringToFront();
                    fmgoimon.TruyenCha = new fmGoiMon.TruyenDuLieu(NhanDuLieu);
                    fmgoimon.Show();
                }
                else
                {
                    button1.Visible = false;
                    fmDatBan fmdatban = new fmDatBan(tableID);
                    if (currenFormChid != null)
                    {
                        currenFormChid.Close();
                    }
                    currenFormChid = fmdatban;
                    fmdatban.TopLevel = false;
                    fmdatban.FormBorderStyle = FormBorderStyle.None;
                    fmdatban.Dock = DockStyle.Fill;
                    panel1.Controls.Add(fmdatban);
                    panel1.Tag = fmdatban;
                    fmdatban.BringToFront();
                    fmdatban.TruyenCha = new fmDatBan.TruyenDuLieu(NhanDuLieu);
                    fmdatban.Show();
                    
                }
            }
        }


        void btn_Click(Object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as TableFood).id;
            CurrenTableId = tableID;
            checkTable(tableID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var bill = tf.Bills.Where(a => a.idTable == CurrenTableId && a.status == 0).FirstOrDefault();
                tf.BillInfoes.RemoveRange(tf.BillInfoes.Where(p => p.idBill == bill.id));
                tf.Bills.Remove(tf.Bills.Where(a => a.id == bill.id).SingleOrDefault());
                tf.SaveChanges();
                Function.updateStatusTable("Trống", CurrenTableId);
                loadTable();
                checkTable(CurrenTableId);
            }
        }
    }
}
