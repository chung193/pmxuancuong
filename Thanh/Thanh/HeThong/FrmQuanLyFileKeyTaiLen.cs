using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;

namespace Thanh.HeThong
{
    public partial class FrmQuanLyFileKeyTaiLen : Form
    {
        private DataTable dtFileKey;
        private XuLyDuLieu objXldl;
        private String id;
        public FrmQuanLyFileKeyTaiLen()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
        }

        public void ThietLapTTCacControl()
        {
            //if(cheDo == 0)
            //{
            //    btnXoa.Enabled = false;
            //}
           
        }

        public void HienThiFile()
        {
            objXldl.MoKetNoi();
            dtFileKey = objXldl.LayDt("Select * from tb_filekey ");
            objXldl.DongKetNoi();
            dgvFileTaiLen.DataSource = dtFileKey;
            dgvFileTaiLen.Columns[0].HeaderText = "ID";
            dgvFileTaiLen.Columns[0].Width = 50;
            dgvFileTaiLen.Columns[1].HeaderText = "Tên File";
            dgvFileTaiLen.Columns[2].HeaderText = "Thời gian tải lên";
        }

        private void FrmQuanLyFileKeyTaiLen_Load(object sender, EventArgs e)
        {
            HienThiFile();
            ThietLapTTCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa file này không? Nếu xóa, toàn bộ các thông tin key từ file này sẽ mất theo", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_filekey Where id = " + id))
                    {
                        objXldl.ThucHienCauLenh("Delete From tb_key Where id_file = " + id);
                         MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmQuanLyFileKeyTaiLen_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + objXldl.loi, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvFileTaiLen_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvFileTaiLen.CurrentRow != null)
                {
                    int dong = dgvFileTaiLen.CurrentRow.Index;
                    id = dgvFileTaiLen.Rows[dong].Cells[0].Value.ToString();
                    btnXoa.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnXoa.Enabled = false;
            }
        }

        private void dgvFileTaiLen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
