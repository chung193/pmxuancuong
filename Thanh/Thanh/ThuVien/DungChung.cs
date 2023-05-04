using DevExpress.Utils.Text;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors.SyntaxEditor;
using Microsoft.Office.Interop.Excel;
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
        public static System.Data.DataTable LayDL(string sheetname, string filePath)
        {
            string kn = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = '" + filePath + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
            using (OleDbConnection conn = new OleDbConnection(kn))
            {
                conn.Open();

                OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter("select *from [" + sheetname + "]", conn);
                System.Data.DataTable tb = new System.Data.DataTable();
                objDA.Fill(tb);
                //dgDulieuExcel.DataSource = null;
                return tb;
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
            OleDbConnection objConn = null;
            System.Data.DataTable dt = null;

            try
            {
                // Connection String. Change the excel file to the file you
                // will search.
                String connString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = '" + excelFile + "';Extended Properties=\"Excel 12.0;HDR=YES;\"";
                // Create connection object by using the preceding connection string.
                objConn = new OleDbConnection(connString);
                // Open connection with the database.
                objConn.Open();
                // Get the data table containg the schema guid.
                dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;

                // Add the sheet name to the string array.
                foreach (DataRow row in dt.Rows)
                {
                    excelSheets[i] = row["TABLE_NAME"].ToString();
                    i++;
                }

                // Loop through all of the sheets if you want too...
                for (int j = 0; j < excelSheets.Length; j++)
                {
                    // Query each excel sheet.
                    //MessageBox.Show("excel sheet");
                }

                return excelSheets;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Clean up.
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
    }
}
   
