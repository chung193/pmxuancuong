using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Thanh.HeThong
{
    public partial class FrmFileKey : Form
    {
        private string DuongDanFile;
        private XuLyDuLieu objXldl;
        private DataTable dtKey;
        public FrmFileKey()
        {
            InitializeComponent();
            DuongDanFile = "";
            objXldl = new XuLyDuLieu();
        }

        private void FrmFileKey_Load(object sender, EventArgs e)
        {

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
                    if(a!= null)
                    {
                        cbSheet.Enabled = true;
                        cbSheet.Items.AddRange(a);
                    }
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                //int total  = objXldl.LenhVoHuong("SELECT COUNT(id) AS total FROM tb_key");
                // MessageBox.Show(total.ToString());
                dtKey = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile );
                dgvFileKey.DataSource = dtKey;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            String strSql;
            DateTime localDate = DateTime.Now;
            string[] a = DuongDanFile.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            strSql = "insert into tb_filekey(tenfile, thoigian) OUTPUT INSERTED.id values(N'" + a[a.Length - 1] +"', '"+ localDate +"')";
            int id = objXldl.LenhVoHuong(strSql);
            DungChung.SaoChep(DuongDanFile, DungChung.LayThuMucLamViec()+ "\\LuuTru\\"+ a[a.Length - 1]);

            foreach (DataRow row in dtKey.Rows)
            {
                try
                {
                    strSql = "select id from tb_key where convertname= N'" + row["convertname"] + "' AND  [key] = N'" + row["key"] + "' AND material = N'"+ row["material"]  + "' AND classifytype = N'" + row["classifytype"]  + "' AND classify = N'" + row["classify"]  +"'";
                    if (objXldl.KiemTraTrung(strSql))
                    {
                        if (!string.IsNullOrEmpty(row["key"].ToString()))
                        {
                            strSql = "Insert Into tb_key(id_file, materialcall, brand, convertname, unit, [key], material, classifytype, classify) Values(" + id + ",   N'" + row["materialcall"] + "',   N'" + row["brand"] + "', N'" + row["convertname"] + "',N'" + row["unit"] + "', N'" + row["key"] + "', N'" +
                        row["material"] + "', N'" + row["classifytype"] + "', N'" + row["classify"] + "')";

                            if (objXldl.ThucHienCauLenh(strSql))
                            {
                                i++;
                            }
                            else
                            {
                                j++;
                            }
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

        private void btnTruncate_Click(object sender, EventArgs e)
        {
            string strSql = "TRUNCATE TABLE tb_key";
            objXldl.ThucHienCauLenh(strSql);
            strSql = "TRUNCATE TABLE tb_filekey";
            objXldl.ThucHienCauLenh(strSql);
            //dtKey = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
            // dgvFileKey.DataSource = dtKey;
        }

        private void dgvFileKey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
