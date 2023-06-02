namespace Thanh
{
    partial class FrmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDangNhap));
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lbTenDangNHap = new System.Windows.Forms.Label();
            this.tbTenDangNhap = new System.Windows.Forms.TextBox();
            this.tbMatKhau = new System.Windows.Forms.TextBox();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.lbTrangThai = new System.Windows.Forms.Label();
            this.btnKetNoi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(128, 399);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(135, 50);
            this.btnDangNhap.TabIndex = 0;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // lbTenDangNHap
            // 
            this.lbTenDangNHap.AutoSize = true;
            this.lbTenDangNHap.Location = new System.Drawing.Point(39, 213);
            this.lbTenDangNHap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTenDangNHap.Name = "lbTenDangNHap";
            this.lbTenDangNHap.Size = new System.Drawing.Size(98, 16);
            this.lbTenDangNHap.TabIndex = 1;
            this.lbTenDangNHap.Text = "Tên đăng nhập";
            // 
            // tbTenDangNhap
            // 
            this.tbTenDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenDangNhap.Location = new System.Drawing.Point(43, 233);
            this.tbTenDangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.tbTenDangNhap.Name = "tbTenDangNhap";
            this.tbTenDangNhap.Size = new System.Drawing.Size(361, 24);
            this.tbTenDangNhap.TabIndex = 2;
            this.tbTenDangNhap.Text = "chung193";
            // 
            // tbMatKhau
            // 
            this.tbMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMatKhau.Location = new System.Drawing.Point(43, 309);
            this.tbMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.tbMatKhau.Name = "tbMatKhau";
            this.tbMatKhau.PasswordChar = '*';
            this.tbMatKhau.Size = new System.Drawing.Size(361, 24);
            this.tbMatKhau.TabIndex = 4;
            this.tbMatKhau.Text = "123123";
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.AutoSize = true;
            this.lbMatKhau.Location = new System.Drawing.Point(39, 289);
            this.lbMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(61, 16);
            this.lbMatKhau.TabIndex = 3;
            this.lbMatKhau.Text = "Mật khẩu";
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(43, 27);
            this.Logo.Margin = new System.Windows.Forms.Padding(4);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(125, 119);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 5;
            this.Logo.TabStop = false;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(271, 399);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(135, 50);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lbTrangThai
            // 
            this.lbTrangThai.AutoSize = true;
            this.lbTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTrangThai.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTrangThai.Location = new System.Drawing.Point(328, 453);
            this.lbTrangThai.Name = "lbTrangThai";
            this.lbTrangThai.Size = new System.Drawing.Size(35, 51);
            this.lbTrangThai.TabIndex = 7;
            this.lbTrangThai.Text = ".";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKetNoi.BackgroundImage")));
            this.btnKetNoi.Location = new System.Drawing.Point(378, 490);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(26, 27);
            this.btnKetNoi.TabIndex = 8;
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // FrmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 519);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.lbTrangThai);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.tbMatKhau);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.tbTenDangNhap);
            this.Controls.Add(this.lbTenDangNHap);
            this.Controls.Add(this.btnDangNhap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDangNhap_FormClosing);
            this.Load += new System.EventHandler(this.FrmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lbTenDangNHap;
        private System.Windows.Forms.TextBox tbTenDangNhap;
        private System.Windows.Forms.TextBox tbMatKhau;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label lbTrangThai;
        private System.Windows.Forms.Button btnKetNoi;
    }
}

