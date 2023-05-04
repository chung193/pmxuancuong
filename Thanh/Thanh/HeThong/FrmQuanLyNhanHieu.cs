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
    public partial class FrmQuanLyNhanHieu : Form
    {

        private XuLyDuLieu objXldl;
        private DataTable dtKey;
        private int cheDo;
        private String id;
        public FrmQuanLyNhanHieu()
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
                txtTenNhanHieu.ReadOnly = true;
                txtNhom1.ReadOnly = true;
                txtNhom2.ReadOnly = true;
                txtNhom3.ReadOnly = true;
                if (dgvNhanHieu.Rows.Count < 1)
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
                txtTenNhanHieu.ReadOnly = false;
                txtNhom1.ReadOnly = false;
                txtNhom2.ReadOnly = false;
                txtNhom3.ReadOnly = false;
            }
        }

        public void HienThiFileKey()
        {
            objXldl.MoKetNoi();
            dtKey = objXldl.LayDt("Select nh.id, nh.tennhanhieu, nh.nhom1, nh.nhom2, nh.nhom3 From tb_nhanhieu as nh");
            objXldl.DongKetNoi();
            dgvNhanHieu.DataSource = dtKey;
            dgvNhanHieu.Columns[0].HeaderText = "id";
            dgvNhanHieu.Columns[0].Width = 50;
            dgvNhanHieu.Columns[1].HeaderText = "Tên nhãn hiệu";
            dgvNhanHieu.Columns[2].HeaderText = "0-500k";
            dgvNhanHieu.Columns[3].HeaderText = "500-1000k";
            dgvNhanHieu.Columns[4].HeaderText = ">1000k";

            txtTenNhanHieu.DataBindings.Clear();
            txtNhom1.DataBindings.Clear();
            txtNhom2.DataBindings.Clear();
            txtNhom3.DataBindings.Clear();

            txtTenNhanHieu.DataBindings.Add("text", dtKey, "tennhanhieu", false, DataSourceUpdateMode.Never);
            txtNhom1.DataBindings.Add("text", dtKey, "nhom1", false, DataSourceUpdateMode.Never);
            txtNhom2.DataBindings.Add("text", dtKey, "nhom2", false, DataSourceUpdateMode.Never);
            txtNhom3.DataBindings.Add("text", dtKey, "nhom3", false, DataSourceUpdateMode.Never);
        }

        private void FrmQuanLyNhanHieu_Load(object sender, EventArgs e)
        {
            HienThiFileKey();
            ThietLapTTCacControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String strSql, tb;
                if (cheDo == 1)
                {
                    strSql = "Insert Into tb_nhanhieu (tennhanhieu, nhom1, nhom2, nhom3) Values('" + txtTenNhanHieu.Text.Trim() + "', '" + txtNhom1.Text.Trim() + "', N'" +
                        txtNhom2.Text.Trim() + "', '" + txtNhom3.Text.Trim() + "')";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_nhanhieu Set tennhanhieu = N'" + txtTenNhanHieu.Text.Trim() + "', nhom1 = N'" + txtNhom1.Text.Trim() +
                        "', nhom2 = N'" + txtNhom2.Text.Trim() + "', nhom3 = N'" + txtNhom3.Text.Trim() + "' Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    FrmQuanLyNhanHieu_Load(sender, e);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa nhãn hiệu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_nhanhieu Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmQuanLyNhanHieu_Load(sender, e);
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
            txtTenNhanHieu.Focus();
        }

        private void dgvNhanHieu_SelectionChanged(object sender, EventArgs e)
        {
            cheDo = 0;
            ThietLapTTCacControl();
            try
            {
                if (dgvNhanHieu.CurrentRow != null)
                {
                    int dong = dgvNhanHieu.CurrentRow.Index;
                    id = dgvNhanHieu.Rows[dong].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtKey.DefaultView.RowFilter = "tennhanhieu Like '%" + txtTimKiem.Text + "%'";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();
            txtTenNhanHieu.Text = "";
            txtNhom1.Text = "";
            txtNhom2.Text = "";
            txtNhom3.Text = "";
            txtTenNhanHieu.Focus();
        }
    }
}
