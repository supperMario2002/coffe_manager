using iTextSharp.text;
using iTextSharp.text.pdf;
using quanlycoffe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeManager
{
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            loadData();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
        }

        void loadData()
        {
            using(var tk = new QuanLyQuanCafeEntities())
            {
                var kqCheck = (from a in tk.ThongKeBills
                               select a
                              ).ToList();
                foreach (var a in kqCheck)
                {
                    dataGridiew1.Rows.Add(a.id, a.DateCheckOut, a.tong);
                }
            }
        }

        
        public void showBillDetail()
        {
            using (var tk = new QuanLyQuanCafeEntities())
            {
                /*var idBill = tk.BillInfoes.SqlQuery("Select * from BillInfo where id ='" + _id  + "'").FirstOrDefault();*/
            }
        }

        public void checkDateBill()
        {
            dataGridiew1.Rows.Clear();
            using (var tk = new QuanLyQuanCafeEntities())
            {
                DateTime theDateto = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());

                DateTime theDatelast = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());


                var kqCheck = (from a in tk.ThongKeBills
                              where (a.DateCheckOut >= theDateto.Date && a.DateCheckOut <= theDatelast.Date)
                              select a
                              ).ToList();
                foreach (var a in kqCheck)
                {
                    dataGridiew1.Rows.Add(a.id, a.DateCheckOut, a.tong);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string txtGetId = dataGridiew1.CurrentRow.Cells[0].Value.ToString();
            using (var tk = new QuanLyQuanCafeEntities())
            {
                int id = Convert.ToInt32(txtGetId);
                var txtBan = (from a in tk.Bills
                              join b in tk.TableFoods
                              on a.idTable equals b.id
                              where a.id == id
                              select new
                              {
                                  b.name
                              }).FirstOrDefault();
            frmThongKeDetail ftk = new frmThongKeDetail();
            ftk.Sender(txtGetId, txtBan.name);
            ftk.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            checkDateBill();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            dataGridiew1.AllowUserToAddRows = false;
            if (dataGridiew1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridiew1.Columns.Count);
                            pdfTable.DefaultCell.Padding = 5;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;


                            foreach (DataGridViewColumn column in dataGridiew1.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridiew1.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Dữ liệu Export thành công!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mô tả lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        private void thốngKêHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêMónĂnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
    
}
