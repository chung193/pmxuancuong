namespace Thanh.HeThong
{
    partial class FrmXuLyMoRong
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddThongtin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbNgayDen = new System.Windows.Forms.Label();
            this.lbSoMAWB = new System.Windows.Forms.Label();
            this.lbChuyenBay = new System.Windows.Forms.Label();
            this.lbKieu = new System.Windows.Forms.Label();
            this.btnCMS = new System.Windows.Forms.Button();
            this.btnMIC = new System.Windows.Forms.Button();
            this.BtnXuat1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSheet = new System.Windows.Forms.ComboBox();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.txtChonFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvXuLy = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuLy)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddThongtin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbNgayDen);
            this.groupBox1.Controls.Add(this.lbSoMAWB);
            this.groupBox1.Controls.Add(this.lbChuyenBay);
            this.groupBox1.Controls.Add(this.lbKieu);
            this.groupBox1.Controls.Add(this.btnCMS);
            this.groupBox1.Controls.Add(this.btnMIC);
            this.groupBox1.Controls.Add(this.BtnXuat1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSheet);
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Controls.Add(this.txtChonFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1792, 124);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xử lý";
            // 
            // btnAddThongtin
            // 
            this.btnAddThongtin.Location = new System.Drawing.Point(1493, 39);
            this.btnAddThongtin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddThongtin.Name = "btnAddThongtin";
            this.btnAddThongtin.Size = new System.Drawing.Size(100, 34);
            this.btnAddThongtin.TabIndex = 16;
            this.btnAddThongtin.Text = "...";
            this.btnAddThongtin.UseVisualStyleBackColor = true;
            this.btnAddThongtin.Click += new System.EventHandler(this.btnAddThongtin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1253, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ngày đến:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1241, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Chuyến bay:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(883, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Số MAWB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kiểu:";
            // 
            // lbNgayDen
            // 
            this.lbNgayDen.AutoSize = true;
            this.lbNgayDen.Location = new System.Drawing.Point(1351, 86);
            this.lbNgayDen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNgayDen.Name = "lbNgayDen";
            this.lbNgayDen.Size = new System.Drawing.Size(0, 16);
            this.lbNgayDen.TabIndex = 11;
            // 
            // lbSoMAWB
            // 
            this.lbSoMAWB.AutoSize = true;
            this.lbSoMAWB.Location = new System.Drawing.Point(1008, 86);
            this.lbSoMAWB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSoMAWB.Name = "lbSoMAWB";
            this.lbSoMAWB.Size = new System.Drawing.Size(0, 16);
            this.lbSoMAWB.TabIndex = 10;
            // 
            // lbChuyenBay
            // 
            this.lbChuyenBay.AutoSize = true;
            this.lbChuyenBay.Location = new System.Drawing.Point(1351, 47);
            this.lbChuyenBay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChuyenBay.Name = "lbChuyenBay";
            this.lbChuyenBay.Size = new System.Drawing.Size(0, 16);
            this.lbChuyenBay.TabIndex = 9;
            // 
            // lbKieu
            // 
            this.lbKieu.AutoSize = true;
            this.lbKieu.Location = new System.Drawing.Point(1008, 43);
            this.lbKieu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKieu.Name = "lbKieu";
            this.lbKieu.Size = new System.Drawing.Size(0, 16);
            this.lbKieu.TabIndex = 8;
            // 
            // btnCMS
            // 
            this.btnCMS.Location = new System.Drawing.Point(1600, 39);
            this.btnCMS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCMS.Name = "btnCMS";
            this.btnCMS.Size = new System.Drawing.Size(187, 34);
            this.btnCMS.TabIndex = 7;
            this.btnCMS.Text = "Xuất file CMS";
            this.btnCMS.UseVisualStyleBackColor = true;
            this.btnCMS.Click += new System.EventHandler(this.btnCMS_Click);
            // 
            // btnMIC
            // 
            this.btnMIC.Location = new System.Drawing.Point(1600, 76);
            this.btnMIC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMIC.Name = "btnMIC";
            this.btnMIC.Size = new System.Drawing.Size(187, 34);
            this.btnMIC.TabIndex = 6;
            this.btnMIC.Text = "Xuất file MIC chuẩn";
            this.btnMIC.UseVisualStyleBackColor = true;
            this.btnMIC.Click += new System.EventHandler(this.btnMIC_Click);
            // 
            // BtnXuat1
            // 
            this.BtnXuat1.Location = new System.Drawing.Point(629, 69);
            this.BtnXuat1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnXuat1.Name = "BtnXuat1";
            this.BtnXuat1.Size = new System.Drawing.Size(187, 34);
            this.BtnXuat1.TabIndex = 5;
            this.BtnXuat1.Text = "Xuất bảng kê OLA";
            this.BtnXuat1.UseVisualStyleBackColor = true;
            this.BtnXuat1.Click += new System.EventHandler(this.BtnXuat1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(509, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn sheet";
            // 
            // cbSheet
            // 
            this.cbSheet.FormattingEnabled = true;
            this.cbSheet.Location = new System.Drawing.Point(608, 38);
            this.cbSheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSheet.Name = "cbSheet";
            this.cbSheet.Size = new System.Drawing.Size(207, 24);
            this.cbSheet.TabIndex = 3;
            this.cbSheet.SelectedIndexChanged += new System.EventHandler(this.cbSheet_SelectedIndexChanged);
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(103, 69);
            this.btnChonFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(187, 34);
            this.btnChonFile.TabIndex = 2;
            this.btnChonFile.Text = "Chọn file";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // txtChonFile
            // 
            this.txtChonFile.Location = new System.Drawing.Point(103, 39);
            this.txtChonFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChonFile.Name = "txtChonFile";
            this.txtChonFile.Size = new System.Drawing.Size(392, 22);
            this.txtChonFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn file";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // dgvXuLy
            // 
            this.dgvXuLy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvXuLy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXuLy.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvXuLy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvXuLy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvXuLy.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvXuLy.Location = new System.Drawing.Point(12, 142);
            this.dgvXuLy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvXuLy.Name = "dgvXuLy";
            this.dgvXuLy.RowHeadersWidth = 51;
            this.dgvXuLy.RowTemplate.Height = 24;
            this.dgvXuLy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXuLy.Size = new System.Drawing.Size(1795, 804);
            this.dgvXuLy.TabIndex = 1;
            // 
            // FrmXuLyMoRong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1819, 959);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvXuLy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmXuLyMoRong";
            this.Text = "FrmXuLyMoRong";
            this.Load += new System.EventHandler(this.FrmXuLyMoRong_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXuLy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.TextBox txtChonFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSheet;
        private System.Windows.Forms.Button BtnXuat1;
        private System.Windows.Forms.Button btnCMS;
        private System.Windows.Forms.Button btnMIC;
        private System.Windows.Forms.Label lbKieu;
        private System.Windows.Forms.Label lbNgayDen;
        private System.Windows.Forms.Label lbSoMAWB;
        private System.Windows.Forms.Label lbChuyenBay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddThongtin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvXuLy;
    }
}