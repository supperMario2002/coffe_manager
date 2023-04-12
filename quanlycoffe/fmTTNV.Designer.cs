
namespace quanlycoffe
{
    partial class fmTTNV
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddres = new System.Windows.Forms.TextBox();
            this.txtGender = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin Cá Nhân";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(286, 62);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 20);
            this.txtName.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(286, 157);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(184, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // txtAddres
            // 
            this.txtAddres.Location = new System.Drawing.Point(286, 213);
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.Size = new System.Drawing.Size(184, 20);
            this.txtAddres.TabIndex = 4;
            // 
            // txtGender
            // 
            this.txtGender.FormattingEnabled = true;
            this.txtGender.Location = new System.Drawing.Point(286, 110);
            this.txtGender.Name = "txtGender";
            this.txtGender.Size = new System.Drawing.Size(184, 21);
            this.txtGender.TabIndex = 5;
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Location = new System.Drawing.Point(388, 308);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 32);
            this.btnSua.TabIndex = 33;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::quanlycoffe.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(106, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 130);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // fmTTNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 412);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.txtGender);
            this.Controls.Add(this.txtAddres);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "fmTTNV";
            this.Text = "fmTTNV";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddres;
        private System.Windows.Forms.ComboBox txtGender;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}