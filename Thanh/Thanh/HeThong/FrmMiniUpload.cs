using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;

namespace Thanh.HeThong
{
    public partial class FrmMiniUpload : Form
    {
        private string filename;
        public FrmMiniUpload()
        {
            InitializeComponent();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    txtTenFile.Text = ofd.FileName;
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
                DungChung.fileXuLyChinh = filename;
                this.Close();
        }
    }
}
