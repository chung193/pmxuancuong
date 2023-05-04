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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNguoiDung = new DevExpress.XtraBars.BarButtonItem();
            this.bbiKey = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTaiFileKey = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQuanLyFileKey = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNhanHieu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTaiFileNhanHieu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiQuanLyFileNhanHieu = new DevExpress.XtraBars.BarButtonItem();
            this.bbiXuLyFile = new DevExpress.XtraBars.BarButtonItem();
            this.bbiThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bbtnTinhThanhPho = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.bbtTenThayThe = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // plChinh
            // 
            this.plChinh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plChinh.Location = new System.Drawing.Point(0, 150);
            this.plChinh.Name = "plChinh";
            this.plChinh.Size = new System.Drawing.Size(948, 439);
            this.plChinh.TabIndex = 1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(43, 46, 43, 46);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.barButtonItem1,
            this.barButtonItem2,
            this.bbiNguoiDung,
            this.bbiKey,
            this.bbiTaiFileKey,
            this.bbiQuanLyFileKey,
            this.bbiNhanHieu,
            this.bbiTaiFileNhanHieu,
            this.bbiQuanLyFileNhanHieu,
            this.bbiXuLyFile,
            this.bbiThoat,
            this.barButtonItem3,
            this.bbtnTinhThanhPho,
            this.barButtonItem4,
            this.bbtTenThayThe});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl1.MaxItemId = 17;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 483;
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(948, 150);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbiNguoiDung
            // 
            this.bbiNguoiDung.Caption = "Người dùng";
            this.bbiNguoiDung.Id = 4;
            this.bbiNguoiDung.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNguoiDung.ImageOptions.Image")));
            this.bbiNguoiDung.Name = "bbiNguoiDung";
            this.bbiNguoiDung.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNguoiDung_ItemClick);
            // 
            // bbiKey
            // 
            this.bbiKey.Caption = "Danh sách key";
            this.bbiKey.Id = 5;
            this.bbiKey.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiKey.ImageOptions.Image")));
            this.bbiKey.Name = "bbiKey";
            this.bbiKey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // bbiTaiFileKey
            // 
            this.bbiTaiFileKey.Caption = "Tải file";
            this.bbiTaiFileKey.Id = 6;
            this.bbiTaiFileKey.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiTaiFileKey.ImageOptions.Image")));
            this.bbiTaiFileKey.Name = "bbiTaiFileKey";
            this.bbiTaiFileKey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // bbiQuanLyFileKey
            // 
            this.bbiQuanLyFileKey.Caption = "Quản lý file";
            this.bbiQuanLyFileKey.Id = 7;
            this.bbiQuanLyFileKey.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiQuanLyFileKey.ImageOptions.Image")));
            this.bbiQuanLyFileKey.Name = "bbiQuanLyFileKey";
            this.bbiQuanLyFileKey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // bbiNhanHieu
            // 
            this.bbiNhanHieu.Caption = "Danh sách nhãn hiệu";
            this.bbiNhanHieu.Id = 8;
            this.bbiNhanHieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiNhanHieu.ImageOptions.Image")));
            this.bbiNhanHieu.Name = "bbiNhanHieu";
            this.bbiNhanHieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // bbiTaiFileNhanHieu
            // 
            this.bbiTaiFileNhanHieu.Caption = "Tải file";
            this.bbiTaiFileNhanHieu.Id = 9;
            this.bbiTaiFileNhanHieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiTaiFileNhanHieu.ImageOptions.Image")));
            this.bbiTaiFileNhanHieu.Name = "bbiTaiFileNhanHieu";
            this.bbiTaiFileNhanHieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // bbiQuanLyFileNhanHieu
            // 
            this.bbiQuanLyFileNhanHieu.Caption = "Quản lý file";
            this.bbiQuanLyFileNhanHieu.Id = 10;
            this.bbiQuanLyFileNhanHieu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiQuanLyFileNhanHieu.ImageOptions.Image")));
            this.bbiQuanLyFileNhanHieu.Name = "bbiQuanLyFileNhanHieu";
            this.bbiQuanLyFileNhanHieu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // bbiXuLyFile
            // 
            this.bbiXuLyFile.Caption = "Xử lý file";
            this.bbiXuLyFile.Id = 11;
            this.bbiXuLyFile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiXuLyFile.ImageOptions.Image")));
            this.bbiXuLyFile.Name = "bbiXuLyFile";
            this.bbiXuLyFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // bbiThoat
            // 
            this.bbiThoat.Caption = "Thoát";
            this.bbiThoat.Id = 12;
            this.bbiThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiThoat.ImageOptions.Image")));
            this.bbiThoat.Name = "bbiThoat";
            this.bbiThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem10_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Xử lý mở rộng";
            this.barButtonItem3.Id = 13;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // bbtnTinhThanhPho
            // 
            this.bbtnTinhThanhPho.Caption = "Tỉnh thành phố";
            this.bbtnTinhThanhPho.Id = 14;
            this.bbtnTinhThanhPho.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtnTinhThanhPho.ImageOptions.Image")));
            this.bbtnTinhThanhPho.Name = "bbtnTinhThanhPho";
            this.bbtnTinhThanhPho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtnTinhThanhPho_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Người dùng";
            this.barButtonItem4.Id = 15;
            this.barButtonItem4.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick_1);
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "Giao diện chính";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7,
            this.ribbonPageGroup1,
            this.ribbonPageGroup8,
            this.ribbonPageGroup2,
            this.ribbonPageGroup9});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng chính";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonPageGroup7.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup7.ImageOptions.Image")));
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiNguoiDung);
            this.ribbonPageGroup7.ItemLinks.Add(this.bbiThoat);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Người dùng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiKey);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiTaiFileKey);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiQuanLyFileKey);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Key";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.bbiNhanHieu);
            this.ribbonPageGroup8.ItemLinks.Add(this.bbiTaiFileNhanHieu);
            this.ribbonPageGroup8.ItemLinks.Add(this.bbiQuanLyFileNhanHieu);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Nhãn hiệu";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtnTinhThanhPho);
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbtTenThayThe);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Các thông tin fake";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.bbiXuLyFile);
            this.ribbonPageGroup9.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Xử lý";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "ribbonPage7";
            // 
            // bbtTenThayThe
            // 
            this.bbtTenThayThe.Caption = "Tên thay thế";
            this.bbtTenThayThe.Id = 16;
            this.bbtTenThayThe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbtTenThayThe.ImageOptions.Image")));
            this.bbtTenThayThe.Name = "bbtTenThayThe";
            this.bbtTenThayThe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbtTenThayThe_ItemClick);
            // 
            // FrmGiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 588);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.plChinh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmGiaoDienChinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giao diện chính";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmGiaoDienChinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel plChinh;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.BarButtonItem bbiNguoiDung;
        private DevExpress.XtraBars.BarButtonItem bbiKey;
        private DevExpress.XtraBars.BarButtonItem bbiTaiFileKey;
        private DevExpress.XtraBars.BarButtonItem bbiQuanLyFileKey;
        private DevExpress.XtraBars.BarButtonItem bbiNhanHieu;
        private DevExpress.XtraBars.BarButtonItem bbiTaiFileNhanHieu;
        private DevExpress.XtraBars.BarButtonItem bbiQuanLyFileNhanHieu;
        private DevExpress.XtraBars.BarButtonItem bbiXuLyFile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem bbiThoat;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem bbtnTinhThanhPho;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbtTenThayThe;
    }
}