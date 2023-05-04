using Microsoft.Office.Interop.Excel;
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
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;

namespace Thanh.HeThong
{
    public partial class FrmXuLyChinh : Form
    {

        #region var
        private System.Data.DataTable dt, dtKey, dtBrand, dtBKOLA;
        private XuLyDuLieu objXldl;
        #endregion
        public FrmXuLyChinh()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
        }

        /// <summary>
        /// load dgv
        /// </summary>
        private void LoadDgv()
        {
            cbSheet.Text = "";
            cbSheet.Items.Clear();
           
            if(DungChung.fileXuLyChinh != "")
            {
                string[] a = DungChung.LaySheet(DungChung.fileXuLyChinh);
                if(a!= null)
                {
                    cbSheet.Enabled = true;
                    cbSheet.Items.AddRange(a);
                }
            }
        }

        /// <summary>
        /// form chọn file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //FrmMiniUpload frm = new FrmMiniUpload();
            //frm.FormClosed += frm_FormClosed;
            //frm.Show();

            cbSheet.Items.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtTenFile.Text = ofd.FileName;
                    DungChung.fileXuLyChinh = ofd.FileName;
                    String[] a = DungChung.LaySheet(DungChung.fileXuLyChinh);

                    if (a != null)
                    {
                        cbSheet.Enabled = true;
                        cbSheet.Items.AddRange(a);
                    }
                }
            }
        }

        /// <summary>
        ///  sự kiện khi close form chọn file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void frm_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    txtTenFile.Text = DungChung.fileXuLyChinh;
        //    LoadDgv();
        //}

        /// <summary>
        /// dialog chọn file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
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
                
                obj.WriteDataTableToExcel(dt, "Dữ liệu", filePath , "Details");

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex )
            {
                //MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmXuLyChinh_Load(object sender, EventArgs e)
        { }

        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                // loop through each row and add values to our sheet
                int rowcount = 1;


                foreach (DataRow datarow in dataTable.Rows)
                {
                    rowcount += 1;
                    progressBar1.Visible = true;
                    processBar(0, dataTable.Rows.Count, rowcount);
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {
                        // on the first iteration we add the column headers
                        if (rowcount == 4)
                        {
                            excelSheet.Cells[4, i] = dataTable.Columns[i - 1].ColumnName;
                            excelSheet.Cells[4, i].Font.Color = System.Drawing.Color.Black;
                            excelSheet.Cells[4, i].Font.Bold = true;
                        }
                        if (rowcount > 4)
                        {
                            excelSheet.Cells[rowcount, i].NumberFormat = "@";
                            excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                        }
                    }
                }
                progressBar1.Visible = false;

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[4, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                excelCellrange.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;


                excelCellrange = excelSheet.Range[excelSheet.Cells[4, 1], excelSheet.Cells[5, dataTable.Columns.Count]];
                // FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);


                //now save the workbook and exit Excel


                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }
        /// <summary>
        /// dialog lưu file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
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
                
                WriteDataTableToExcel(dt, "Dữ liệu", filePath);

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        

        /// <summary>
        /// chọn sheet trong combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbSheet.SelectedItem.ToString() != "")
                {
                    string sheetName = cbSheet.SelectedItem.ToString();
                    // xử lý
                    // labelProcess.Text= "Sheet " + sheetName + " đang được xử lý";
                    
                    System.Data.DataTable dt = RenderData(sheetName);
                    dgvXuLy.DataSource = dt; 

                    //this.Invoke(new System.Action(() => {
                    //    // code của bạn
                    //    Thread t = new Thread(() => {
                    //        RenderData(sheetName);
                    //    });
                    //    t.IsBackground = true;
                    //    t.Start();
                    //}));
                 
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void processBar(int min, int max, int value)
        {
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
            progressBar1.Value = value;
           // labelProcess.Text = value.ToString() + "/ " + max.ToString();
        }

        private System.Data.DataTable RenderData(string sheetName)
        {
            dt = DungChung.LayDL(sheetName, DungChung.fileXuLyChinh);
            dtKey = objXldl.LayDt("select * from tb_key");
            dtBrand = objXldl.LayDt("select * from tb_nhanhieu");
            Random random = new Random();
            // xử lý lấy key
            dt.Columns.Add("Đầu ra");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
               // progressBar1.Visible = true;
                //processBar(0, dt.Rows.Count, i);
                int j = DungChung.TimKiemKey(dt.Rows[i]["ProductName1"].ToString(), dtKey);
                if (j != -1)
                {
                    // MessageBox.Show(j.ToString());
                    dt.Rows[i]["Đầu ra"] = DungChung.RandomItemInArray(dtKey.Rows[j]["unit"].ToString()) + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["convertname"].ToString()) ;
                    if (dtKey.Rows[j]["materialcall"].ToString() != "" || dtKey.Rows[j]["material"].ToString() != "")
                    {
                        string x = "";
                        if (dtKey.Rows[j]["materialcall"].ToString() != "")
                        {
                            x += ",  " + DungChung.RandomItemInArray(dtKey.Rows[j]["materialcall"].ToString());
                        }

                        if (dtKey.Rows[j]["material"].ToString() != "")
                        {
                            x += " " + DungChung.RandomItemInArray(dtKey.Rows[j]["material"].ToString()) + ",";
                        }

                        dt.Rows[i]["Đầu ra"] += x;
                    }
                    dt.Rows[i]["Đầu ra"] += " " + dtKey.Rows[j]["classifytype"].ToString() + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["classify"].ToString());
                    List<int> nhanhieu;
                    if (dt.Rows[i]["DeclaredName1"].ToString() != "")
                    {
                        nhanhieu = DungChung.TimKiemNhanHieu(dt.Rows[i]["DeclaredName1"].ToString(), dtBrand);
                    }
                    else
                    {
                        nhanhieu = DungChung.TimKiemNhanHieu(dtKey.Rows[i]["brand"].ToString(), dtBrand);
                    }
                    int y = 0;

                    DataColumnCollection columns = dt.Columns;
                    string temp = "";
                    foreach (var nh in nhanhieu)
                    {
                        // MessageBox.Show(nh.ToString());
                        if (y == 0)
                        {

                            //MessageBox.Show((dtBrand.Rows[nh]["nhom1"].ToString()));
                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) < 500000)
                            {
                                temp += dtBrand.Rows[nh]["nhom1"].ToString();
                            }
                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) > 500000 & Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) < 1000000)
                            {
                                temp += dtBrand.Rows[nh]["nhom2"].ToString();
                            }

                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) > 1000000)
                            {
                                temp += dtBrand.Rows[nh]["nhom3"].ToString();
                            }
                        }
                        else
                        {

                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) < 500000)
                            {
                                temp += dtBrand.Rows[nh]["nhom1"].ToString();
                            }
                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) > 500000 & Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) < 1000000)
                            {
                                temp += dtBrand.Rows[nh]["nhom2"].ToString();
                            }

                            if (Double.Parse(dt.Rows[i]["DeclaredValue1"].ToString()) > 1000000)
                            {
                                temp += dtBrand.Rows[nh]["nhom3"].ToString();
                            }
                        }
                        y++;
                    }
                    string[] arrtemp = temp.Split(';');

                    int start = random.Next(0, arrtemp.Length);
                    arrtemp[start] = ", NCC " + arrtemp[start];
                    dt.Rows[i]["Đầu ra"] += arrtemp[start];
                }
                else
                {
                    dt.Rows[i]["Đầu ra"] = "";
                }

            }
            // xử lý với branch
            //progressBar1.Visible = false;
            //
            return dt;
        }
    }
}
