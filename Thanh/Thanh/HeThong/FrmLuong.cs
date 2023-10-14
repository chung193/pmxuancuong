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
using System.IO;

namespace Thanh.HeThong
{
    public partial class FrmLuong : Form
    {
        private DataTable dtNhanHieu;
        private XuLyDuLieu objXldl;
        private String DuongDanFile;
        public FrmLuong()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
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

        public static System.Data.DataTable LayDL(string sheetname, string filePath, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets[sheetname];
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                        tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var modelTable1 = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    if (modelTable1.Style.Border.Right.Style == OfficeOpenXml.Style.ExcelBorderStyle.None)
                        break;

                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        if (string.IsNullOrEmpty(cell.Text))
                        {
                            break;
                        }
                        else
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }
                }
                return tbl;
            }
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                dtNhanHieu = LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvNhanHieu.DataSource = dtNhanHieu;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            int i = 0, j = 0;
            String strSql;
            string localDate = DateTime.Now.ToString("MM/dd/yyyy HH: mm");

            string[] a = DuongDanFile.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            strSql = "insert into tb_fileluong(tenfile, ngayupload) OUTPUT INSERTED.id values(N'" + a[a.Length - 1] + "', '" + localDate + "')";
            int id = objXldl.LenhVoHuong(strSql);
            string currentDateStr = DateTime.Now.ToString("MM/dd/yyyy");
            string currentTimeStr = DateTime.Now.ToString("HH:mm:ss");
            foreach (DataRow row in dtNhanHieu.Rows)
            {
                try
                {                   
                    if (true)
                    {

                        strSql = "Insert Into tb_luong(mafile, mawb, sovandon, sothung, phanluong, date, time) Values(" + id + ", N'" + row["MAWB"] + "', N'" + row["SỐ VẬN ĐƠN"] + "', N'" +
                        row["SỐ THÙNG"] + "', N'" + row["PHÂN LUỒNG"] + "', N'" + currentDateStr+ "', N'" + currentTimeStr + "')";
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
    }
}
