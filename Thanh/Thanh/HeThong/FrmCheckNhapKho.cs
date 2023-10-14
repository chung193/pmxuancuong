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
    public partial class FrmCheckNhapKho : Form
    {
        private XuLyDuLieu objXldl;
        private string _idfile = "";
        public FrmCheckNhapKho()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
        }

        public void loadCb()
        {
            cbFile.Text = "";
            cbFile.Items.Clear();
            string sql = "select * from tb_fileluong";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objXldl.LayDt(sql);
            if (dt != null)
            {
                cbFile.Enabled = true;
                cbFile.DataSource = dt;
                cbFile.DisplayMember = "tenfile";
                cbFile.ValueMember = "id";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmCheckNhapKho_Load(object sender, EventArgs e)
        {
            loadCb();
        }

        private void cbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            _idfile = cbFile.SelectedValue.ToString();
            decimal decValue;

            if (decimal.TryParse(_idfile, out decValue)){
                string sql = "select name, datetime from tb_check where idfile = " + _idfile;
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = objXldl.LayDt(sql);
                dgvData.DataSource = dt;
            }
            else
            { }
            
        }
    }
}
