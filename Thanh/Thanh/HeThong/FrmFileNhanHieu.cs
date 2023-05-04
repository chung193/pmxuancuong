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
    public partial class FrmFileNhanHieu : Form
    {
        private DataTable dtFileKey;
        private XuLyDuLieu objXldl;
        private int cheDo;
        private String id;
        public FrmFileNhanHieu()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
            cheDo = 0;
        }

        public void ThietLapTTCacControl()
        {
            if (cheDo == 0)
            {
                btnXoa.Enabled = true;
            }
            else
            {
                btnXoa.Enabled = false;
            }
        }

        public void HienThiFile()
        {
            objXldl.MoKetNoi();
            dtFileKey = objXldl.LayDt("Select * from tb_filenhanhieu ");
            objXldl.DongKetNoi();
            dgvFileTaiLen.DataSource = dtFileKey;
            dgvFileTaiLen.Columns[0].HeaderText = "ID";
            dgvFileTaiLen.Columns[0].Width = 50;
            dgvFileTaiLen.Columns[1].HeaderText = "Tên File";
            dgvFileTaiLen.Columns[2].HeaderText = "Thời gian tải lên";
        }

        private void FrmFileNhanHieu_Load(object sender, EventArgs e)
        {
            
            HienThiFile();
            ThietLapTTCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa file này không? Nếu xóa, toàn bộ các thông tin nhãn hiệu từ file này sẽ mất theo", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_filenhanhieu Where id = " + id))
                    {
                        objXldl.ThucHienCauLenh("Delete From tb_filenhanhieu Where id_file = " + id);
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmFileNhanHieu_Load(sender, e);
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
                //if (Int32.Parse(id) == 0)
                //{
                //    btnXoa.Enabled = false;
                //}
                if (dgvFileTaiLen.CurrentRow != null)
                {
                    cheDo = 0;
                    ThietLapTTCacControl();
                    int dong = dgvFileTaiLen.CurrentRow.Index;
                    id = dgvFileTaiLen.Rows[dong].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                btnXoa.Enabled = false;
            }
        }
    }

}
