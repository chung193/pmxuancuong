using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thanh.ThuVien;

namespace Thanh.HeThong
{
    public partial class FrmQuanLyKey : Form
    {
        private XuLyDuLieu objXldl;
        private DataTable dtKey;
        private int cheDo;
        private String id;
        public FrmQuanLyKey()
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
                txtUnit.ReadOnly = true;
                txtKey.ReadOnly = true;
                txtMaterial.ReadOnly = true;
                txtClassify.ReadOnly = true;
                txtClassifyType.ReadOnly = true;
                txtConvertname.ReadOnly = true;
                txtBrand.ReadOnly = true;
                txtMaterialcall.ReadOnly = true;

                if (dgvKey.Rows.Count < 1)
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
                txtUnit.ReadOnly = false;
                txtKey.ReadOnly = false;
                txtMaterial.ReadOnly = false;
                txtClassify.ReadOnly = false;
                txtClassifyType.ReadOnly = false;
                txtConvertname.ReadOnly = false;
                txtMaterialcall.ReadOnly = false;
                txtBrand.ReadOnly = false;
            }
        }

        public async Task HienThiFileKey()
        {
            objXldl.MoKetNoi();
            dtKey = objXldl.LayDt("Select id, [key], convertname, unit, classify, classifytype, material, materialcall, brand From tb_key");
            objXldl.DongKetNoi();
            dgvKey.DataSource = dtKey;

            dgvKey.Columns[0].HeaderText = "ID";
            dgvKey.Columns[0].Width = 50;
            dgvKey.Columns[1].HeaderText = "Key";
            dgvKey.Columns[2].HeaderText = "Convertname";
            dgvKey.Columns[2].Width = 200;
            dgvKey.Columns[3].HeaderText = "Unit";
            dgvKey.Columns[3].Width = 120;
            dgvKey.Columns[4].HeaderText = "Classify Type";
            dgvKey.Columns[5].HeaderText = "Classify";
            dgvKey.Columns[5].Width = 120;
            dgvKey.Columns[6].HeaderText = "MaterialCall";
            dgvKey.Columns[6].Width = 120;
            dgvKey.Columns[7].HeaderText = "Material";
            dgvKey.Columns[7].Width = 120;
            dgvKey.Columns[8].HeaderText = "Brand";
            dgvKey.Columns[8].Width = 200;

            txtUnit.DataBindings.Clear();
            txtKey.DataBindings.Clear();
            txtMaterial.DataBindings.Clear();
            txtClassify.DataBindings.Clear();
            txtClassifyType.DataBindings.Clear();
            txtConvertname.DataBindings.Clear();
            txtMaterialcall.DataBindings.Clear();
            txtBrand.DataBindings.Clear();

            txtUnit.DataBindings.Add("text", dtKey, "unit", false, DataSourceUpdateMode.Never);
            txtKey.DataBindings.Add("text", dtKey, "key", false, DataSourceUpdateMode.Never);
            txtMaterial.DataBindings.Add("text", dtKey, "material", false, DataSourceUpdateMode.Never);
            txtClassify.DataBindings.Add("text", dtKey, "classify", false, DataSourceUpdateMode.Never);
            txtClassifyType.DataBindings.Add("text", dtKey, "classifytype", false, DataSourceUpdateMode.Never);
            txtConvertname.DataBindings.Add("text", dtKey, "convertname", false, DataSourceUpdateMode.Never);
            txtMaterialcall.DataBindings.Add("text", dtKey, "materialcall", false, DataSourceUpdateMode.Never);
            txtBrand.DataBindings.Add("text", dtKey, "brand", false, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = 1;
            ThietLapTTCacControl();
            txtUnit.Text = "";
            txtKey.Text = "";
            txtMaterial.Text = "";
            txtClassify.Text = "";
            txtClassifyType.Text = "";
            txtConvertname.Text = "";
            txtMaterialcall.Text = "";
            GP.Text = "";
            txtUnit.Focus();
        }

        private async void FrmQuanLyFileKey_Load(object sender, EventArgs e)
        {

            //HienThiFileKey();
            //Thread getDataThread = new Thread(new ThreadStart(ThietLapTTCacControl));
            //Thread getTotalThread = new Thread(new ThreadStart(LayTong));

            //getDataThread.IsBackground = true;
            //getTotalThread.IsBackground = true;
            //getDataThread.Start();
            //getTotalThread.Start();
            //ThietLapTTCacControl();
            //LayTong();

            await HienThiFileKey();
            await LayTong();
            ThietLapTTCacControl();
        }

        

        private async Task LayTong()
        {
            String strSql = "SELECT count(id) as total  FROM tb_key";
            XuLyDuLieu XLDL = new XuLyDuLieu();
            int total = XLDL.LenhVoHuong(strSql);
            txtTotal.Text = total.ToString();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                String strSql, tb;
                if (cheDo == 1)
                {
                    strSql = "Insert Into tb_key (brand, materialcall, unit, [key], convertname, material, classify, classifytype) Values('" + GP.Text.Trim() + "','" + txtMaterialcall.Text.Trim() + "','" + txtUnit.Text.Trim() + "', '" + txtKey.Text.Trim() + "',  '" + txtConvertname.Text.Trim() + "', N'" +
                        txtMaterial.Text.Trim() + "', '" + txtClassifyType.Text.Trim() + "', '" + txtClassify.Text.Trim() + "')";
                    tb = "Thêm thành công";
                }
                else
                {
                    strSql = "Update tb_key Set brand='" + GP.Text.Trim() + "', materialcall= '" + txtMaterialcall.Text.Trim() + "' ,unit = N'" + txtUnit.Text.Trim() + "', convertname = N'" + txtConvertname.Text.Trim() + "', [key] = N'" + txtKey.Text.Trim() +
                        "', material = N'" + txtMaterial.Text.Trim() + "', classifytype = N'" + txtClassifyType.Text.Trim() + "', classify = N'" + txtClassify.Text.Trim() +  "' Where id = " + id;
                    tb = "Sửa thành công";
                }
                if (objXldl.ThucHienCauLenh(strSql))
                {
                    MessageBox.Show(tb, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cheDo = 0;
                    FrmQuanLyFileKey_Load(sender, e);
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
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa key này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (objXldl.ThucHienCauLenh("Delete From tb_key Where id = " + id))
                    {
                        MessageBox.Show("Đã xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmQuanLyFileKey_Load(sender, e);
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
            txtUnit.Focus();
        }

        private void dgvKey_SelectionChanged(object sender, EventArgs e)
        {
            cheDo = 0;
            ThietLapTTCacControl();
            try
            {
                if (dgvKey.CurrentRow != null)
                {
                    int dong = dgvKey.CurrentRow.Index;
                    id = dgvKey.Rows[dong].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                btnSua.Enabled = btnXoa.Enabled = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dtKey.DefaultView.RowFilter = "convertname Like '%" + txtTimKiem.Text + "%'";
        }

        private void dgvKey_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            try
            {
                CongCuExcel obj = new CongCuExcel();
                obj.WriteDataTableToExcel(dtKey, "Dữ liệu", filePath, "Details");

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GP_Enter(object sender, EventArgs e)
        {

        }
    }
}
