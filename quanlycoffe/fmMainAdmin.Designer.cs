
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
            this.thongke = new System.Windows.Forms.ToolStripMenuItem();
            this.qlnv = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ban = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qlnv,
            this.ban,
            this.thongke});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // thongke
            // 
            this.thongke.Name = "thongke";
            this.thongke.Size = new System.Drawing.Size(84, 24);
            this.thongke.Text = "Thống kê";
            this.thongke.Click += new System.EventHandler(this.thongke_Click);
            // 
            // qlnv
            // 
            this.qlnv.BackColor = System.Drawing.SystemColors.Control;
            this.qlnv.Name = "qlnv";
            this.qlnv.Size = new System.Drawing.Size(140, 24);
            this.qlnv.Text = "Quản lý nhân viên";
            this.qlnv.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 602);
            this.panel1.TabIndex = 1;
            // 
            // ban
            // 
            this.ban.Name = "ban";
            this.ban.Size = new System.Drawing.Size(104, 24);
            this.ban.Text = "Quản Lý Bàn";
            this.ban.Click += new System.EventHandler(this.quảnLýBànToolStripMenuItem_Click);
            // 
            // fmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 633);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}