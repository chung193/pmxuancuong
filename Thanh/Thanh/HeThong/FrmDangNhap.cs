using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.HeThong;
using Thanh.ThuVien;
namespace Thanh
{
    public partial class FrmDangNhap : Form
    {
        private XuLyDuLieu objXldl;
        private DataTable dtNguoiDung;
        private FrmGiaoDienChinh frmGiaoDienChinh;
        public FrmDangNhap()
        {
            InitializeComponent();
            dtNguoiDung = null;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            objXldl = new XuLyDuLieu();
            bool test = objXldl.MoKetNoi();
            if (test)
            {
                dtNguoiDung = objXldl.LayDt("select id, hoten, case quyen when 0 then N'Người dùng' when 1 then N'Quản trị viên' end as quyen from  tb_nguoidung where tendangnhap = '" + tbTenDangNhap.Text + "' and matkhau = '" + tbMatKhau.Text + "'");
                objXldl.DongKetNoi();
                if (dtNguoiDung.Rows.Count > 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DungChung.dtNguoidung = dtNguoiDung;
                    this.Hide();
                    frmGiaoDienChinh = new FrmGiaoDienChinh();
                    frmGiaoDienChinh.Closed += (s, args) => this.Close();
                    frmGiaoDienChinh.Show(); 
                }
                else
                {
                    dtNguoiDung = null;
                    MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Kiểm tra lại kết nối và thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            FrmKetNoi frm = new FrmKetNoi();
            frm.FormClosed += new FormClosedEventHandler(Form_Closed);
            frm.Show();
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            objXldl = new XuLyDuLieu();
            if (objXldl.MoKetNoi())
            {
                lbTrangThai.ForeColor = Color.Green;
            }
            else
            {
                lbTrangThai.ForeColor = Color.Red;
                // MessageBox.Show(objXldl.loi);
            }
            
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            objXldl = new XuLyDuLieu();
            if (objXldl.MoKetNoi())
            {
                lbTrangThai.ForeColor = Color.Green;
            }
            else
            {
                lbTrangThai.ForeColor = Color.Red;
            }
        }
    }
}
