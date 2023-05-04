using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;

namespace Thanh.HeThong
{
    public partial class FrmDialog : Form
    {
        public FrmDialog()
        {
            InitializeComponent();
        }

        private void FrmDialog_Load(object sender, EventArgs e)
        {
            dtpNgayDen.CustomFormat = "dd/MM/yyyy";
            if (!String.Equals(DungChung.Kieu,""))
            {
                txtKieu.Text = DungChung.Kieu;
            }
            if (!String.Equals(DungChung.SoMAWB, ""))
            {
                txtSoMAWB.Text = DungChung.SoMAWB;
            }
            if (!String.Equals(DungChung.ChuyenBay, ""))
            {
                txtChuyenBay.Text = DungChung.ChuyenBay;
            }
            if (!String.Equals(DungChung.NgayDen, ""))
            {
                dtpNgayDen.Text = DungChung.NgayDen;
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            DungChung.Kieu = (txtKieu.Text).ToString();
            DungChung.SoMAWB = (txtSoMAWB.Text).ToString();
            DungChung.ChuyenBay = (txtChuyenBay.Text).ToString();
            DungChung.NgayDen = (dtpNgayDen.Text).ToString();
            this.Close();
        }
    }
}
