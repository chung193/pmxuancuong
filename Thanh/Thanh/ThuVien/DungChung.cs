
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thanh.ThuVien
{


    public static class DungChung
    {
        public static System.Data.DataTable dtNguoidung;
        public static string fileXuLyChinh;
        public static string configPath = "./config.txt";

        public static string Kieu;
        public static string SoMAWB;
        public static string ChuyenBay;
        public static string NgayDen;

        // ==================================================================================
        /// <summary>
        /// Các public method
        /// </summary>
        /// <returns></returns>
        public static string[] DocFile()
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(configPath);
                return lines;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return lines = null;
            }
        }

        public static void VietFile(string[] data)
        {
            if (File.Exists(configPath))
            {
                // Read file using StreamReader. Reads file line by line  
                using (StreamWriter file = new StreamWriter(configPath))
                {
                    foreach (string line in data)
                    {
                        file.WriteLine(line);
                    }
                    file.Close();
                }
            }
        }

        public static DateTime randomDate()
        {
            string MonthLabel = DateTime.Now.Month.ToString();
            string YearLabel = DateTime.Now.Year.ToString();
            Random gen = new Random();
            DateTime start = new DateTime(1988, 1, 1);
            DateTime end = new DateTime(Int32.Parse(YearLabel)-16, Int32.Parse(MonthLabel), 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        } 

        public static string RandomItemInArray(string temp)
        {
            string[] result;
            if (temp.Contains(";"))
            {
                result = temp.Split(';');
                Random rd = new Random();
                int ran = rd.Next(0, result.Length);
                return result[ran];
            }
            else
            {
                return temp;
            }
        }

        public static int TimKiemKey(string TenSP, System.Data.DataTable dtKey)
        {
            string tb = "";
            try
            {
                int max = 0, index = -1;
                for (int i = 0; i < dtKey.Rows.Count; i++)
                {
                    string tam = dtKey.Rows[i]["key"].ToString().ToLower();
                    TenSP = TenSP.ToLower();
                    string[] temp = tam.Split(new string[] { "..." }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp.All(TenSP.Contains))
                    {
                        if(max == 0)
                        {
                            max = tam.Length;
                            index = i;
                        }
                        else
                        {
                            if(max < tam.Length)
                            {
                                max = tam.Length;
                                index = i;
                            }
                        }
                    }
                }
                return index;
            }
            catch (Exception exc)
            {
                /// MessageBox.Show(exc.Message);
                return -1;
            }
        }

        public static List<int> TimKiemNhanHieu(string TenSP, System.Data.DataTable dtNhanHieu)
        {
            string tb = "";
            int i = 0;
            List<int> result = new List<int>();
            try
            {
                for (i = 0; i < dtNhanHieu.Rows.Count; i++)
                {
                    string tam = dtNhanHieu.Rows[i]["tennhanhieu"].ToString().ToLower();
                    TenSP = TenSP.Replace(" ", "").ToLower();
                    string[] temp = TenSP.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                    //MessageBox.Show(temp.Length.ToString());
                    //break;
                    if (temp.Contains(tam))
                    {
                        result.Add(i);
                    }
                }
            }
            catch (Exception exc)
            {
                return result;
            }
            return result;
        }

        // public delegate void myEvent(string s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheetname"></param>
        /// <param name="filePath"></param>
        /// <returns>Lấy dữ liệu từ file Exel với tên sheet truyền vào</returns>
        public static System.Data.DataTable LayDL(string sheetname, string filePath, bool hasHeader = true)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
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
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }

        public static string LayThuMucLamViec()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string currenFolder = Directory.GetParent(workingDirectory).Parent.FullName;
            return currenFolder;
        }
        public static void SaoChep(string sourceFile, string destinationFile)
        {
            try
            {
                //MessageBox.Show(sourceFile);
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message);
            }
        }

        // move file
        public static void DiChuyen(string path, string path2)
        {
            try
            {
                File.Move(path, path2);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi xử lý lưu file  " + e.ToString());
            }
        }


        // lấy date theo định dạng
        public static string getDate()
        {
            string str = DateTime.Now.Date.ToString();
            string[] strArr = str.Split('/');
            if (int.Parse(strArr[0]) < 10)
            {
                strArr[0] = "0" + strArr[0];
            }
            return strArr[0];
        }

        public static System.Data.DataTable MakeDataTables(System.Data.DataTable dt, string[] columnNameArr)
        {
            for (int i = 0; i < columnNameArr.Length; i++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = columnNameArr[i];
                column.DataType = System.Type.GetType("System.String");
                //if (column.ColumnName == "TRỌNG LƯỢNG")
                //{
                //    column.DataType = System.Type.GetType("System.Int32)");
                //}
                //else
                //{
                //    column.DataType = System.Type.GetType("System.String");
                //}
                
                dt.Columns.Add(column);
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excelFile"></param>
        /// <returns>Lấy danh sách các sheet name</returns>
        public static String[] LaySheet(string excelFile)
        {

            FileInfo fileInfo = new FileInfo(excelFile);
            var excel = new ExcelPackage(fileInfo);
            List<string> list = new List<string>();
            foreach (var worksheet in excel.Workbook.Worksheets)
            {
                list.Add(worksheet.Name);
            }

            return list.ToArray();
        }
    }
}
   
