
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
            this.qldanhmuc = new System.Windows.Forms.ToolStripMenuItem();
            this.qldoan = new System.Windows.Forms.ToolStripMenuItem();
            this.logOut = new System.Windows.Forms.ToolStripMenuItem();
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
            this.logOut});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(883, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // qlnv
            // 
            this.qlnv.BackColor = System.Drawing.SystemColors.Control;
            this.qlnv.Name = "qlnv";
            this.qlnv.Size = new System.Drawing.Size(140, 24);
            this.qlnv.Text = "Quản lý nhân viên";
            this.qlnv.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // ban
            // 
            this.ban.Name = "ban";
            this.ban.Size = new System.Drawing.Size(102, 24);
            this.ban.Text = "Quản lý bàn";
            this.ban.Click += new System.EventHandler(this.quảnLýBànToolStripMenuItem_Click);
            // 
            // thongke
            // 
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(84, 24);
            this.thongke.Text = "Thống kê";
            this.thongke.Click += new System.EventHandler(this.thongke_Click);
            // 
            // qldanhmuc
            // 
            this.qldanhmuc.Name = "qldanhmuc";
            this.qldanhmuc.Size = new System.Drawing.Size(142, 24);
            this.qldanhmuc.Text = "Quản lý danh mục";
            this.qldanhmuc.Click += new System.EventHandler(this.qldanhmuc_Click);
            // 
            // qldoan
            // 
            this.qldoan.Name = "qldoan";
            this.qldoan.Size = new System.Drawing.Size(115, 24);
            this.qldoan.Text = "Quản lý đồ ăn";
            this.qldoan.Click += new System.EventHandler(this.quảnLýĐồĂnToolStripMenuItem_Click);
            // 
            // logOut
            // 
            this.logOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logOut.BackColor = System.Drawing.Color.Red;
            this.logOut.Name = "logOut";
            this.logOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logOut.Size = new System.Drawing.Size(93, 24);
            this.logOut.Text = "Đăng Xuất";
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 602);
            this.panel1.TabIndex = 1;
            // 
            // fmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}