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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Thanh.HeThong
{
    public partial class FrmXuLyMoRong : Form
    {
        #region Init var

        private string DuongDanFile;
        private XuLyDuLieu objXldl;
        private System.Data.DataTable dtNguoiDungfake, dtTrungGian, dtKey, dtBrand, dtExport, dtUpCMS, dtMICChuan;
        private int dem  = 1;
        private string[] columnName = { "STT","MÃ VẬN ĐƠN", "MÔ TẢ HÀNG HÓA", "KIỆN", "TRỌNG LƯỢNG", "TRỊ GIÁ", "NGƯỜI GỬI", "NGƯỜI NHẬN", "ĐỊA CHỈ NGƯỜI NHẬN", "Ghi Chú" };
        private string[] columnNameUpCMS = { "ID Card", "MasterAirWayBill", "FlightNumber", "FlightDate", "LM Tracking", "Product Name 1", "ContentVN", "HSCode", "Currency", "Original quantity", "Declared Value 1", "Parcel Weight(KG)", "Customs Declaration", "Original", "Destination", "Receiver Name", "Receiver Address City", "Receiver Telephone", "Carton No", "Country", "Sender Name", "Sender Address" };
        private string[] columnNameMICChuan = { "MAWB (20)", "HAWB (20)", "CANHAN_TOCHUC(1)", "DIADIEM_LUUKHO(7)", "MAYBAY(12)", "NGAY_DEN(8)", "DIADIEM_DOHANG(5)", "DIADIEM_XEPHANG(5)", "MA_NGUOI NHAP (13)", "TEN_NGUOINHAP (100)", "DIACHI_NHAP (100)", "SDT_NHAP (20)", "Mã Nước_XX", "Tên_NGUOI_XUAT_Khẩu(70)", "DIACHI_XUAT", "Mã bưu chính (7)", "SO_LUONG(6)", "TRONG_LUONG(8)", "Mã phân loại giá hóa đơn (1)", "Mã điều kiện giá hóa đơn(3)", "Mã đồng Tiền của hóa đơn (3)", "Tổng tri giá hóa đơn (20)", "TRI_GIA tính huế(8)", "MO TA_HANG(200)", "Số quản lý nội bộ", "GHI_CHU(100)", "Mã phân loại cước vận chuyển (1)", "Mã iền ệ cước vận chuyển (3)", "Phí vận chuyển (18)", "Mã phân loại bảo hiểm (1)", "Mã iền ệ của iền bảo hiểm (3)", "Phí bảo hiểm (18)" };

        private List<string> replaceName = new List<string>();
        private List<string> fakeName = new List<string>();
        private List<int> randomList = new List<int>();
        #endregion


        /// <summary>
        /// những sự kiện khi load form
        /// </summary>
        public FrmXuLyMoRong()
        {
            objXldl = new XuLyDuLieu();
            InitializeComponent();
        }

        #region event
        /// <summary>
        ///  button chọn file, lấy các sheet có trong file excel đó, add vào combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            cbSheet.Items.Clear();
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtChonFile.Text = ofd.FileName;
                    DuongDanFile = ofd.FileName;
                    String[] a = DungChung.LaySheet(DuongDanFile);
                    DungChung.fileXuLyChinh = DuongDanFile;
                    
                    if (a != null)
                    {
                        cbSheet.Enabled = true;
                        cbSheet.Items.AddRange(a);
                    }
                }
            }
        }
        
        /// <summary>
        /// sự kiện đóng dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DungChung.Kieu == null && DungChung.Kieu == null && DungChung.SoMAWB == null && DungChung.ChuyenBay == null && DungChung.NgayDen == null)
            {
                // exportFileUpCMS();
            }
            else
            {
                lbKieu.Text = DungChung.Kieu.ToString();
                lbSoMAWB.Text = DungChung.SoMAWB.ToString();
                lbChuyenBay.Text = DungChung.ChuyenBay.ToString();
                lbNgayDen.Text = DungChung.NgayDen.ToString();
            }
        }

        /// <summary>
        /// button export file mic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMIC_Click(object sender, EventArgs e)
        {
            if (DungChung.Kieu == null || DungChung.SoMAWB == null || DungChung.ChuyenBay == null || DungChung.NgayDen == null)
            {
                MessageBox.Show("Bạn cần điền thông tin trước");
            }
            else
            {
                exportFileMICChuan();
            }
        }

        /// <summary>
        /// button export file cms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCMS_Click(object sender, EventArgs e)
        {
            if (DungChung.Kieu == null || DungChung.Kieu == null || DungChung.SoMAWB == null || DungChung.ChuyenBay == null || DungChung.NgayDen == null)
            {
                // exportFileUpCMS();
                MessageBox.Show("Bạn cần điền đẩy đủ thông tin trước");
            }
            else
            {
                exportFileUpCMS();
            }
        }

        /// <summary>
        /// người dùng nhấn button xuất bảng kê ola
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnXuat1_Click(object sender, EventArgs e)
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
                obj.WriteDataTableToExcel(dtBangKe(dtTrungGian), "Dữ liệu", filePath, "ola");

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// change value trong combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSheet.SelectedItem.ToString() != "")
            {
                dtTrungGian = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DuongDanFile);
                dgvXuLy.DataSource = dtTrungGian;
                dtTrungGian = ChuanBiDuLieu(dtTrungGian);
               
                //dtTrungGian = dtBangKe(dtTrungGian);
            }
        }


        /// <summary>
        /// Người dùng mở dialog add thêm thông tin về chuyến /...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddThongtin_Click(object sender, EventArgs e)
        {
            FrmDialog frm = new FrmDialog();
            frm.FormClosed += frm_FormClosed;
            frm.Show();
        }

        /// <summary>
        /// sự kiện form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmXuLyMoRong_Load(object sender, EventArgs e)
        {
            dtKey = objXldl.LayDt("select * from tb_key");
            dtBrand = objXldl.LayDt("select * from tb_nhanhieu");
            dtNguoiDungfake = objXldl.LayDt("select * from tb_nguoidungfake");
        }
        #endregion


        #region function process
        /// <summary>
        ///  button export file up cms
        /// </summary>
        private void exportFileUpCMS()
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
                dtUpCMS = dtCMS(dtUpCMS);
                obj.WriteDataTableToExcel(dtUpCMS, "Dữ liệu", filePath, "cms");

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///  hàm xử lý export file mic chuẩn
        /// </summary>
        private void exportFileMICChuan()
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
                dtMICChuan = dtGenMICChuan(dtMICChuan);
                obj.WriteDataTableToExcel(dtMICChuan, "Dữ liệu", filePath, "mic");

                MessageBox.Show("File được tạo tại  " + filePath);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// process bar
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="value"></param>
        private void processBar(int min, int max, int value)
        {
            
        }

        /// <summary>
        /// Tên người dùng có trùng không (ngay trong datatable)
        /// </summary>
        /// <param name="tenNguoiDung"></param>
        /// <returns></returns>
        private int KiemTraNguoiDung(string tenNguoiDung)
        {
            try
            {
                System.Data.DataTable dtResult = dtTrungGian.Select("`Receiver Name` LIKE '%" + tenNguoiDung + "%'").CopyToDataTable();
                return (dtResult.Rows.Count > 1) ? dtResult.Rows.Count : 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Kiểm tra địa chỉ trùng lặp và thay thế
        /// </summary>
        /// <param name="diaChi"></param>
        /// <returns></returns>
        private int KiemTraDiaChi(string diaChi)
        {
            try
            {
                System.Data.DataTable dtResult = dtTrungGian.Select("`Receiver Address` LIKE '%" + diaChi + "%'").CopyToDataTable();
                return (dtResult.Rows.Count > 1) ? dtResult.Rows.Count : 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Kiểm tra địa chỉ trùng lặp và thay thế
        /// </summary>
        /// <param name="dienThoai"></param>
        /// <returns></returns>
        private int KiemTraDienThoai(string dienThoai)
        {
            try
            {
                System.Data.DataTable dtResult = dtTrungGian.Select("`Receiver Telephone` LIKE '%" + dienThoai + "%'").CopyToDataTable();
                return (dtResult.Rows.Count > 1) ? dtResult.Rows.Count : 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        /// <summary>
        /// Chuẩn bị dữ liệu datatable , thay thế các tên người dùng trùng
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private System.Data.DataTable ChuanBiDuLieu(System.Data.DataTable dt)
        {
            System.Data.DataTable dtResult = dtTrungGian;
            int vtTenNguoidung = 1;
            int vtDiaChi = 1;
            int vtDienThoai = 1;
            for (int i = 0; i < dtTrungGian.Rows.Count; i++)
            {
                if (KiemTraNguoiDung(dtTrungGian.Rows[i]["Receiver Name"].ToString()) != 0)
                {
                    dtResult.Rows[i]["Receiver Name"] = dtNguoiDungfake.Rows[vtTenNguoidung]["Name"].ToString();
                    vtTenNguoidung++;
                }
                if (KiemTraDiaChi(dtTrungGian.Rows[i]["Receiver Address"].ToString()) != 0)
                {
                    dtResult.Rows[i]["Receiver Address"] = dtNguoiDungfake.Rows[vtDiaChi]["Address"].ToString();
                    vtDiaChi++;
                }
                if (KiemTraDienThoai(dtTrungGian.Rows[i]["Receiver Telephone"].ToString()) != 0)
                {
                    dtResult.Rows[i]["Receiver Telephone"] = dtNguoiDungfake.Rows[vtDienThoai]["Telephone"].ToString();
                    vtDienThoai++;
                }
            }
            return dtResult;
        }

        /// <summary>
        /// function xuất bảng kê ola
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private System.Data.DataTable dtBangKe(System.Data.DataTable dt)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            try
            {
                dtResult = DungChung.MakeDataTables(dtResult, columnName);
                Random random = new Random();

                // xử lý lấy key
                int clSTT = 1;
                for (int i = 0; i < dtTrungGian.Rows.Count; i++)
                {

                    //Thread t = new Thread(new ThreadStart(() =>
                    //{

                    //}));
                    //t.Start();
                    int j = DungChung.TimKiemKey(dtTrungGian.Rows[i]["Product Name 1"].ToString(), dtKey);
                    if (j != -1)
                    {
                        DataRow myRow;
                        // MessageBox.Show(j.ToString());
                        myRow = dtResult.NewRow();
                        // dtResult.Rows[i]["MÔ TẢ HÀNG HÓA"] = dtKey.Rows[j]["unit"].ToString() + " " + dtKey.Rows[j]["convertname"].ToString();
                        myRow["STT"] = clSTT.ToString();
                        clSTT++;
                        myRow["MÃ VẬN ĐƠN"] = dtTrungGian.Rows[i]["LM Tracking"].ToString();
                        myRow["KIỆN"] = dtTrungGian.Rows[i]["Carton No"].ToString();
                        //myRow["TRỌNG LƯỢNG"] = dtTrungGian.Rows[i]["Carton Weight(KG)"].ToString();
                        myRow["TRỌNG LƯỢNG"] = dtTrungGian.Rows[i]["Parcel Weight(KG)"].ToString();
                        // MessageBox.Show(dtTrungGian.Rows[i]["Carton Weight(KG)"].ToString());Parcel Weight(KG)
                        myRow["NGƯỜI GỬI"] = dtTrungGian.Rows[i]["Sender Name"].ToString();
                        //myRow["NGƯỜI NHẬN"] = dtTrungGian.Rows[i]["Receiver Name"].ToString();
                        myRow["NGƯỜI NHẬN"] = objXldl.checkName(dtTrungGian.Rows[i]["Receiver Name"].ToString());
                        myRow["ĐỊA CHỈ NGƯỜI NHẬN"] = dtTrungGian.Rows[i]["Receiver Address"].ToString() +", "+dtTrungGian.Rows[i]["Receiver City"].ToString() + ", " + dtTrungGian.Rows[i]["Receiver Province/State"].ToString();
                        double total = 0, dem = 1;
                        while (dem <= 22)
                        {
                            double tem = 0;
                            if (!String.Equals(dtTrungGian.Rows[i]["货值（越南盾）" + dem.ToString()].ToString(), ""))
                            {
                                tem = double.Parse(dtTrungGian.Rows[i]["货值（越南盾）" + dem.ToString()].ToString());
                            }
                            total += tem;
                            dem++;
                        }
                        myRow["TRỊ GIÁ"] = total.ToString();

                        objXldl.MoKetNoi();
                        string sql = "select Code from tb_thanhpho where TinhTP = N'" + dtTrungGian.Rows[i]["Receiver Province/State"] + "'";
                        int codeThanhPho = objXldl.LenhVoHuong(sql);
                        int n = random.Next(0, 2);

                        int bYear = random.Next(70, 99);

                        // 100000-999999
                        int rand = random.Next(100000, 999999);
                        myRow["Ghi Chú"] = "CMT" + codeThanhPho.ToString() + n.ToString() + bYear.ToString() + rand.ToString();

                        myRow["MÔ TẢ HÀNG HÓA"] = DungChung.RandomItemInArray(dtKey.Rows[j]["unit"].ToString()) + " " + dtKey.Rows[j]["convertname"].ToString();
                        if (dtKey.Rows[j]["materialcall"].ToString() != "" || dtKey.Rows[j]["material"].ToString() != "")
                        {
                            string x = "";
                            if (dtKey.Rows[j]["materialcall"].ToString() != "")
                            {
                                x += ",  " + dtKey.Rows[j]["materialcall"].ToString();
                            }

                            if (dtKey.Rows[j]["material"].ToString() != "")
                            {
                                x += " " + dtKey.Rows[j]["material"].ToString() + ",";
                            }

                            //dtResult.Rows[i]["MÔ TẢ HÀNG HÓA"] += x;
                            myRow["MÔ TẢ HÀNG HÓA"] += x;
                        }
                        // dtResult.Rows[i]["MÔ TẢ HÀNG HÓA"] += " " + dtKey.Rows[j]["classifytype"].ToString() + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["classify"].ToString());
                        myRow["MÔ TẢ HÀNG HÓA"] += " " + dtKey.Rows[j]["classifytype"].ToString() + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["classify"].ToString());
                        List<int> nhanhieu;
                        if (dtTrungGian.Rows[i]["Declared Name 1"].ToString() != "")
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtTrungGian.Rows[i]["Declared Name 1"].ToString(), dtBrand);
                        }
                        else
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtKey.Rows[i]["brand"].ToString(), dtBrand);
                        }
                        int y = 0;

                        DataColumnCollection columns = dtTrungGian.Columns;
                        string temp = "";
                        foreach (var nh in nhanhieu)
                        {
                            // MessageBox.Show(nh.ToString());
                            if (y == 0)
                            {

                                //MessageBox.Show((dtBrand.Rows[nh]["nhom1"].ToString()));
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            else
                            {

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            y++;
                        }
                        string[] arrtemp = temp.Split(';');

                        int start = random.Next(0, arrtemp.Length);
                        arrtemp[start] = ", NCC " + arrtemp[start];
                        myRow["MÔ TẢ HÀNG HÓA"] += arrtemp[start];
                        dtResult.Rows.Add(myRow);
                    }

                }
                // xử lý với branch\
                dtExport = dtResult;
                dgvXuLy.DataSource = dtExport;
                return dtResult;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return dtResult;
        }
        

        /// <summary>
        /// function xuất bảng kê cms
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private System.Data.DataTable dtCMS(System.Data.DataTable dt)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            try
            {
               

                dtResult = DungChung.MakeDataTables(dtResult, columnNameUpCMS);
                Random random = new Random();

                
                // xử lý lấy key
                for (int i = 0; i < dtTrungGian.Rows.Count; i++)
                {
                    processBar(0, dtTrungGian.Rows.Count, i);

                    DataRow myRow;

                    int j = DungChung.TimKiemKey(dtTrungGian.Rows[i]["Product Name 1"].ToString(), dtKey);
                    if (j != -1)
                    {
                        // MessageBox.Show(j.ToString());
                        myRow = dtResult.NewRow();
                        System.DateTime today = System.DateTime.Today;
                        myRow["MasterAirWayBill"] = DungChung.SoMAWB.ToString();
                        myRow["FlightNumber"]= DungChung.ChuyenBay.ToString() + "/" + DungChung.getDate() + today.ToString("MMM"); ;
                        myRow["FlightDate"]= DungChung.NgayDen.ToString();

                        // myRow["MÃ VẬN ĐƠN"]=DungChung.SoMAWB;

                        myRow["LM Tracking"] = dtTrungGian.Rows[i]["LM Tracking"].ToString();
                        myRow["Product Name 1"] = dtTrungGian.Rows[i]["Product Name 1"].ToString();
                        myRow["Currency"] = "VNĐ";
                        myRow["Original quantity"] = dtTrungGian.Rows[i]["Declared QTY 1"].ToString();
                        myRow["Parcel Weight(KG)"] = dtTrungGian.Rows[i]["Parcel Weight(KG)"].ToString();

                        double total = 0, dem = 1;
                        while (dem <= 22)
                        {
                            double tem = 0;
                            if (!String.Equals(dtTrungGian.Rows[i]["货值（越南盾）" + dem.ToString()].ToString(), ""))
                            {
                                tem = double.Parse(dtTrungGian.Rows[i]["货值（越南盾）" + dem.ToString()].ToString());
                            }
                            total += tem;
                            dem++;
                        }

                        myRow["Customs Declaration"] = total.ToString();
                        myRow["Original"] = "CNSZX";
                        myRow["Destination"] = "HAN";
                        // myRow["Receiver Name"] = dtTrungGian.Rows[i]["Receiver Name"].ToString();
                        myRow["Receiver Name"] = objXldl.checkName( dtTrungGian.Rows[i]["Receiver Name"].ToString());
                        myRow["Receiver Address City"] = dtTrungGian.Rows[i]["Receiver Address"].ToString()+ ", " + dtTrungGian.Rows[i]["Receiver City"].ToString() + ", "  + dtTrungGian.Rows[i]["Receiver Province/State"].ToString() + ", Việt Nam";
                        myRow["Receiver Telephone"] = dtTrungGian.Rows[i]["Receiver Telephone"].ToString();
                        myRow["Carton No"] = dtTrungGian.Rows[i]["Carton No"].ToString();
                        myRow["Country"] = "CN";
                        myRow["Sender Name"] = dtTrungGian.Rows[i]["Sender Name"].ToString();
                        myRow["Sender Address"] = dtTrungGian.Rows[i]["Sender Address"].ToString();
                        myRow["Carton No"] = dtTrungGian.Rows[i]["Carton No"].ToString();

                        

                        myRow["ContentVN"] = DungChung.RandomItemInArray(dtKey.Rows[j]["unit"].ToString()) + " " + dtKey.Rows[j]["convertname"].ToString();

                        if (dtKey.Rows[j]["materialcall"].ToString() != "" || dtKey.Rows[j]["material"].ToString() != "")
                        {
                            string x = "";
                            if (dtKey.Rows[j]["materialcall"].ToString() != "")
                            {
                                x += ",  " + dtKey.Rows[j]["materialcall"].ToString();
                            }

                            if (dtKey.Rows[j]["material"].ToString() != "")
                            {
                                x += " " + dtKey.Rows[j]["material"].ToString() + ",";
                            }

                           
                            myRow["ContentVN"] += x;
                        }

                        myRow["ContentVN"] += " " + dtKey.Rows[j]["classifytype"].ToString() + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["classify"].ToString());
                        List<int> nhanhieu;
                        if (dtTrungGian.Rows[i]["Declared Name 1"].ToString() != "")
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtTrungGian.Rows[i]["Declared Name 1"].ToString(), dtBrand);
                        }
                        else
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtKey.Rows[i]["brand"].ToString(), dtBrand);
                        }
                        int y = 0;

                        DataColumnCollection columns = dtTrungGian.Columns;
                        string temp = "";
                        foreach (var nh in nhanhieu)
                        {
                            
                            if (y == 0)
                            {

                                
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            else
                            {

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            y++;
                        }
                        string[] arrtemp = temp.Split(';');

                        int start = random.Next(0, arrtemp.Length);
                        arrtemp[start] = ", NCC " + arrtemp[start];
                        myRow["ContentVN"] += arrtemp[start];

                        myRow["Declared Value 1"] = Math.Round(double.Parse(myRow["Customs Declaration"].ToString()) / double.Parse(myRow["Original quantity"].ToString()), 2);
                        // myRow["Carton No"] = dtTrungGian.Rows[i]["Carton No"].ToString();
                        dtResult.Rows.Add(myRow);
                        // hết phần content vn
                    }
                }
                // xử lý với branch
                dtExport = dtResult;
                dgvXuLy.DataSource = dtExport;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return dtResult;
        }


        /// <summary>
        /// function xuất file mic chuẩn
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private System.Data.DataTable dtGenMICChuan(System.Data.DataTable dt)
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            try
            {
                dtResult = DungChung.MakeDataTables(dtResult, columnNameMICChuan);
                // dtTrungGian = DungChung.LayDL(cbSheet.SelectedItem.ToString(), DungChung.fileXuLyChinh);
                Random random = new Random();
                // xử lý lấy key

                
                for (int i = 0; i < dtTrungGian.Rows.Count; i++)
                {
                    processBar(0, dtTrungGian.Rows.Count, i);

                    DataRow myRow;

                    int j = DungChung.TimKiemKey(dtTrungGian.Rows[i]["Product Name 1"].ToString(), dtKey);
                    if (j != -1)
                    {
                        // MessageBox.Show(j.ToString());
                        myRow = dtResult.NewRow();

                        myRow["MAWB (20)"] = DungChung.SoMAWB.ToString();
                        System.DateTime today = System.DateTime.Today;

                        myRow["MAYBAY(12)"] = DungChung.ChuyenBay.ToString() + "/"+ DungChung.getDate() + today.ToString("MMM");
                        myRow["NGAY_DEN(8)"] = DungChung.NgayDen.ToString();

                        // myRow["MÃ VẬN ĐƠN"]=DungChung.SoMAWB;

                        myRow["HAWB (20)"] = dtTrungGian.Rows[i]["LM Tracking"].ToString();

                        myRow["CANHAN_TOCHUC(1)"] ="2";
                        myRow["DIADIEM_LUUKHO(7)"] = "15BBEA0";
                        myRow["DIADIEM_DOHANG(5)"] = "VNHNG";
                        myRow["DIADIEM_XEPHANG(5)"] = "CNSZX";
                        myRow["MA_NGUOI NHAP (13)"] = ("9999999999998").ToString();
                        myRow["TEN_NGUOINHAP (100)"] = objXldl.checkName(dtTrungGian.Rows[i]["Receiver Name"].ToString());
                        myRow["DIACHI_NHAP (100)"] = dtTrungGian.Rows[i]["Receiver Address"].ToString() + " " + dtTrungGian.Rows[i]["Receiver City"].ToString() + " " + dtTrungGian.Rows[i]["Receiver Province/State"].ToString() + " Việt Nam";

                        myRow["SDT_NHAP (20)"] = dtTrungGian.Rows[i]["Receiver Telephone"].ToString();
                        myRow["Mã Nước_XX"] = "CN";
                        myRow["Tên_NGUOI_XUAT_Khẩu(70)"] = dtTrungGian.Rows[i]["Sender Name"];
                        myRow["DIACHI_XUAT"] = dtTrungGian.Rows[i]["Sender Address"].ToString();
                        myRow["Mã bưu chính (7)"] = "";
                        myRow["SO_LUONG(6)"] ="1";
                        myRow["TRONG_LUONG(8)"] = dtTrungGian.Rows[i]["Parcel Weight(KG)"].ToString();
                        myRow["Mã phân loại giá hóa đơn (1)"] = "D";
                        myRow["Mã điều kiện giá hóa đơn(3)"] = "DAF";
                        myRow["Mã đồng Tiền của hóa đơn (3)"] = "VND";
                        double total = 0, dem = 1;
                        while(dem <= 22)
                        {
                            double tem = 0;
                            if(!String.Equals(dtTrungGian.Rows[i]["货值（越南盾）"+ dem.ToString()].ToString(), ""))
                            {
                                tem = double.Parse(dtTrungGian.Rows[i]["货值（越南盾）" + dem.ToString()].ToString());
                            }
                            total += tem;
                            dem++;
                        }
                        myRow["Tổng tri giá hóa đơn (20)"] = total.ToString();
                        myRow["TRI_GIA tính huế(8)"] = "";
                        myRow["Số quản lý nội bộ"] = dtTrungGian.Rows[i]["Carton No"].ToString();

                        myRow["Mã phân loại cước vận chuyển (1)"] = "";
                        myRow["Mã iền ệ cước vận chuyển (3)"] = "";
                        myRow["Phí vận chuyển (18)"] = "";
                        myRow["Mã phân loại bảo hiểm (1)"] = "";
                        myRow["Mã iền ệ của iền bảo hiểm (3)"] = "";
                        myRow["Phí bảo hiểm (18)"] = "";

                        myRow["MO TA_HANG(200)"] = DungChung.RandomItemInArray(dtKey.Rows[j]["unit"].ToString()) + " " + dtKey.Rows[j]["convertname"].ToString();

                        if (dtKey.Rows[j]["materialcall"].ToString() != "" || dtKey.Rows[j]["material"].ToString() != "")
                        {
                            string x = "";
                            if (dtKey.Rows[j]["materialcall"].ToString() != "")
                            {
                                x += ",  " + dtKey.Rows[j]["materialcall"].ToString();
                            }

                            if (dtKey.Rows[j]["material"].ToString() != "")
                            {
                                x += " " + dtKey.Rows[j]["material"].ToString() + ",";
                            }


                            myRow["MO TA_HANG(200)"] += x;
                        }

                        myRow["MO TA_HANG(200)"] += " " + dtKey.Rows[j]["classifytype"].ToString() + " " + DungChung.RandomItemInArray(dtKey.Rows[j]["classify"].ToString());
                        List<int> nhanhieu;
                        if (dtTrungGian.Rows[i]["Declared Name 1"].ToString() != "")
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtTrungGian.Rows[i]["Declared Name 1"].ToString(), dtBrand);
                        }
                        else
                        {
                            nhanhieu = DungChung.TimKiemNhanHieu(dtKey.Rows[i]["brand"].ToString(), dtBrand);
                        }
                        int y = 0;

                        DataColumnCollection columns = dtTrungGian.Columns;
                        string temp = "";
                        foreach (var nh in nhanhieu)
                        {

                            if (y == 0)
                            {


                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            else
                            {

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 500000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom1"].ToString();
                                }
                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 500000 & Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) < 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom2"].ToString();
                                }

                                if (Double.Parse(dtTrungGian.Rows[i]["Declared Value 1"].ToString()) > 1000000)
                                {
                                    temp += dtBrand.Rows[nh]["nhom3"].ToString();
                                }
                            }
                            y++;
                        }
                        string[] arrtemp = temp.Split(';');

                        int start = random.Next(0, arrtemp.Length);
                        arrtemp[start] = ", NCC " + arrtemp[start];
                        myRow["MO TA_HANG(200)"] += arrtemp[start];
                       
                        // hết phần content vn

                        // phần ghi chú
                        objXldl.MoKetNoi();
                        string sql = "select Code from tb_thanhpho where TinhTP = N'" + dtTrungGian.Rows[i]["Receiver Province/State"] + "'";
                        int codeThanhPho = objXldl.LenhVoHuong(sql);
                        int n = random.Next(0, 2);

                        int bYear = random.Next(70, 99);

                        int rand = random.Next(100000, 999999);
                        myRow["GHI_CHU(100)"] = objXldl.checkName(dtTrungGian.Rows[i]["Receiver Name"].ToString()) + " - " +  "CMT" + codeThanhPho.ToString() + n.ToString() + bYear.ToString() + rand.ToString();
                        dtResult.Rows.Add(myRow);
                    }
                    else
                    {
                        
                    }
                }
                // xử lý với branch
                dtExport = dtResult;
                dgvXuLy.DataSource = dtExport;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return dtResult;
        }
        #endregion
    }
}
