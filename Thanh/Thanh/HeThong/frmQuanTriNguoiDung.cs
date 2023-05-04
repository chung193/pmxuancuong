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
    public partial class frmQuanTriNguoiDung : Form
    {
        private DataTable dtNguoiDung;
        private XuLyDuLieu objXldl;
        private int cheDo;
        private String id;
        public frmQuanTriNguoiDung()
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
                txtTenDangNhap.ReadOnly = true;
                txtMatKhau.ReadOnly = true;
                txtHoTen.ReadOnly = true;
                cboQuyen.Enabled = false;
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
                txtTenDangNhap.ReadOnly = false;
                txtMatKhau.ReadOnly = false;
                txtHoTen.ReadOnly = false;
                cboQuyen.Enabled = true;
            }
        }

        public void HienThiNguoiDung()
        {
            objXldl.MoKetNoi();
            dtNguoiDung = objXldl.LayDt("Select id, tendangnhap, matkhau, hoten, Case quyen When 0 Then N'Người dùng' When 1 Then " +
                "N'Quản trị viên' End As 'quyen' From tb_nguoidung");
            objXldl.DongKetNoi();
            dgvNguoiDung.DataSource = dtNguoiDung;
            dgvNguoiDung.Columns[0].HeaderText = "ID";
            dgvNguoiDung.Columns[0].Width = 50;
            dgvNguoiDung.Columns[1].HeaderText = "Tên đăng nhập";
            dgvNguoiDung.Columns[2].HeaderText = "Mật khẩu";
            dgvNguoiDung.Columns[3].HeaderText = "Họ tên";
            dgvNguoiDung.Columns[4].HeaderText = "Quyền";
            dgvNguoiDung.Columns[4].Width = 120;

            txtTenDangNhap.DataBindings.Clear();
            txtMatKhau.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            cboQuyen.DataBindings.Clear();

            txtTenDangNhap.DataBindings.Add("text", dtNguoiDung, "tendangnhap", false, DataSourceUpdateMode.Never);
            txtMatKhau.DataBindings.Add("text", dtNguoiDung, "matkhau", false, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add("text", dtNguoiDung, "hoten", false, DataSourceUpdateMode.Never);
            cboQuyen.DataBindings.Add("text", dtNguoiDung, "quyen", false, DataSourceUpdateMode.Never);
        }

        private void frmQuanTriNguoiDung_Load(object sender, EventArgs e)
        {
            HienThiNguoiDung();
            ThietLapTTCacControl();
        }

        public bool KiemTraTenDangNhap()
        {
            bool kq = true;
            if (txtTenDangNhap.Text.Trim().Length < 6 || txtTenDangNhap.Text.Trim().Length > 50)
            {
                kq = false;
                err.SetError(txtTenDangNhap, "Tên đăng nhập chưa đúng");
            }
            else
            {
                err.SetError(txtTenDangNhap, "");
            }
            return kq;
        }

        public bool KiemTraMatKhau()
        {
            bool kq = true;
            if (txtMatKhau.Text.Trim().Length < 6 || txtMatKhau.Text.Trim().Length > 30)
            {
                kq = false;
                err.SetError(txtMatKhau, "Mật khẩu chưa đúng");
            }
            else
            {
                err.SetError(txtMatKhau, "");
            }
            return kq;
        }

        public bool KiemTraHoTen()
        {
            bool kq = true;
            if (txtHoTen.Text.Trim().Length < 1)
            {
                kq = false;
                err.SetError(txtHoTen, "Họ tên không được để trống");
            }
            else
            {
                err.SetError(txtHoTen, "");
            }
            return kq;
        }

        public bool KiemTraToanBo()
        {
            bool kq = true;
            if (cheDo != 0)
            {
                kq = KiemTraTenDangNhap() & KiemTraMatKhau() & KiemTraHoTen();
                btnLuu.Enabled = kq;
            }
            return kq;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_nguoidung Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQuanTriNguoiDung_Load(sender, e);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtHoTen.Text = "";
            // cboQuyen.SelectedIndex = 0;
            KiemTraToanBo();
            txtTenDangNhap.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String strSql, tb;
                if (cheDo == 1)
                {
                    strSql = "Insert Into tb_nguoidung Values('" + txtTenDangNhap.Text.Trim() + "', '" + txtMatKhau.Text.Trim() + "', N'" +
                        txtHoTen.Text.Trim() + "', " + cboQuyen.SelectedIndex + ")";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_nguoidung Set tendangnhap = '" + txtTenDangNhap.Text.Trim() + "', matkhau = '" + txtMatKhau.Text.Trim() +
                        "', hoten = N'" + txtHoTen.Text.Trim() + "', quyen = " + cboQuyen.SelectedIndex + " Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    frmQuanTriNguoiDung_Load(sender, e);
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_nguoidung Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmQuanTriNguoiDung_Load(sender, e);
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
            txtTenDangNhap.Focus();
        }

        private void txtTenDangNhap_TextChanged_1(object sender, EventArgs e)
        {
            KiemTraToanBo();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            KiemTraToanBo();
        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {
            KiemTraToanBo();
        }

        private void txtTimKiem_TextChanged_1(object sender, EventArgs e)
        {
            dtNguoiDung.DefaultView.RowFilter = "hoten Like '%" + txtTimKiem.Text + "%'";
        }

        private void dgvNguoiDung_SelectionChanged_1(object sender, EventArgs e)
        {
            cheDo = 0;
            ThietLapTTCacControl();
            try
            {
                if(dgvNguoiDung.CurrentRow != null)
                {
                    int dong = dgvNguoiDung.CurrentRow.Index;
                    id = dgvNguoiDung.Rows[dong].Cells[0].Value.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
