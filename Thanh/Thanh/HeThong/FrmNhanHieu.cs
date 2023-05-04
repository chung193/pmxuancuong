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
    public partial class FrmNhanHieu : Form
    {
        private DataTable dtNhanHieu;
        private XuLyDuLieu objXldl;
        private String DuongDanFile;
        public FrmNhanHieu()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            String strSql;
            DateTime localDate = DateTime.Now;

            string[] a = DuongDanFile.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            strSql = "insert into tb_filenhanhieu(tenfile, thoigian) OUTPUT INSERTED.id values(N'" + a[a.Length - 1] + "', '" + localDate + "')";
            int id = objXldl.LenhVoHuong(strSql);
            // DungChung.SaoChep(DuongDanFile, DungChung.LayThuMucLamViec() + "\\LuuTru\\NhanHieu\\" + a[a.Length - 1]);

            foreach (DataRow row in dtNhanHieu.Rows)
            {
                try
                {
                    // strSql = "select id from tb_nhanhieu where tennhanhieu = N'" + row["tennhanhieu"] + "' AND nhom1 = N'" + row["nhom1"] + "' AND nhom2 = N'" + row["nhom2"] + "' AND nhom3 = N'" + row["nhom3"] + "'";
                    strSql = "select id from tb_nhanhieu where tennhanhieu = N'" + row["tennhanhieu"] + "'";
                    bool check = objXldl.KiemTraTrung(strSql);
                    if (check)
                    {
                        strSql = "Insert Into tb_nhanhieu(id_file, tennhanhieu, nhom1, nhom2, nhom3) Values(" + id + ", N'" + row["tennhanhieu"] + "', N'" + row["nhom1"] + "', N'" +
                        row["nhom2"] + "', N'" + row["nhom3"] + "')";
                        // MessageBox.Show(strSql);
                        if (objXldl.ThucHienCauLenh(strSql))
                        {
                            i++;
                            //MessageBox.Show(i.ToString());
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string tb;
            tb = "Thêm thành công " + i + " và " + j + " lỗi";
            MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // FrmFileKey_Load(sender, e);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            cbSheet.Items.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    txtFileName.Text = ofd.FileName;
                DuongDanFile = ofd.FileName;
                String[] a = DungChung.LaySheet(DuongDanFile);
                if (a != null)
                {
                    cbSheet.Enabled = true;
                    cbSheet.Items.AddRange(a);
                }
            }
        }

        private void dgvFileKey_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                //int total  = objXldl.LenhVoHuong("SELECT COUNT(id) AS total FROM tb_key");
                // MessageBox.Show(total.ToString());
                dtNhanHieu = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvNhanHieu.DataSource = dtNhanHieu;
            }
        }

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            string strSql = "TRUNCATE TABLE tb_nhanhieu";
            objXldl.ThucHienCauLenh(strSql);
            //dtKey = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
            // dgvFileKey.DataSource = dtKey;
        }

        private void FrmNhanHieu_Load(object sender, EventArgs e)
        {

        }
    }
}
