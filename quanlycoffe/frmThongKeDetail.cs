using quanlycoffe;
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

namespace CoffeManager
{
    public partial class frmThongKeDetail : Form
    {
        public delegate void SendMessage(string idBill, string txtBan);
        public SendMessage Sender;
        public frmThongKeDetail()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);
        }
        private void GetMessage(string idBill, string txtBan)
        {
            using (var tk = new QuanLyQuanCafeEntities())
            {
                int id = Convert.ToInt32(idBill);
                var menu = (from a in tk.Foods
                            join b in tk.BillInfoes
                            on a.id equals b.idFood
                            where b.idBill == id
                            select new
                            {
                                a.name,
                                b.count,
                                a.price
                            }).ToList();
                int tong = 0;
                foreach (var a in menu)
                {
                    dataGridView2.Rows.Add(a.name, a.count, a.price);
                    int price = Convert.ToInt32(a.price);
                    int count = Convert.ToInt32(a.count);
                    tong += (price * count);
                    lblTongTien.Text = Function.FormatCurrency("VND",tong);
                }
            }
                
                lblIdTable.Text = idBill;
                lblTenBan.Text = txtBan;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
