using quanlycoffe.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace quanlycoffe
{
    public partial class fmGoiMon : Form
    {

        private static int CurrenTableId;
        public delegate void TruyenDuLieu(int nd);
        public TruyenDuLieu TruyenCha;
        public fmGoiMon(int idTable) : this()
        {
            CurrenTableId = idTable;
            showBill(idTable);
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var billStatus = tf.Bills.Where(a => a.idTable == idTable && a.status == 0).FirstOrDefault();
                var nameTable = tf.TableFoods.Where(x => x.id == idTable).FirstOrDefault();
                var nameCustomer = tf.Customers.Where(a => a.id == billStatus.idCustomer).FirstOrDefault();
                gbBan.Text = nameTable.name + ": " + nameCustomer.name;
            }
        }
        public fmGoiMon()
        {
            InitializeComponent();
            loadMenu();
            
        }
        void checkBill()
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {

                var billStatus = tf.Bills.Where(a => a.idTable == CurrenTableId && a.status == 0).FirstOrDefault();
                if (billStatus == null)
                {
                    Function.updateStatusTable("Trống", CurrenTableId);
                }
                else
                {
                    var billInfo = tf.BillInfoes.Where(x => x.idBill == billStatus.id).FirstOrDefault();
                    if (billInfo == null)
                    {
                        tf.Bills.Remove(tf.Bills.Where(p => p.id == billStatus.id).SingleOrDefault());
                        tf.SaveChanges();
                        Function.updateStatusTable("Trống", CurrenTableId);
                    }
                    else
                    {
                        Function.updateStatusTable("Có người", CurrenTableId);
                    }
                }
            }
        }

        void loadMenu()
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                cbDanhMuc.DataSource = tf.FoodCategories.ToList();
                cbDanhMuc.ValueMember = "id";
                cbDanhMuc.DisplayMember = "name";

                cbChuyenBan.DataSource = tf.TableFoods.ToList();
                cbChuyenBan.DisplayMember = "name";
                cbChuyenBan.ValueMember = "id";
            }

        }

        void showBill(int id)
        {
            
            int total = 0;
            using (var tf = new QuanLyQuanCafeEntities())
            {
                // Lấy id của bill chưa thanh toán theo bàn
                var idBill = tf.Bills.Where(a => a.idTable == id && a.status == 0).FirstOrDefault();

                // Xóa data cũ của hóa đơn
                dataGridView1.Rows.Clear();

                // Hiển thị thông tin chi tiết của bill neeus co bill
                if (idBill != null)
                {
                    var listBill = (from a in tf.BillInfoes
                                    join b in tf.Foods
                                    on a.idFood equals b.id
                                    where a.idBill == idBill.id
                                    select new
                                    {
                                        a.id,
                                        b.name,
                                        b.price,
                                        a.count
                                    }).ToList();
                    
                    foreach (var a in listBill)
                    {
                        total += Convert.ToInt32(a.price) * Convert.ToInt32(a.count);
                        dataGridView1.Rows.Add(a.name, a.price, a.count, a.id);
                    }


                }
                else
                {
                    total = 0;
                }
                lbTongTien.Text = Function.FormatCurrency("VND", total);
                lbTongTienHiden.Text = Convert.ToString(total);
            }

        }

        void moveTable(int idBill, int idMoveTable)
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var findBill = tf.Bills.Find(idBill);
                var findTable = tf.TableFoods.Find(idMoveTable);
                if (findBill != null)
                {
                    findTable.status = "Có người";
                    findBill.idTable = idMoveTable;
                    tf.SaveChanges();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(cbDoAn.SelectedValue);
            int countFood = Convert.ToInt32(nrdSoLuong.Value);
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var checkBill = tf.Bills.Where(x => x.idTable == CurrenTableId && x.status == 0).FirstOrDefault();
                if (checkBill == null)
                {
                    var createBillInfo = new BillInfo
                    {
                        idBill = checkBill.id,
                        idFood = idFood,
                        count = countFood,
                    };
                    tf.BillInfoes.Add(createBillInfo);
                    tf.SaveChanges();

                }
                else
                {

                    var checkFood = tf.BillInfoes.Where(x => x.idBill == checkBill.id && x.idFood == idFood).FirstOrDefault();
                    if (checkFood == null)
                    {
                        var addBillInfo = new BillInfo
                        {
                            idBill = checkBill.id,
                            idFood = idFood,
                            count = countFood,
                        };
                        tf.BillInfoes.Add(addBillInfo);
                        tf.SaveChanges();
                    }
                    else
                    {
                        if (btnThem.Text == "Thay đổi")
                        {
                            int a = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                            var findBillInfo = tf.BillInfoes.Find(a);
                            if (findBillInfo != null)
                            {
                                findBillInfo.count = countFood;
                                tf.SaveChanges();

                            }
                        }
                        else
                        {

                            MessageBox.Show("Đã có đồ ăn trong hóa đơn! Vui lòng chỉnh sửa hóa đơn!");
                        }
                    }

                }
                btnThem.Text = "Thêm";
            }
            checkBill();
            showBill(CurrenTableId);
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idCategories = ((sender as ComboBox).SelectedItem as FoodCategory).id;
            using (var tf = new QuanLyQuanCafeEntities())
            {
                cbDoAn.DataSource = tf.Foods.Where(x => x.idCategory == idCategories).ToList();
                cbDoAn.ValueMember = "id";
                cbDoAn.DisplayMember = "name";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThem.Text = "Thay đổi";
            //cbDanhMuc.SelectedIndex = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            string selectedValue = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string selecteCount = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            nrdSoLuong.Value = Convert.ToInt32(selecteCount);
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var findfood = tf.Foods.Where(x => x.name == selectedValue).FirstOrDefault();
                var findcategory = tf.FoodCategories.Where(x => x.id == findfood.idCategory).FirstOrDefault();
                cbDanhMuc.Text = findcategory.name;
                cbDoAn.Text = findfood.name;
            }

            //CurrenBillInfoId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
        }

        private void nbrGiamGia_ValueChanged(object sender, EventArgs e)
        {
            int sale = Convert.ToInt32(nbrGiamGia.Text);
            int total = Convert.ToInt32(lbTongTienHiden.Text);
            if (sale > 0 && sale <= 100)
            {
                total = total - (total * sale) / 100;
            }
            lbTongTien.Text = Function.FormatCurrency("VND", total);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                using (var tf = new QuanLyQuanCafeEntities())
                {
                    int index = (int)dataGridView1.SelectedRows[0].Cells[3].Value;
                    tf.BillInfoes.Remove(tf.BillInfoes.Where(p => p.id == index).SingleOrDefault());
                    tf.SaveChanges();
                }
                checkBill();
                showBill(CurrenTableId);
            }
            else
            {
                MessageBox.Show("Hóa đơn trống!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    var idBill = tf.Bills.Where(a => a.idTable == CurrenTableId && a.status == 0).FirstOrDefault();
                    if (idBill != null)
                    {
                        var updateStatus = tf.Bills.Find(idBill.id);
                        updateStatus.status = 1;
                        checkBill();
                        tf.SaveChanges();
                        Function.updateStatusTable("Trống", CurrenTableId);
                        if (TruyenCha != null)
                        {
                            TruyenCha(CurrenTableId);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hóa đơn không được để trống!!");
                    }
                }
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            using (var tf = new QuanLyQuanCafeEntities())
            {
                var idBill = tf.Bills.Where(a => a.idTable == CurrenTableId && a.status == 0).FirstOrDefault();
                moveTable(idBill.id, Convert.ToInt32(cbChuyenBan.SelectedValue));
                checkBill();
                showBill(CurrenTableId);
                Function.updateStatusTable("Trống", CurrenTableId);
                Function.updateStatusTable("Có người", Convert.ToInt32(cbChuyenBan.SelectedValue));
                if (TruyenCha != null)
                {
                    TruyenCha(CurrenTableId);
                }
            }
        }
    }
}