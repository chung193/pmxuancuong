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
using System.Runtime.InteropServices;
using WMPLib;
using System.Reflection;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Thanh.HeThong
{
    public partial class FrmCheck : Form
    {
        private XuLyDuLieu objXldl;
        System.Data.DataTable dtDL;
        string pathRed = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\red.mp3";
        string pathBlue = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\blue.mp3";
        string pathYellow = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\yellow.mp3";
        string _idfile ="";
        public FrmCheck()
        {
            InitializeComponent();
            objXldl = new XuLyDuLieu();
        }

        private void FrmCheck_Load(object sender, EventArgs e)
        {
            loadCb();
        }

        public void loadCb()
        {
            cbFile.Text = "";
            cbFile.Items.Clear();
            string sql = "select * from tb_fileluong";
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = objXldl.LayDt(sql);
            if (dt != null)
            {
                cbFile.Enabled = true;
                cbFile.DataSource = dt;
                cbFile.DisplayMember = "tenfile";
                cbFile.ValueMember = "id";
                //cbFile.SelectedValue = 0;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string id = cbFile.SelectedValue.ToString();
            string sql = "select * from tb_luong where mafile = " + id;
            lbDangChon.Text = "File đang chọn: "+cbFile.Text;
            dtDL = objXldl.LayDt(sql);
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private List<String> getList(DataView dv)
        {
            List<string> list = new List<string>();

            foreach (DataRowView row in dv)
            {
                list.Add(row.Row.ItemArray[4].ToString());
            }
            return list.Distinct().ToList(); ;
        }

        private void playMedia(string resourceName)
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            switch (resourceName)
            {
                case "red":
                    player.URL = pathRed;
                    break;
                case "blue":
                    player.URL = pathBlue;
                    break;
                case "yellow":
                    player.URL = pathYellow;
                    break;
                default:
                    player.URL = pathBlue;
                    break;
            }
            player.controls.play();
        }

        private void insertCheck(string text, int id)
        {
            String strSql;
            DateTime localDate = DateTime.Now;
            strSql = "insert into tb_check(idFile, name, datetime) values(" + id.ToString() + ", '" + text + "', '" + localDate + "')";
            //MessageBox.Show(strSql);
            objXldl.ThucHienCauLenh(strSql);
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sothungDgv.Rows.Add(txtCode.Text);
               
                DataView dv = new DataView(dtDL);
                dv.RowFilter = "sothung Like '%" + txtCode.Text + "%'";
                List<string> list = new List<string>();
                list = getList(dv);
                //MessageBox.Show(txtCode.Text + _idfile);
                insertCheck(txtCode.Text,int.Parse(_idfile));
                txtCode.Text = "";
                if (list.Count > 0)
                {
                    bool existRed = list.Contains("Đỏ");
                    if (existRed)
                    {
                        playMedia("red");
                    }
                    else
                    {
                        bool existYellow = list.Contains("Vàng");
                        if (existYellow)
                        {
                            playMedia("yellow");
                        }
                        else
                        {
                            playMedia("blue");
                        }
                    }
                    checkDgv.DataSource = dv;
                }
                else
                {
                    //MessageBox.Show("Không có dữ liệu với mã thùng đã nhập");
                }
            }
        }

        private void cbFile_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbFile_SelectedIndexChanged(object sender, EventArgs e)
        {
                _idfile = cbFile.SelectedValue.ToString();
        }
    }
}
