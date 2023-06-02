using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Thanh.ThuVien
{
    internal class XuLyDuLieu
    {
        public string strConn;
        public string loi;
        private SqlConnection conn;
        public string host, user, pw;
        public XuLyDuLieu()
        {
            //"Data Source=DESKTOP-G25SBPL;Initial Catalog=thanh;Integrated Security=True";
            // Data Source=DESKTOP-G25SBPL;Initial Catalog=thanh;Persist Security Info=True;User ID=thanh;Password=*********
            string[] host = DungChung.DocFile();
            strConn = "Data Source=" + host[0] + ";Initial Catalog=evi68651_xuancuong;Persist Security Info=True;User Id=" + host[1] + ";Password=" + host[2];
            conn = new SqlConnection(strConn);
        }

        public bool MoKetNoi()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                MessageBox.Show("đã có lỗi xảy ra " + loi);
                return false;
            }
        }

        public void DongKetNoi()
        {
            if(conn != null)
            {
                conn.Close();
            }
        }

        public DataTable LayDt(string strSql)
        {
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public SqlDataAdapter LayDa(String strSql)
        {
            SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            return da;
        }

        public bool KiemTraTrung(String strSql)
        {
            bool result = true;
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                var kq = cmd.ExecuteReader();
                if (kq.HasRows)
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                loi = ex.Message;
            }
            finally
            {
                DongKetNoi();
            }
            return result;
        }
        public bool ThucHienCauLenh(String strSql)
        {
            int kq = 0;
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                loi = ex.Message;
                kq = 0;
            }
            finally
            {
                DongKetNoi();
            }
            return kq > 0;
        }

        public int LenhVoHuong(String strSql)
        {
            int kq = 0;
            try
            {
                loi = "";
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                object a = cmd.ExecuteScalar();
                if (a != null)
                    kq = int.Parse(a.ToString());
            }
            catch (Exception ex)
            {
                loi = ex.Message;
            }
            finally
            {
                DongKetNoi();
            }
            return kq;
        }

        public string LenhLayKq(String strSql)
        {
            string kq = "";
            try
            {
                loi = "";
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                object a = cmd.ExecuteScalar();
                if (a != null)
                    kq = a.ToString();
            }
            catch (Exception ex)
            {
                loi = ex.Message;
            }
            finally
            {
                DongKetNoi();
            }
            return kq;
        }

        // kiếm tra tên có trùng với phần tên lỗi không (tên không có thực, nếu đúng, thay thế bằng tên khác)
        public string checkName(string name)
        {
            string sql = "select replace from tb_tenthaythe where name = N'" + name + "'";
            string a = LenhLayKq(sql);
            if (string.Equals(a, ""))
            {
                return name;
            }
            else
            {
                return a;
            }
        }
        //public string getRow(string name)
        //{
        //    string sql = "select *  from tb_tenthaythe where name = N'" + name + "'";
        //    string a = LenhLayKq(sql);
        //    if (string.Equals(a, ""))
        //    {
        //        return name;
        //    }
        //    else
        //    {
        //        return a;
        //    }
        //}
    }
}
