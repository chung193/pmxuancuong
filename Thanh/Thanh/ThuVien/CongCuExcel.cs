using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thanh.ThuVien
{
    internal class CongCuExcel
    {
        #region Init var
        public int value = 0;
        // ola
        public string title = "Công ty Cổ phần Hữu Nghị Xuân Cương";
        public string titleOla = "BẢNG KÊ HÀNG HÓA";
        public string infoTile = "MRWB:";
        public string infoContent = "HN-CM140123-01:";
        public string endFile = "Lạng Sơn, Ngày 14 tháng 01 năm 2023";
        public string bussiness = "Đại diện doanh nghiệp";
        public string sign = "(Kí, ghi rõ họ & tên)";
        // cms

        // mic
        #endregion


        public bool checkType(string StrType)
        {
            if (string.IsNullOrEmpty(StrType)) return false;
            else if(StrType == "ola" || StrType == "cms" || StrType == "mic") return false;
            else return true;
        }
        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType="")
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

                
                // với ola , cột tổng là tổng trọng lượng và trị giá
                double totalWeight = 0;
                double totalPrice = 0;

                // loop through each row and add values to our sheet
                int rowcount = 1;
                foreach (DataRow datarow in dataTable.Rows)
                {
                    
                    for (int i = 1; i <= dataTable.Columns.Count; i++)
                    {

                        switch (ReporType)
                        {
                            case "ola":
                                // với ola , cột tổng là tổng trọng lượng và trị giá
                                totalWeight += Convert.ToDouble(datarow[4].ToString());
                                //var x = datarow[6].ToString();
                                totalPrice += Convert.ToDouble(datarow[5].ToString());
                                
                                break;
                            case "cms":
                                // code block
                                break;
                            case "mic":
                                // code block
                                break;
                            default:
                                // code block
                                break;
                        }
                        if (checkType(ReporType))
                        {
                            if (rowcount == 1)
                            {
                                excelSheet.Cells[1, i] = dataTable.Columns[i-1].ColumnName;
                                excelSheet.Cells[1, i].Font.Color = System.Drawing.Color.Black;
                                excelSheet.Cells[1, i].Font.Bold = true;
                            }
                    
                               excelSheet.Cells[rowcount + 1, i].NumberFormat = "@";
                               excelSheet.Cells[rowcount + 1, i] = datarow[i - 1].ToString();
                        }else
                        {
                            if (rowcount == 4)
                            {
                                excelSheet.Cells[4, i] = dataTable.Columns[i - 1].ColumnName;
                                excelSheet.Cells[4, i].Font.Color = System.Drawing.Color.Black;
                                excelSheet.Cells[4, i].Font.Bold = true;
                            }

                                excelSheet.Cells[rowcount+4, i].NumberFormat = "@";
                                excelSheet.Cells[rowcount+4, i] = datarow[i - 1].ToString();
                            
                        }
                    }
                    rowcount += 1;
                }
                switch (ReporType)
                {
                    case "ola":
                        excelSheet.Cells[1, 1] = title;
                        excelSheet.Cells[2, 2] = titleOla;
                        excelSheet.Cells[2, 2].Font.Bold = true;
                        excelSheet.Cells[2, 2].Font.Size = 16;
                        excelSheet.Cells[3, 6] = infoTile;
                        excelSheet.Cells[3, 7] = infoContent;
                        excelSheet.Cells[rowcount +4, 3] = "Tổng";
                        excelSheet.Cells[rowcount+4, 5] = totalWeight.ToString();
                        excelSheet.Cells[rowcount+4, 6] = totalPrice.ToString();
                        excelSheet.Cells[rowcount + 5, 9] = endFile;
                        excelSheet.Cells[rowcount + 6, 9] = bussiness;
                        excelSheet.Cells[rowcount + 7, 9] = sign;
                        break;
                    case "cms":
                        // code block
                        break;
                    case "mic":
                        // code block
                        break;
                    default:
                        // code block
                        break;
                }

                // now we resize the columns
                excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                if (checkType(ReporType))
                {
                    excelCellrange = excelSheet.Range[excelSheet.Cells[1, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                }
                else
                {
                    switch (ReporType)
                    {
                        case "ola":
                            excelCellrange = excelSheet.Range[excelSheet.Cells[4, 1], excelSheet.Cells[rowcount + 4, dataTable.Columns.Count]];
                            break;
                        case "cms":
                            excelCellrange = excelSheet.Range[excelSheet.Cells[4, 1], excelSheet.Cells[rowcount + 3, dataTable.Columns.Count]];
                            break;
                        case "mic":
                            excelCellrange = excelSheet.Range[excelSheet.Cells[4, 1], excelSheet.Cells[rowcount + 3, dataTable.Columns.Count]];
                            break;
                        default:
                            // code block
                            break;
                    }
                }
                    
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
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }
    }
}
