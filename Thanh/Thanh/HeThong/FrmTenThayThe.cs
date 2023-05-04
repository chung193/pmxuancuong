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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Thanh.HeThong
{
    public partial class FrmTenThayThe : Form
    {
        private DataTable dtTenThayThe;
        private String DuongDanFile;
        private XuLyDuLieu objXldl;
        private int cheDo;
        private String id;
        public FrmTenThayThe()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
            //cboQuyen.SelectedIndex = 0;
            cheDo = 0;
        }
        void ThietLapTTCacControl()
        {
            if (cheDo == 0)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtTenloi.ReadOnly = true;
                txtTenThayThe.ReadOnly = true;
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
                txtTenloi.ReadOnly = false;
                txtTenThayThe.ReadOnly = false;
            }
        }

        public void HienThi()
        {
            objXldl.MoKetNoi();
            dtTenThayThe = objXldl.LayDt("Select  * " +
                " From tb_tenthaythe");
            objXldl.DongKetNoi();
            dgvNguoiDung.DataSource = dtTenThayThe;

            dgvNguoiDung.Columns[0].HeaderText = "ID";
            dgvNguoiDung.Columns[0].Width = 40;
            dgvNguoiDung.Columns[1].HeaderText = "name";
            dgvNguoiDung.Columns[2].HeaderText = "replace";
            dgvNguoiDung.Columns[2].Width = 40;

            txtTenloi.DataBindings.Clear();
            txtTenThayThe.DataBindings.Clear();

            txtTenThayThe.DataBindings.Add("text", dtTenThayThe, "name", false, DataSourceUpdateMode.Never);
            txtTenloi.DataBindings.Add("text", dtTenThayThe, "replace", false, DataSourceUpdateMode.Never);

        }
        private void FrmTenThayThe_Load(object sender, EventArgs e)
        {
            HienThi();
            ThietLapTTCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_tenthaythe Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmTenThayThe_Load(sender, e);
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            cheDo = 2;
            ThietLapTTCacControl();
            txtTenThayThe.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();
            txtTenloi.Text = "";
            txtTenThayThe.Text = "";
            // cboQuyen.SelectedIndex = 0;
            txtTenloi.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String strSql, tb;
                if (cheDo == 1)
                {
                    strSql = "Insert Into tb_tenthaythe Values(N'" + txtTenloi.Text.Trim() + "', N'" + txtTenThayThe.Text.Trim() + "')";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_tenthaythe Set name = N'" + txtTenloi.Text.Trim() + "', replace = N'" + txtTenThayThe.Text.Trim() +
                        "' Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    FrmTenThayThe_Load(sender, e);
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtTenThayThe.DefaultView.RowFilter = "name Like '%" + txtTimKiem.Text + "%'";
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

            foreach (DataRow row in dtTenThayThe.Rows)
            {
                try
                {
                    strSql = "select id from tb_tenthaythe where name = N'" + row["Name"] + "'";
                    bool check = objXldl.KiemTraTrung(strSql);
                    if (check)
                    {
                        strSql = "Insert Into tb_tenthaythe(name, replace) Values( N'" + row["Name"] + "',N'" + row["Replace"] + "')";
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
            string strSql = "TRUNCATE TABLE tb_tenthaythe";
            objXldl.ThucHienCauLenh(strSql);
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                dtTenThayThe = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvNguoiDung.DataSource = dtTenThayThe;
            }
        }
    }
}
