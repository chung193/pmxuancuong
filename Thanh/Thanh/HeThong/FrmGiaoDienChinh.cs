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

        private void FrmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            String quyen =  DungChung.dtNguoidung.Rows[0][2].ToString();
            //MessageBox.Show(quyen);
            if(quyen != "Quản trị viên")
            {
            }
        }

        private void panelThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void panelNguoiDung_Click(object sender, EventArgs e)
        {
            loadForm(new frmQuanTriNguoiDung());
        }


        private void panelUploadKey_Click(object sender, EventArgs e)
        {
            loadForm(new FrmFileKey());
        }

        private void panelQLKey_Click(object sender, EventArgs e)
        {
           
            loadForm(new FrmQuanLyFileKey());
        }

        private void panelQLFileKey_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyFileKeyTaiLen());
        }

        private void panelUploadFile_Click(object sender, EventArgs e)
        {
            loadForm(new FrmFileNhanHieu());
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {
            loadForm(new FrmNhanHieu());
        }

        private void panelNhanHieu_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyNhanHieu());
        }

        private void panelNguoiDungFake_Click(object sender, EventArgs e)
        {
            loadForm(new FrmNguoiDungFake());
        }

        private void panelThanhPho_Click(object sender, EventArgs e)
        {
            loadForm(new frmThanhPho());
        }

        private void panelTenThayThe_Click(object sender, EventArgs e)
        {
            loadForm(new FrmTenThayThe());
        }

        private void panelDichLoc_Click(object sender, EventArgs e)
        {
            loadForm(new FrmXuLyChinh());
        }

        private void panelXuLy_Click(object sender, EventArgs e)
        {
            loadForm(new FrmXuLyMoRong());
        }
    }
}
