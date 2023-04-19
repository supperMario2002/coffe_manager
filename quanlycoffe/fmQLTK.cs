using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace quanlycoffe
{
    public partial class fmQLTK : Form
    {

        public fmQLTK()
        {
            InitializeComponent();
            loadTable();
        }

        private int validate()
        {
            string Username = txtTenNguoiDung.Text;
            string DisplayName = txtHoTen.Text;
            string Pass = txtMatKhau.Text;

            if (Username == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return 0;
            }
            if (DisplayName == "")
            {
                MessageBox.Show("Họ tên không được để trống");
                return 0;
            }
            if (Pass == "")
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return 0;
            }
            return 1;
        }
        void reset()
        {
            txtTenNguoiDung.Enabled = true;
            txtTenNguoiDung.Text = "";
            txtHoTen.Text = "";
            txtMatKhau.Text = "";
            txtGioitinh.Text = "";
            txtPhone.Text = "";
            txtDiaChi.Text = "";
        }
        void loadTable()
        {
            using (var db = new QuanLyQuanCafeEntities())
            {
                dataGridView1.Rows.Clear();
                var data = db.Accounts.Where(x=>x.Type != 0).ToList();

                foreach (var i in data)
                {
                    dataGridView1.Rows.Add(i.UserName, i.DisplayName, i.PassWord, i.genner, i.phone, i.address,i.avatar);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyQuanCafeEntities())
            {
                if (validate() == 1)
                {
                    var edit = db.Accounts.Find(txtTenNguoiDung.Text);
                    if (edit != null)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại");
                    }
                    else
                    {
                        var create = new Account
                        {
                            UserName = txtTenNguoiDung.Text,
                            DisplayName = txtHoTen.Text,
                            PassWord = txtMatKhau.Text,
                            Type = 1,
                            genner = txtGioitinh.Text,
                            phone = txtPhone.Text,
                            address = txtDiaChi.Text,
                            avatar = getImage(),
                        };
                        db.Accounts.Add(create);
                        db.SaveChanges();
                        reset();
                        loadTable();
                    }
                }
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string DisplayName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string PassWord = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string genner = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string phone = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            string address = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            byte[] img = (byte[])dataGridView1.Rows[e.RowIndex].Cells[6].Value;
            MemoryStream stream = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(stream);
            txtTenNguoiDung.Enabled = false;
            txtTenNguoiDung.Text = Username;
            txtHoTen.Text = DisplayName;
            txtMatKhau.Text = PassWord;
            txtGioitinh.Text = genner;
            txtPhone.Text = phone;
            txtDiaChi.Text = address;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (validate() == 1)
            {
                string Username = txtTenNguoiDung.Text;
                using (var db = new QuanLyQuanCafeEntities())
                {
                    var edit = db.Accounts.Find(Username);
                    edit.DisplayName = txtHoTen.Text;
                    edit.PassWord = txtMatKhau.Text;
                    edit.genner = txtGioitinh.Text;
                    edit.phone = txtPhone.Text;
                    edit.address = txtDiaChi.Text;
                    db.SaveChanges();
                    reset();
                    loadTable();
                }
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Username = txtTenNguoiDung.Text;
            using (var db = new QuanLyQuanCafeEntities())
            {
                if(Username == "")
                {
                    MessageBox.Show("Hãy chọn 1 bản ghi để xóa");
                }
                else
                {
                    var delete = db.Accounts.Remove(db.Accounts.Where(x => x.UserName == Username).SingleOrDefault());
                    db.SaveChanges();
                    reset();
                    loadTable();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files|*.png| All files(*.*)|*.*";
                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    pictureBox1.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private byte[] getImage()
        {
            MemoryStream stream = new MemoryStream();
            pictureBox1.Image.Save(stream, pictureBox1.Image.RawFormat);

            return stream.GetBuffer();
        }
    }
}
