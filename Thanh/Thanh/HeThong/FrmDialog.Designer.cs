namespace Thanh.HeThong
{
    partial class FrmDialog
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
            this.txtKieu = new System.Windows.Forms.TextBox();
            this.txtChuyenBay = new System.Windows.Forms.TextBox();
            this.txtSoMAWB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayDen = new System.Windows.Forms.DateTimePicker();
            this.btnXong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtKieu
            // 
            this.txtKieu.Location = new System.Drawing.Point(114, 27);
            this.txtKieu.Name = "txtKieu";
            this.txtKieu.Size = new System.Drawing.Size(210, 20);
            this.txtKieu.TabIndex = 0;
            // 
            // txtChuyenBay
            // 
            this.txtChuyenBay.Location = new System.Drawing.Point(114, 104);
            this.txtChuyenBay.Name = "txtChuyenBay";
            this.txtChuyenBay.Size = new System.Drawing.Size(210, 20);
            this.txtChuyenBay.TabIndex = 2;
            // 
            // txtSoMAWB
            // 
            this.txtSoMAWB.Location = new System.Drawing.Point(114, 64);
            this.txtSoMAWB.Name = "txtSoMAWB";
            this.txtSoMAWB.Size = new System.Drawing.Size(210, 20);
            this.txtSoMAWB.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kiểu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày đến";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chuyến bay";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số MAWB";
            // 
            // dtpNgayDen
            // 
            this.dtpNgayDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDen.Location = new System.Drawing.Point(114, 145);
            this.dtpNgayDen.Name = "dtpNgayDen";
            this.dtpNgayDen.Size = new System.Drawing.Size(210, 20);
            this.dtpNgayDen.TabIndex = 9;
            // 
            // btnXong
            // 
            this.btnXong.Location = new System.Drawing.Point(232, 179);
            this.btnXong.Name = "btnXong";
            this.btnXong.Size = new System.Drawing.Size(92, 32);
            this.btnXong.TabIndex = 10;
            this.btnXong.Text = "Xong";
            this.btnXong.UseVisualStyleBackColor = true;
            this.btnXong.Click += new System.EventHandler(this.btnXong_Click);
            // 
            // FrmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 223);
            this.Controls.Add(this.btnXong);
            this.Controls.Add(this.dtpNgayDen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoMAWB);
            this.Controls.Add(this.txtChuyenBay);
            this.Controls.Add(this.txtKieu);
            this.Name = "FrmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điền 1 số thông tin cần thiết";
            this.Load += new System.EventHandler(this.FrmDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKieu;
        private System.Windows.Forms.TextBox txtChuyenBay;
        private System.Windows.Forms.TextBox txtSoMAWB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpNgayDen;
        private System.Windows.Forms.Button btnXong;
    }
}