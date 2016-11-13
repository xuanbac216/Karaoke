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
        //private void OpenConnection()
        //{
        //    try
        //    {
        //        conn.Open();

        //    }
        //    catch (MySqlException ex)
        //    {
        //        //When handling errors, you can your application's response based 
        //        //on the error number.
        //        //The two most common error numbers when connecting are as follows:
        //        //0: Cannot connect to server.
        //        //1045: Invalid user name and/or password.
        //        switch (ex.Number)
        //        {
        //            case 0:
        //                MessageBox.Show("Cannot connect to server.  Contact administrator");
        //                break;

        //            case 1045:
        //                MessageBox.Show("Invalid username/password, please try again");
        //                break;
        //        }

        //    }
        //}
        //public new void LoadDichvu()
        //{
        //    dgv_hddv.DataSource = null;
        //    dgv_hddv.Rows.Clear();
        //    ds = new DataSet();
        //    #region Đổ dữ liệu bảng dịch vụ
        //    string sSelectHoaDonDichVu = "select * from dichvu";
        //    daKaraoke = new MySqlDataAdapter(sSelectHoaDonDichVu, conn);
        //    daKaraoke.Fill(ds, "tbl_ChonHoaDonDichVu");
        //    foreach (DataRow r in ds.Tables["tbl_ChonHoadonDichVu"].Rows)
        //    {

        //        dgv_hddv.Rows.Add(r[0], r[1], r[3]);
        //    }
        //    ds.Tables["tbl_ChonHoaDonDichVu"].Clear();
        //    conn.Close();
        //    #endregion
        //}
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
    }
}
