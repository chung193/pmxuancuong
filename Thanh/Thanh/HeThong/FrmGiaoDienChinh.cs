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
            String quyen = DungChung.dtNguoidung.Rows[0][2].ToString();
            if (quyen == "Người dùng")
            {
                tabFakeData.Visible = false;
                tabKey.Visible = false;
                tabNhanHieu.Visible = false;
                tabNguoiDung.Visible = false;
            }
            else
            {
                
            }
        }

        private void btnNguoiDung_Click(object sender, EventArgs e)
        {
            loadForm(new frmQuanTriNguoiDung());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyKey());
        }

        private void btnFileKey_Click(object sender, EventArgs e)
        {
            loadForm(new FrmTaiLenFileKey());
        }

        private void btnTaiLenFileKey_Click(object sender, EventArgs e)
        {
            
            loadForm(new FrmFileKey());
        }

        private void btnNhanHieu_Click(object sender, EventArgs e)
        {
            loadForm(new FrmQuanLyNhanHieu());
           
        }

        private void btnFileNhanHieu_Click(object sender, EventArgs e)
        {
            loadForm(new FrmFileNhanHieu());
        }

        private void btnTaiLenFileNhanHieu_Click(object sender, EventArgs e)
        {
            loadForm(new FrmNhanHieu());
        }

        private void btnNguoiDungFake_Click(object sender, EventArgs e)
        {
            loadForm(new FrmNguoiDungFake());
        }

        private void btnThanhPho_Click(object sender, EventArgs e)
        {
            loadForm(new frmThanhPho());
        }

        private void btnTenThayThe_Click(object sender, EventArgs e)
        {
            loadForm(new FrmTenThayThe());
        }

        private void btnDichLoc_Click(object sender, EventArgs e)
        {
            loadForm(new FrmXuLyChinh());
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            loadForm(new FrmXuLyMoRong());
        }
    }
}
