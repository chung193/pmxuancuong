namespace Thanh.HeThong
{
    partial class FrmGiaoDienChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGiaoDienChinh));
            this.plChinh = new System.Windows.Forms.Panel();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.tabNguoiDung = new System.Windows.Forms.RibbonTab();
            this.panelNguoiDung = new System.Windows.Forms.RibbonPanel();
            this.panelThoat = new System.Windows.Forms.RibbonPanel();
            this.tabKey = new System.Windows.Forms.RibbonTab();
            this.panelQLFileKey = new System.Windows.Forms.RibbonPanel();
            this.panelUploadKey = new System.Windows.Forms.RibbonPanel();
            this.panelQLKey = new System.Windows.Forms.RibbonPanel();
            this.tabNhanHieu = new System.Windows.Forms.RibbonTab();
            this.panelUploadFile = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.panelNhanHieu = new System.Windows.Forms.RibbonPanel();
            this.tabFakeData = new System.Windows.Forms.RibbonTab();
            this.panelNguoiDungFake = new System.Windows.Forms.RibbonPanel();
            this.tabXuLy = new System.Windows.Forms.RibbonTab();
            this.panelThanhPho = new System.Windows.Forms.RibbonPanel();
            this.panelTenThayThe = new System.Windows.Forms.RibbonPanel();
            this.panelDichLoc = new System.Windows.Forms.RibbonPanel();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.SuspendLayout();
            // 
            // plChinh
            // 
            this.plChinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plChinh.Location = new System.Drawing.Point(12, 154);
            this.plChinh.Name = "plChinh";
            this.plChinh.Size = new System.Drawing.Size(1010, 506);
            this.plChinh.TabIndex = 0;
            // 
            // ribbon1
            // 
            this.ribbon1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ribbon1.BackgroundImage")));
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1034, 139);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.tabNguoiDung);
            this.ribbon1.Tabs.Add(this.tabKey);
            this.ribbon1.Tabs.Add(this.tabNhanHieu);
            this.ribbon1.Tabs.Add(this.tabFakeData);
            this.ribbon1.Tabs.Add(this.tabXuLy);
            this.ribbon1.Text = "ribbon1";
            // 
            // tabNguoiDung
            // 
            this.tabNguoiDung.Name = "tabNguoiDung";
            this.tabNguoiDung.Panels.Add(this.panelNguoiDung);
            this.tabNguoiDung.Panels.Add(this.panelThoat);
            this.tabNguoiDung.Text = "Người dùng";
            // 
            // panelNguoiDung
            // 
            this.panelNguoiDung.Image = ((System.Drawing.Image)(resources.GetObject("panelNguoiDung.Image")));
            this.panelNguoiDung.Name = "panelNguoiDung";
            this.panelNguoiDung.Text = "Quản lý người dùng";
            this.panelNguoiDung.Click += new System.EventHandler(this.panelNguoiDung_Click);
            // 
            // panelThoat
            // 
            this.panelThoat.Name = "panelThoat";
            this.panelThoat.Text = "Thoát";
            this.panelThoat.Click += new System.EventHandler(this.panelThoat_Click);
            // 
            // tabKey
            // 
            this.tabKey.Name = "tabKey";
            this.tabKey.Panels.Add(this.panelQLFileKey);
            this.tabKey.Panels.Add(this.panelUploadKey);
            this.tabKey.Panels.Add(this.panelQLKey);
            this.tabKey.Text = "Key";
            // 
            // panelQLFileKey
            // 
            this.panelQLFileKey.Name = "panelQLFileKey";
            this.panelQLFileKey.Text = "Quản lý file key";
            this.panelQLFileKey.Click += new System.EventHandler(this.panelQLFileKey_Click);
            // 
            // panelUploadKey
            // 
            this.panelUploadKey.Name = "panelUploadKey";
            this.panelUploadKey.Text = "Upload file key";
            this.panelUploadKey.Click += new System.EventHandler(this.panelUploadKey_Click);
            // 
            // panelQLKey
            // 
            this.panelQLKey.Name = "panelQLKey";
            this.panelQLKey.Text = "Quản lý key";
            this.panelQLKey.Click += new System.EventHandler(this.panelQLKey_Click);
            // 
            // tabNhanHieu
            // 
            this.tabNhanHieu.Name = "tabNhanHieu";
            this.tabNhanHieu.Panels.Add(this.panelUploadFile);
            this.tabNhanHieu.Panels.Add(this.ribbonPanel1);
            this.tabNhanHieu.Panels.Add(this.panelNhanHieu);
            this.tabNhanHieu.Text = "Nhãn hiệu";
            // 
            // panelUploadFile
            // 
            this.panelUploadFile.Name = "panelUploadFile";
            this.panelUploadFile.Text = "Quản lý file nhãn hiệu";
            this.panelUploadFile.Click += new System.EventHandler(this.panelUploadFile_Click);
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Upload file nhãn hiệu";
            this.ribbonPanel1.Click += new System.EventHandler(this.ribbonPanel1_Click);
            // 
            // panelNhanHieu
            // 
            this.panelNhanHieu.Name = "panelNhanHieu";
            this.panelNhanHieu.Text = "QL nhãn hiệu";
            this.panelNhanHieu.Click += new System.EventHandler(this.panelNhanHieu_Click);
            // 
            // tabFakeData
            // 
            this.tabFakeData.Name = "tabFakeData";
            this.tabFakeData.Panels.Add(this.panelNguoiDungFake);
            this.tabFakeData.Panels.Add(this.panelThanhPho);
            this.tabFakeData.Panels.Add(this.panelTenThayThe);
            this.tabFakeData.Text = "Dữ liệu fake";
            // 
            // panelNguoiDungFake
            // 
            this.panelNguoiDungFake.Name = "panelNguoiDungFake";
            this.panelNguoiDungFake.Text = "Người dùng fake";
            this.panelNguoiDungFake.Click += new System.EventHandler(this.panelNguoiDungFake_Click);
            // 
            // tabXuLy
            // 
            this.tabXuLy.Name = "tabXuLy";
            this.tabXuLy.Panels.Add(this.panelDichLoc);
            this.tabXuLy.Text = "Xử lý";
            // 
            // panelThanhPho
            // 
            this.panelThanhPho.Name = "panelThanhPho";
            this.panelThanhPho.Text = "Thành phố";
            this.panelThanhPho.Click += new System.EventHandler(this.panelThanhPho_Click);
            // 
            // panelTenThayThe
            // 
            this.panelTenThayThe.Name = "panelTenThayThe";
            this.panelTenThayThe.Text = "Tên thay thế";
            this.panelTenThayThe.Click += new System.EventHandler(this.panelTenThayThe_Click);
            // 
            // panelDichLoc
            // 
            this.panelDichLoc.Name = "panelDichLoc";
            this.panelDichLoc.Text = "Dịch lọc";
            this.panelDichLoc.Click += new System.EventHandler(this.panelDichLoc_Click);
            
            // 
            // FrmGiaoDienChinh
            // 
            this.ClientSize = new System.Drawing.Size(1034, 672);
            this.Controls.Add(this.ribbon1);
            this.Controls.Add(this.plChinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmGiaoDienChinh";
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel plChinh;
        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab tabNguoiDung;
        private System.Windows.Forms.RibbonPanel panelNguoiDung;
        private System.Windows.Forms.RibbonPanel panelThoat;
        private System.Windows.Forms.RibbonTab tabKey;
        private System.Windows.Forms.RibbonPanel panelQLFileKey;
        private System.Windows.Forms.RibbonPanel panelUploadKey;
        private System.Windows.Forms.RibbonPanel panelQLKey;
        private System.Windows.Forms.RibbonTab tabNhanHieu;
        private System.Windows.Forms.RibbonPanel panelUploadFile;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel panelNhanHieu;
        private System.Windows.Forms.RibbonTab tabFakeData;
        private System.Windows.Forms.RibbonPanel panelNguoiDungFake;
        private System.Windows.Forms.RibbonTab tabXuLy;
        private System.Windows.Forms.RibbonPanel panelThanhPho;
        private System.Windows.Forms.RibbonPanel panelTenThayThe;
        private System.Windows.Forms.RibbonPanel panelDichLoc;
        private System.Windows.Forms.RibbonPanel panelXuLy;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
    }
}