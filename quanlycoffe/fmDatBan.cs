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
    public partial class fmDatBan : Form
    {
        private static int CurrenTableId;

        public delegate void TruyenDuLieu(int nd);
        public TruyenDuLieu TruyenCha;

        public fmDatBan()
        {
            InitializeComponent();
        }

        public fmDatBan(int idTable) : this()
        {
            CurrenTableId = idTable;
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var nameTable = tf.TableFoods.Where(x => x.id == idTable).FirstOrDefault();
                lbTenBan.Text = nameTable.name;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            if(name == "" || phone == "")
            {
                MessageBox.Show("Tên và số diện thoại không được để trống!!");
            }
            else
            {
                using (var tf = new QuanLyQuanCafeEntities())
                {
                    var createCustomer = new Customer { 
                        name = txtName.Text,
                        phone = txtPhone.Text
                    };
                    tf.Customers.Add(createCustomer);
                    var createBill = new Bill
                    {
                        idTable = CurrenTableId,
                        DateCheckIn = DateTime.Now,
                        status = 0,
                        idCustomer = createCustomer.id
                    };
                    tf.Bills.Add(createBill);

                    Function.updateStatusTable("Có người", CurrenTableId);
                    tf.SaveChanges();

                    if(TruyenCha != null)
                    {
                        TruyenCha(CurrenTableId);
                    }
                }
            }
        }
    }
}
