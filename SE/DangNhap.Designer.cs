namespace SE
{
    partial class DangNhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbxTenDangNhap = new System.Windows.Forms.TextBox();
            this.tbxMatKhau = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lbeError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu:";
            // 
            // tbxTenDangNhap
            // 
            this.tbxTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTenDangNhap.Location = new System.Drawing.Point(208, 9);
            this.tbxTenDangNhap.Name = "tbxTenDangNhap";
            this.tbxTenDangNhap.Size = new System.Drawing.Size(131, 21);
            this.tbxTenDangNhap.TabIndex = 1;
            // 
            // tbxMatKhau
            // 
            this.tbxMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMatKhau.Location = new System.Drawing.Point(208, 35);
            this.tbxMatKhau.Name = "tbxMatKhau";
            this.tbxMatKhau.Size = new System.Drawing.Size(131, 21);
            this.tbxMatKhau.TabIndex = 1;
            this.tbxMatKhau.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SE.Properties.Resources.Coin_us_dollar_icon;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(264, 82);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 3;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(183, 82);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            // 
            // lbeError
            // 
            this.lbeError.ForeColor = System.Drawing.Color.Red;
            this.lbeError.Location = new System.Drawing.Point(112, 59);
            this.lbeError.Name = "lbeError";
            this.lbeError.Size = new System.Drawing.Size(227, 20);
            this.lbeError.TabIndex = 4;
            this.lbeError.Text = "label3";
            this.lbeError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbeError.Visible = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 117);
            this.Controls.Add(this.lbeError);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tbxMatKhau);
            this.Controls.Add(this.tbxTenDangNhap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DangNhap";
            this.Text = "DangNhap";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTenDangNhap;
        private System.Windows.Forms.TextBox tbxMatKhau;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lbeError;
    }
}