namespace Thanh.HeThong
{
    partial class FrmCheck
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbDangChon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cbFile = new System.Windows.Forms.ComboBox();
            this.checkDgv = new System.Windows.Forms.DataGridView();
            this.sothungDgv = new System.Windows.Forms.DataGridView();
            this.sothung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sothungDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbDangChon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.cbFile);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(953, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // lbDangChon
            // 
            this.lbDangChon.AutoSize = true;
            this.lbDangChon.Location = new System.Drawing.Point(19, 72);
            this.lbDangChon.Name = "lbDangChon";
            this.lbDangChon.Size = new System.Drawing.Size(0, 13);
            this.lbDangChon.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(730, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Điền số thùng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn file";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(297, 46);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(119, 23);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Chọn file này";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(733, 49);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(203, 20);
            this.txtCode.TabIndex = 2;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // cbFile
            // 
            this.cbFile.FormattingEnabled = true;
            this.cbFile.Location = new System.Drawing.Point(22, 48);
            this.cbFile.Name = "cbFile";
            this.cbFile.Size = new System.Drawing.Size(269, 21);
            this.cbFile.TabIndex = 1;
            this.cbFile.SelectedIndexChanged += new System.EventHandler(this.cbFile_SelectedIndexChanged);
            this.cbFile.SelectedValueChanged += new System.EventHandler(this.cbFile_SelectedValueChanged);
            // 
            // checkDgv
            // 
            this.checkDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.checkDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.checkDgv.Location = new System.Drawing.Point(12, 118);
            this.checkDgv.Name = "checkDgv";
            this.checkDgv.Size = new System.Drawing.Size(702, 525);
            this.checkDgv.TabIndex = 1;
            // 
            // sothungDgv
            // 
            this.sothungDgv.AllowUserToAddRows = false;
            this.sothungDgv.AllowUserToDeleteRows = false;
            this.sothungDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sothungDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sothungDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sothungDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sothung});
            this.sothungDgv.Location = new System.Drawing.Point(720, 118);
            this.sothungDgv.Name = "sothungDgv";
            this.sothungDgv.ReadOnly = true;
            this.sothungDgv.Size = new System.Drawing.Size(245, 525);
            this.sothungDgv.TabIndex = 2;
            // 
            // sothung
            // 
            this.sothung.HeaderText = "Số thùng đã nhập";
            this.sothung.Name = "sothung";
            this.sothung.ReadOnly = true;
            // 
            // FrmCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 655);
            this.Controls.Add(this.sothungDgv);
            this.Controls.Add(this.checkDgv);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCheck";
            this.Text = "FrmCheck";
            this.Load += new System.EventHandler(this.FrmCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sothungDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cbFile;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView checkDgv;
        private System.Windows.Forms.Label lbDangChon;
        private System.Windows.Forms.DataGridView sothungDgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn sothung;
    }
}