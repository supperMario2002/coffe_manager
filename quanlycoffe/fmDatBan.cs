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
            loadTable();
        }

        void loadTable()
        {
            using (var db = new QuanLyQuanCafeEntities())
            {
                dgvKhachHang.Rows.Clear();
                var data = db.Customers.ToList();

                foreach (var i in data)
                {
                    dgvKhachHang.Rows.Add(i.name, i.phone);
                }

            }
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
                    var checkCustomer = tf.Customers.Where(x => x.name == name && x.phone == phone).FirstOrDefault();
                    int idCustomer = 0;
                    if(checkCustomer == null)
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
                    }
                    else
                    {
                        idCustomer = checkCustomer.id;
                        var createBill = new Bill
                        {
                            idTable = CurrenTableId,
                            DateCheckIn = DateTime.Now,
                            status = 0,
                            idCustomer = idCustomer
                        };
                        tf.Bills.Add(createBill);
                    }

                    Function.updateStatusTable("Có người", CurrenTableId);
                    tf.SaveChanges();

                    if(TruyenCha != null)
                    {
                        TruyenCha(CurrenTableId);
                    }
                }
            }
        }


        private void fmDatBan_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string keysearch = txtName.Text;
            using (var db = new QuanLyQuanCafeEntities())
            {
                dgvKhachHang.Rows.Clear();
                var data = db.Customers.Where(x =>  x.name.Contains(keysearch)).ToList();

                foreach (var i in data)
                {
                    dgvKhachHang.Rows.Add(i.name, i.phone);
                }

            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dgvKhachHang.Rows[e.RowIndex].Cells[0].Value.ToString();
            string phone = dgvKhachHang.Rows[e.RowIndex].Cells[1].Value.ToString();

            txtName.Text = name;
            txtPhone.Text = phone;
        }
    }
}
