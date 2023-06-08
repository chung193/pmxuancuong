namespace Thanh.HeThong
{
    partial class FrmQuanLyKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuanLyKey));
            this.err = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label42423 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.GP = new System.Windows.Forms.GroupBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaterialcall = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtConvertname = new System.Windows.Forms.TextBox();
            this.txtClassifyType = new System.Windows.Forms.TextBox();
            this.txtClassify = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvKey = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.loadingBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            this.GP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(596, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Classify Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Key";
            // 
            // label42423
            // 
            this.label42423.AutoSize = true;
            this.label42423.Location = new System.Drawing.Point(7, 45);
            this.label42423.Name = "label42423";
            this.label42423.Size = new System.Drawing.Size(26, 13);
            this.label42423.TabIndex = 10;
            this.label42423.Text = "Unit";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(354, 38);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(215, 20);
            this.txtMaterial.TabIndex = 8;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(39, 78);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(215, 20);
            this.txtKey.TabIndex = 7;
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(39, 38);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(215, 20);
            this.txtUnit.TabIndex = 6;
            // 
            // GP
            // 
            this.GP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GP.Controls.Add(this.txtBrand);
            this.GP.Controls.Add(this.label7);
            this.GP.Controls.Add(this.txtMaterialcall);
            this.GP.Controls.Add(this.label6);
            this.GP.Controls.Add(this.label5);
            this.GP.Controls.Add(this.txtConvertname);
            this.GP.Controls.Add(this.txtClassifyType);
            this.GP.Controls.Add(this.txtClassify);
            this.GP.Controls.Add(this.label1);
            this.GP.Controls.Add(this.label4);
            this.GP.Controls.Add(this.label3);
            this.GP.Controls.Add(this.label2);
            this.GP.Controls.Add(this.label42423);
            this.GP.Controls.Add(this.txtMaterial);
            this.GP.Controls.Add(this.txtKey);
            this.GP.Controls.Add(this.txtUnit);
            this.GP.Location = new System.Drawing.Point(12, 8);
            this.GP.Name = "GP";
            this.GP.Size = new System.Drawing.Size(917, 157);
            this.GP.TabIndex = 9;
            this.GP.TabStop = false;
            this.GP.Text = "Quản lý file key";
            this.GP.Enter += new System.EventHandler(this.GP_Enter);
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(39, 118);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(530, 20);
            this.txtBrand.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Brand";
            // 
            // txtMaterialcall
            // 
            this.txtMaterialcall.Location = new System.Drawing.Point(354, 80);
            this.txtMaterialcall.Name = "txtMaterialcall";
            this.txtMaterialcall.Size = new System.Drawing.Size(215, 20);
            this.txtMaterialcall.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Material Call";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Convert name";
            // 
            // txtConvertname
            // 
            this.txtConvertname.Location = new System.Drawing.Point(686, 118);
            this.txtConvertname.Name = "txtConvertname";
            this.txtConvertname.Size = new System.Drawing.Size(215, 20);
            this.txtConvertname.TabIndex = 20;
            // 
            // txtClassifyType
            // 
            this.txtClassifyType.Location = new System.Drawing.Point(686, 77);
            this.txtClassifyType.Name = "txtClassifyType";
            this.txtClassifyType.Size = new System.Drawing.Size(215, 20);
            this.txtClassifyType.TabIndex = 19;
            // 
            // txtClassify
            // 
            this.txtClassify.Location = new System.Drawing.Point(686, 40);
            this.txtClassify.Name = "txtClassify";
            this.txtClassify.Size = new System.Drawing.Size(215, 20);
            this.txtClassify.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Classify";
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Location = new System.Drawing.Point(87, 0);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(68, 33);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Location = new System.Drawing.Point(235, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(68, 33);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.Location = new System.Drawing.Point(161, 0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 33);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(197, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(0, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(215, 22);
            this.txtTimKiem.TabIndex = 8;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Location = new System.Drawing.Point(685, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(243, 33);
            this.panel2.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Location = new System.Drawing.Point(2, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 33);
            this.panel1.TabIndex = 7;
            // 
            // btnExcel
            // 
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(495, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(171, 33);
            this.btnExcel.TabIndex = 10;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThem
            // 
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.Location = new System.Drawing.Point(13, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(68, 33);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvKey
            // 
            this.dgvKey.AllowDrop = true;
            this.dgvKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKey.Location = new System.Drawing.Point(12, 237);
            this.dgvKey.Name = "dgvKey";
            this.dgvKey.ReadOnly = true;
            this.dgvKey.RowHeadersWidth = 51;
            this.dgvKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKey.Size = new System.Drawing.Size(917, 332);
            this.dgvKey.TabIndex = 8;
            this.dgvKey.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKey_CellContentClick);
            this.dgvKey.SelectionChanged += new System.EventHandler(this.dgvKey_SelectionChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(686, 211);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Tổng số";
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Location = new System.Drawing.Point(748, 211);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(0, 13);
            this.txtTotal.TabIndex = 11;
            // 
            // loadingBox
            // 
            this.loadingBox.Image = ((System.Drawing.Image)(resources.GetObject("loadingBox.Image")));
            this.loadingBox.Location = new System.Drawing.Point(377, 306);
            this.loadingBox.Name = "loadingBox";
            this.loadingBox.Size = new System.Drawing.Size(220, 220);
            this.loadingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingBox.TabIndex = 12;
            this.loadingBox.TabStop = false;
            this.loadingBox.Visible = false;
            // 
            // FrmQuanLyKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 582);
            this.Controls.Add(this.loadingBox);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmQuanLyKey";
            this.Text = "FrmQuanLyFileKey";
            this.Load += new System.EventHandler(this.FrmQuanLyFileKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            this.GP.ResumeLayout(false);
            this.GP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider err;
        private System.Windows.Forms.GroupBox GP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label42423;
        private System.Windows.Forms.TextBox txtMaterial;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvKey;
        private System.Windows.Forms.TextBox txtClassifyType;
        private System.Windows.Forms.TextBox txtClassify;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtConvertname;
        private System.Windows.Forms.TextBox txtMaterialcall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.PictureBox loadingBox;
    }
}