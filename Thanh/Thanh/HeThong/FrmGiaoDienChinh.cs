using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;

namespace Thanh.HeThong
{
    public partial class FrmGiaoDienChinh : Form
    {
        //frmQuanTriNguoiDung frmQuanTriNguoiDung;
        public FrmGiaoDienChinh()
        {
            InitializeComponent();
            //frmQuanTriNguoiDung = new frmQuanTriNguoiDung();
            
        }

        public void loadForm(object form)
        {
            if(this.plChinh.Controls.Count > 0)
            {
                this.plChinh.Controls.RemoveAt(0);
            }
            Form f  = form as Form;
            f.TopLevel= false;
            f.Dock= DockStyle.Fill;
            this.plChinh.Controls.Add(f);
            this.plChinh.Tag = f;
            f.Show();
        }

        private void tsmQuanTriNguoiDung_Click(object sender, EventArgs e)
        {
            // flpChinh.Controls.Add(frmQuanTriNguoiDung);
            loadForm(new frmQuanTriNguoiDung());
        }

        private void FrmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            String quyen =  DungChung.dtNguoidung.Rows[0][2].ToString();
            //MessageBox.Show(quyen);
            if(quyen != "Quản trị viên")
            {
            }
        }

        private void tsmDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmTaiLenFileTuKhoa_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyFileKey());
        }

        private void tsmFileKey_Click(object sender, EventArgs e)
        {
            loadForm(new FrmFileKey());
        }

        private void danhSáchFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyFileKeyTaiLen());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            loadForm(new FrmNhanHieu());
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyNhanHieu());
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            loadForm(new FrmFileNhanHieu());
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            loadForm(new FrmXuLyChinh());
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new frmQuanTriNguoiDung());
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            loadForm(new FrmQuanLyFileKey());
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmFileKey());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmQuanLyFileKeyTaiLen());
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            loadForm(new FrmQuanLyNhanHieu());
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmNhanHieu());
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // loadForm(new FrmQuanLyNhanHieu());
           
            loadForm(new FrmFileNhanHieu());
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmXuLyChinh());
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmXuLyMoRong());
        }

        private void bbtnTinhThanhPho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new frmThanhPho());
        }

        private void barButtonItem4_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmNguoiDungFake());
        }

        private void bbtTenThayThe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadForm(new FrmTenThayThe());
        }
    }
}
