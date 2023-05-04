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
    public partial class frmThanhPho : Form
    {
        private DataTable dtThanhPho;
        private String DuongDanFile;
        private XuLyDuLieu objXldl;
        private int cheDo;
        private String id;
        public frmThanhPho()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
            //cboQuyen.SelectedIndex = 0;
            cheDo = 0;
        }
        public void ThietLapTTCacControl()
        {
            if (cheDo == 0)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtTinhTP.ReadOnly = true;
                txtCode.ReadOnly = true;
                if (dgvNguoiDung.Rows.Count < 1)
                {
                    btnSua.Enabled = false;
                    btnLuu.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                txtTinhTP.ReadOnly = false;
                txtCode.ReadOnly = false;
            }
        }

        public void HienThiThanhPho()
        {
            objXldl.MoKetNoi();
            dtThanhPho = objXldl.LayDt("Select  * " +
                " From tb_thanhpho");
            objXldl.DongKetNoi();
            dgvNguoiDung.DataSource = dtThanhPho;

            dgvNguoiDung.Columns[0].HeaderText = "ID";
            dgvNguoiDung.Columns[0].Width = 40;
            dgvNguoiDung.Columns[1].HeaderText = "TinhTP";
            dgvNguoiDung.Columns[2].HeaderText = "code";
            dgvNguoiDung.Columns[2].Width = 40;

            txtTinhTP.DataBindings.Clear();
            txtTinhTP.DataBindings.Clear();
            txtCode.DataBindings.Clear();

            txtTinhTP.DataBindings.Add("text", dtThanhPho, "TinhTP", false, DataSourceUpdateMode.Never);
            txtCode.DataBindings.Add("text", dtThanhPho, "code", false, DataSourceUpdateMode.Never);
  
        }

        private void frmThanhPho_Load(object sender, EventArgs e)
        {
            HienThiThanhPho();
            ThietLapTTCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_thanhpho Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmThanhPho_Load(sender, e);
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String strSql, tb;
                if (cheDo == 1)
                {
                    strSql = "Insert Into tb_thanhpho Values(N'" + txtTinhTP.Text.Trim() + "', '" + txtCode.Text.Trim() + "')";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_thanhpho Set TinhTP = N'" + txtTinhTP.Text.Trim() + "', Code = '" + txtCode.Text.Trim() +
                        "' Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    frmThanhPho_Load(sender, e);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();
            txtCode.Text = "";
            txtTinhTP.Text = "";
            // cboQuyen.SelectedIndex = 0;
            txtTinhTP.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtThanhPho.DefaultView.RowFilter = "TinhTP Like '%" + txtTimKiem.Text + "%'";
        }

        private void dgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            cheDo = 0;
            ThietLapTTCacControl();
            try
            {
                if (dgvNguoiDung.CurrentRow != null)
                {
                    int dong = dgvNguoiDung.CurrentRow.Index;
                    id = dgvNguoiDung.Rows[dong].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cheDo = 2;
            ThietLapTTCacControl();
            txtTinhTP.Focus();
        }

        private void txtTinhTP_TextChanged(object sender, EventArgs e)
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
                if (a != null)
                {
                    cbSheet.Enabled = true;
                    cbSheet.Items.AddRange(a);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            String strSql;

            foreach (DataRow row in dtThanhPho.Rows)
            {
                try
                {
                    strSql = "select id from tb_thanhpho where TinhTP = N'" + row["TinhTP"] + "'";
                    bool check = objXldl.KiemTraTrung(strSql);
                    if (check)
                    {
                        strSql = "Insert Into tb_thanhpho(TinhTP, Code) Values( N'" + row["TinhTP"] + "'," + row["Code"] + ")";
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
            string strSql = "TRUNCATE TABLE tb_thanhpho";
            objXldl.ThucHienCauLenh(strSql);
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                //int total  = objXldl.LenhVoHuong("SELECT COUNT(id) AS total FROM tb_key");
                // MessageBox.Show(total.ToString());
                dtThanhPho = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvNguoiDung.DataSource = dtThanhPho;
            }
        }
    }
}
