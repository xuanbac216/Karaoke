using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using QuanlyKaraoke.BLL;

namespace QuanlyKaraoke
{
    public partial class frm_hddv : Form 
    {
        public string sohd;
        //DataSet ds;
        //static string connetionString = "server=localhost;database=karaoke;uid=root;pwd=;";
        //MySqlConnection conn = new MySqlConnection(connetionString);
        //MySqlDataAdapter daKaraoke;
        //DataTable table = new DataTable();

        public frm_hddv()
        {
            InitializeComponent();
            //OpenConnection();
        }

        private void lb_sohoadon_Click(object sender, EventArgs e)
        {

        }
       
        public new void LoadDichvu()
        {
            dgv_hddv.DataSource = null;
            dgv_hddv.Rows.Clear();

            #region Đổ dữ liệu bảng dịch vụ
            var lst = XuLyDichVu.GetDichVu();
            foreach (DichVu r in lst)
            {

                dgv_hddv.Rows.Add(r.maDichVu, r.tenDichVu, r.soLuong);
            }
            
           
            #endregion
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadDichvu();
            txt_hddv_sohd.Text = sohd;
        }
       
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_hddv_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_hddv.SelectedRows[0];
                txt_hddv_madv.Text = dt.Cells["dgv_dsdv_madv"].Value.ToString();
                //ExcuteHoaDonDichVu();

            }
            catch
            {
            }
        }

        private void btn_hddv_ok_Click(object sender, EventArgs e)
        {
            var soHd = txt_hddv_sohd.Text.ToString();
            var maDv = txt_hddv_madv.Text.ToString();
            var sl = nud_hddv_sl.Value.ToString();
            XuLyHoaDon.ThemDichVu(soHd, maDv, sl);
            this.Close();
        }
    }
}
