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
    public partial class FrmKetNoi : Form
    {
        public FrmKetNoi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] temp = { txtHost.Text, txtTenDangNhap.Text, txtMatKhau.Text};
            DungChung.VietFile(temp);
            XuLyDuLieu xldl = new XuLyDuLieu();
            this.Close();
        }

        private void FrmKetNoi_Load(object sender, EventArgs e)
        {
            string[] arr = DungChung.DocFile();
            txtHost.Text = arr[0];
            txtTenDangNhap.Text = arr[1];
            txtMatKhau.Text = arr[2];
        }
    }
}
