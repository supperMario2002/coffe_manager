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
    public partial class frmThongKeDoAn : Form
    {
        public frmThongKeDoAn()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            using (var tk = new QuanLyQuanCafeEntities())
            {
                var menu = (from a in tk.Foods
                            join b in tk.BillInfoes
                            on a.id equals b.idFood
                            select new
                            {
                                a.name,
                                b.count,
                                a.price
                            }).ToList();
                int tong = 0;
                foreach (var a in menu)
                {
                    dataGridiew1.Rows.Add(a.name, a.count, a.price);
                    int price = Convert.ToInt32(a.price);
                    int count = Convert.ToInt32(a.count);
                    tong += (price * count);
                }
            }
        }

        public void checkDateBill()
        {
            dataGridiew1.Rows.Clear();
            using (var tk = new QuanLyQuanCafeEntities())
            {
                DateTime theDateto = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

                DateTime theDatelast = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());


                var kqCheck = (from f in tk.Foods
                               join b in tk.BillInfoes
                               on f.id equals b.idFood
                               join c in tk.Bills
                               on b.idBill equals c.id
                               where c.status == 1 && (c.DateCheckOut >= theDateto.Date && c.DateCheckOut <= theDatelast.Date)
                               select new
                               {
                                    f.name,
                                    b.count,
                                    f.price
                               }).ToList();
                foreach (var d in kqCheck)
                {
                    dataGridiew1.Rows.Add(d.name, d.count, d.price);
                }
            }

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            checkDateBill();
        }
    }
}
