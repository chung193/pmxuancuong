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
    public partial class FrmNguoiDungFake : Form
    {
        private DataTable dtNguoiDungFake;
        private String DuongDanFile;
        private XuLyDuLieu objXldl;
        private int cheDo;
        private String id;
        public FrmNguoiDungFake()
        {
            objXldl = new XuLyDuLieu();
            cheDo = 0;
            InitializeComponent();
        }

        public void ThietLapTTCacControl()
        {
            if (cheDo == 0)
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnXoa.Enabled = true;
                txtDiaChi.ReadOnly = true;
                txtDienthoai.ReadOnly = true;
                txtTen.ReadOnly = true;
                txtVung.ReadOnly = true;
                txtThanhPho.ReadOnly = true;
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

                txtDiaChi.ReadOnly = false;
                txtDienthoai.ReadOnly = false;
                txtTen.ReadOnly = false;
                txtVung.ReadOnly = false;
                txtThanhPho.ReadOnly = false;
            }
        }

        public void HienThi()
        {
            objXldl.MoKetNoi();
            dtNguoiDungFake = objXldl.LayDt("Select  * " +
                " From tb_nguoidungfake");
            objXldl.DongKetNoi();
            dgvNguoiDung.DataSource = dtNguoiDungFake;

            dgvNguoiDung.Columns[0].HeaderText = "ID";
            dgvNguoiDung.Columns[1].HeaderText = "Tên";
            dgvNguoiDung.Columns[2].HeaderText = "Vùng";
            dgvNguoiDung.Columns[3].HeaderText = "Thành phố";
            dgvNguoiDung.Columns[4].HeaderText = "Điện thoại";
            dgvNguoiDung.Columns[5].HeaderText = "Địa chỉ";

            txtDiaChi.DataBindings.Clear();
            txtDienthoai.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtVung.DataBindings.Clear();
            txtThanhPho.DataBindings.Clear();

            txtThanhPho.DataBindings.Add("text", dtNguoiDungFake, "Receivercity", false, DataSourceUpdateMode.Never);
            txtDienthoai.DataBindings.Add("text", dtNguoiDungFake, "Telephone", false, DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("text", dtNguoiDungFake, "Name", false, DataSourceUpdateMode.Never);
            txtVung.DataBindings.Add("text", dtNguoiDungFake, "Receiverstate", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("text", dtNguoiDungFake, "Address", false, DataSourceUpdateMode.Never);
        }

        private void FrmNguoiDungFake_Load(object sender, EventArgs e)
        {
            HienThi();
            ThietLapTTCacControl();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();

            txtThanhPho.Text = "";
            txtDienthoai.Text = "";
            txtTen.Text = "";
            txtVung.Text = "";
            txtDiaChi.Text = "";

            txtTen.Focus();
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
                //MessageBox.Show(ex.Message);
                btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            cheDo = 2;
            ThietLapTTCacControl();
            txtTen.Focus();
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

            foreach (DataRow row in dtNguoiDungFake.Rows)
            {
                try
                {
                    strSql = "select id from tb_nguoidungfake where Name = N'" + row["Receiver Name"] + "'";
                    bool check = objXldl.KiemTraTrung(strSql);
                    if (check)
                    {
                        strSql = "Insert Into tb_nguoidungfake(Name,Receiverstate,Receivercity,Telephone,Address ) " +
                            "Values( N'" + row["Receiver Name"] + "',N'" + row["Receiver Province/State"] + "',N'" + row["Receiver City"] + "',N'" + row["Receiver Telephone"] + "',N'" + row["Receiver Address"] + "')";
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
            string strSql = "TRUNCATE TABLE tb_nguoidungfake";
            objXldl.ThucHienCauLenh(strSql);
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                dtNguoiDungFake = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvNguoiDung.DataSource = dtNguoiDungFake;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_nguoidungfake Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmNguoiDungFake_Load(sender, e);
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
                    strSql = "Insert Into tb_nguoidungfake Values(N'" + txtTen.Text.Trim() + "', N'" + txtVung.Text.Trim() + "', N'" + txtThanhPho.Text.Trim() + "', N'" + txtDienthoai.Text.Trim() + "', N'" + txtDiaChi.Text.Trim() + "')";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_nguoidungfake Set Name = N'" + txtTen.Text.Trim() + "', Receiverstate = N'" + txtVung.Text.Trim() + "' , Receiverstate = N'" + txtVung.Text.Trim() + "', Receivercity = N'" + txtThanhPho.Text.Trim() + "', Telephone = N'" + txtDienthoai.Text.Trim() + "', Address = N'" + txtDiaChi.Text.Trim() +
                        "' Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    FrmNguoiDungFake_Load(sender, e);
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
            dtNguoiDungFake.DefaultView.RowFilter = "Name Like '%" + txtTimKiem.Text + "%'";
        }
    }
}
