
namespace quanlycoffe
{
    partial class fmMainAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.qlnv = new System.Windows.Forms.ToolStripMenuItem();
            this.ban = new System.Windows.Forms.ToolStripMenuItem();
            this.thongke = new System.Windows.Forms.ToolStripMenuItem();
            this.tkMonAn = new System.Windows.Forms.ToolStripMenuItem();
            this.Tkhoadon = new System.Windows.Forms.ToolStripMenuItem();
            this.qldanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.qldoan = new System.Windows.Forms.ToolStripMenuItem();
            this.logOut = new System.Windows.Forms.ToolStripMenuItem();
            this.qlkhachhang = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qlnv,
            this.ban,
            this.thongke,
            this.qldanhmuc,
            this.qldoan,
            this.logOut,
            this.qlkhachhang});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // qlnv
            // 
            this.qlnv.BackColor = System.Drawing.SystemColors.Control;
            this.qlnv.Name = "qlnv";
            this.qlnv.Size = new System.Drawing.Size(115, 20);
            this.qlnv.Text = "Quản lý nhân viên";
            this.qlnv.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // ban
            // 
            this.ban.Name = "ban";
            this.ban.Size = new System.Drawing.Size(83, 20);
            this.ban.Text = "Quản lý bàn";
            this.ban.Click += new System.EventHandler(this.quảnLýBànToolStripMenuItem_Click);
            // 
            // thongke
            // 
            this.thongke.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tkMonAn,
            this.Tkhoadon});
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(68, 20);
            this.thongke.Text = "Thống kê";
            // 
            // tkMonAn
            // 
            this.tkMonAn.Name = "tkMonAn";
            this.tkMonAn.Size = new System.Drawing.Size(171, 22);
            this.tkMonAn.Text = "Thống kê món Ăn";
            this.tkMonAn.Click += new System.EventHandler(this.tkMonAn_Click);
            // 
            // Tkhoadon
            // 
            this.Tkhoadon.Name = "Tkhoadon";
            this.Tkhoadon.Size = new System.Drawing.Size(171, 22);
            this.Tkhoadon.Text = "Thống Kê hóa đơn";
            this.Tkhoadon.Click += new System.EventHandler(this.Tkhoadon_Click);
            // 
            // qldanhmuc
            // 
            this.qldanhmuc.Name = "qldanhmuc";
            this.qldanhmuc.Size = new System.Drawing.Size(117, 20);
            this.qldanhmuc.Text = "Quản lý danh mục";
            this.qldanhmuc.Click += new System.EventHandler(this.qldanhmuc_Click);
            // 
            // qldoan
            // 
            this.qldoan.Name = "qldoan";
            this.qldoan.Size = new System.Drawing.Size(93, 20);
            this.qldoan.Text = "Quản lý đồ ăn";
            this.qldoan.Click += new System.EventHandler(this.quảnLýĐồĂnToolStripMenuItem_Click);
            // 
            // logOut
            // 
            this.logOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logOut.BackColor = System.Drawing.Color.Red;
            this.logOut.Name = "logOut";
            this.logOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logOut.Size = new System.Drawing.Size(74, 20);
            this.logOut.Text = "Đăng Xuất";
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // qlkhachhang
            // 
            this.qlkhachhang.Name = "qlkhachhang";
            this.qlkhachhang.Size = new System.Drawing.Size(125, 20);
            this.qlkhachhang.Text = "Quản lý khách hàng";
            this.qlkhachhang.Click += new System.EventHandler(this.qlkhachhang_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 602);
            this.panel1.TabIndex = 1;
            // 
            // fmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 641);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fmMainAdmin";
            this.Text = "fmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thongke;
        private System.Windows.Forms.ToolStripMenuItem qlnv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem ban;
        private System.Windows.Forms.ToolStripMenuItem qldoan;
        private System.Windows.Forms.ToolStripMenuItem logOut;
        private System.Windows.Forms.ToolStripMenuItem qldanhmuc;
        private System.Windows.Forms.ToolStripMenuItem tkMonAn;
        private System.Windows.Forms.ToolStripMenuItem Tkhoadon;
        private System.Windows.Forms.ToolStripMenuItem qlkhachhang;
    }
}