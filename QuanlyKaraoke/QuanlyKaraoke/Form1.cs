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

namespace QuanlyKaraoke
{
    public partial class Form1 : Form
    {
        DataSet ds;
        static string connetionString = "server=localhost;database=karaoke;uid=root;pwd=;";
        MySqlConnection conn = new MySqlConnection(connetionString);
        MySqlDataAdapter daKaraoke;
        DataTable table = new DataTable();
        string testRoom;
        public int check;
        public Form1()
        {
            InitializeComponent();
            OpenConnection();
          
        }
        private void OpenConnection()
        {
            try
            {
                conn.Open();

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }

            }
        }


        private void CloseConnection()
        {
            try
            {
                conn.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        
        public void LoadKhoHoaDon()
        {
            #region Đổ dữ liệu cho kho hóa đơn
            dgv_khohoadon.DataSource = null;
            dgv_khohoadon.Rows.Clear();
            string sSelectHoadon = "select * from hoadon";
            daKaraoke = new MySqlDataAdapter(sSelectHoadon, conn);
            daKaraoke.Fill(ds, "tbl_KhoHoaDon");
            foreach (DataRow r in ds.Tables["tbl_KhoHoaDon"].Rows)
            {

                dgv_khohoadon.Rows.Add(r[0], r[1], r[2], r[3], r[4], r[5]);
            }
            ds.Tables["tbl_KhoHoaDon"].Clear();
            #endregion
        }
        public void LoadHoaDonHoatDong()
        {
            dgv_hoadonhd.DataSource = null;
            dgv_hoadonhd.Rows.Clear();
            #region Đổ dữ liệu cho hóa đơn đang hoạt động
            string sSelectHoadonhd = "select * from hoadon where trangthai=0";
            daKaraoke = new MySqlDataAdapter(sSelectHoadonhd, conn);
            daKaraoke.Fill(ds, "tbl_HoaDonHoatDong");
            foreach (DataRow r in ds.Tables["tbl_HoaDonHoatDong"].Rows)
            {

                dgv_hoadonhd.Rows.Add(r[0], r[1], r[4]);
            }
            ds.Tables["tbl_HoaDonHoatDong"].Clear();
            #endregion
        }
        public void LoadCmbPhong()
        {
            #region Đổ dữ liệu cho combobox phòng
            DataTable cmb = new DataTable();
            cmb.Columns.Add("maphong");
            cmb.Columns.Add("tenphong");
            
            string sSelectPhong = "select maphong,tenphong from phong where trangthai=0";
            daKaraoke = new MySqlDataAdapter(sSelectPhong, conn);
            daKaraoke.Fill(ds, "tbl_Phong");
            
            foreach (DataRow r in ds.Tables["tbl_Phong"].Rows)
            {

                cmb.Rows.Add(r[0], r[1]);
                
            }
            cmb_hdphong.DataSource = cmb;
            cmb_hdphong.DisplayMember = "tenphong";
            cmb_hdphong.ValueMember = "maphong";
            ds.Tables["tbl_Phong"].Rows.Clear();
            //cmb_hdphong.DataSource = ds.Tables["tbl_Phong"];
           

            #endregion
        }
        public void LoadDichvu()
        {
            dgv_dichvu.DataSource = null;
            dgv_dichvu.Rows.Clear();
            #region Đổ dữ liệu bảng dịch vụ
            string sSelectHoadonhd = "select * from dichvu";
            daKaraoke = new MySqlDataAdapter(sSelectHoadonhd, conn);
            daKaraoke.Fill(ds, "tbl_DichVu");
            foreach (DataRow r in ds.Tables["tbl_DichVu"].Rows)
            {

                dgv_dichvu.Rows.Add(r[0],r[1], r[2],r[3],r[4],r[5]);
               
            }
            ds.Tables["tbl_DichVu"].Clear();
            #endregion
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ds = new DataSet("dsKhoHoaDon");

            #region Load form
            txt_hdsohoadon.Text = "";
            cmb_hdphong.Text = "";
            dtm_hdgiovao.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtm_hdgiora.Text = "";
            
            LoadKhoHoaDon();
            LoadHoaDonHoatDong();
            LoadCmbPhong();
            LoadDichvu();
            #endregion
            

        }
       
        public void ExcuteHoaDonDichVu()
        {
            string sSelectHDDV = "select hd.madv, dv.tendv, hd.soluong from hoadon_dichvu as hd, dichvu as dv where hd.madv = dv.madv and sohd=" + txt_hdsohoadon.Text;
            daKaraoke = new MySqlDataAdapter(sSelectHDDV, conn);
            daKaraoke.Fill(ds, "tbl_HoaDonDichVu");
            dgv_hoadondichvu.DataSource = null;
            dgv_hoadondichvu.Rows.Clear();

            foreach (DataRow r in ds.Tables["tbl_HoaDonDichVu"].Rows)
            {

                dgv_hoadondichvu.Rows.Add(r[0], r[1], r[2]);
            }
            ds.Tables["tbl_HoaDonDichVu"].Clear();
        }
        //public void ExcuteDichVu()
        //{
        //    string sSelectHDDV = "select hd.madv, dv.tendv, hd.soluong from hoadon_dichvu as hd, dichvu as dv where hd.madv = dv.madv and sohd=" + txt_hdsohoadon.Text;
        //    daKaraoke = new MySqlDataAdapter(sSelectHDDV, conn);
        //    daKaraoke.Fill(ds, "tbl_HoaDonDichVu");
        //    dgv_hoadondichvu.DataSource = null;
        //    dgv_hoadondichvu.Rows.Clear();

        //    foreach (DataRow r in ds.Tables["tbl_HoaDonDichVu"].Rows)
        //    {

        //        dgv_hoadondichvu.Rows.Add(r[0], r[1], r[2]);
        //    }
        //    ds.Tables["tbl_HoaDonDichVu"].Clear();
        //}
        public void OpenRoom(string maphong)
        {

            string sOpen = "update phong set trangthai=1 where maphong=" + maphong;
            MySqlCommand cmd = new MySqlCommand(sOpen, conn);
            cmd.ExecuteNonQuery();
        }
        public void CloseRoom(string maphong)
        {

            string sClose = "update phong set trangthai=0 where maphong=" + maphong;
            MySqlCommand cmd = new MySqlCommand(sClose, conn);
            cmd.ExecuteNonQuery();
        }
        private void dgv_hoadonhd_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_hoadonhd.SelectedRows[0];
                txt_hdsohoadon.Text = dt.Cells["hdhd_sohoadon"].Value.ToString();
                cmb_hdphong.Text = dt.Cells["hdhd_phong"].Value.ToString();
                testRoom = dt.Cells["hdhd_phong"].Value.ToString();
                dtm_hdgiovao.Text = dt.Cells["hdhd_giovao"].Value.ToString();
                
                //dtm_hdgiora.Text = dt.Cells["hdhd_giora"].Value.ToString();
                cmb_hdphong.Enabled = false;
                ExcuteHoaDonDichVu();
                
            }
            catch {
            }
        }

        
        public void ThemHoaDon()
        {
            try
            {
                string sThemHoaDon = "insert into hoadon(maphong,giovao,trangthai) value(@maphong,@giovao,@trangthai)";
                MySqlCommand cmd = new MySqlCommand(sThemHoaDon, conn);
                cmd.Parameters.AddWithValue("@maphong", cmb_hdphong.SelectedValue);
                var giovao =  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
                cmd.Parameters.AddWithValue("@giovao", giovao.ToString());
                cmd.Parameters.AddWithValue("@trangthai", 0);
                cmd.ExecuteNonQuery();
                OpenRoom(cmb_hdphong.SelectedValue.ToString());
                LoadHoaDonHoatDong();
                LoadKhoHoaDon();
                LoadCmbPhong();

                MessageBox.Show("Thêm hóa đơn thành công!");
                cmd.Parameters.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void DoiPhong()
        {
            
            try
            {
                CloseRoom(testRoom);
                string sDoiPhong =  "update hoadon set maphong=" + cmb_hdphong.SelectedValue.ToString() + " where sohd =" + txt_hdsohoadon.Text;
                MySqlCommand cmd = new MySqlCommand(sDoiPhong, conn);
                OpenRoom(cmb_hdphong.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                LoadHoaDonHoatDong();
                LoadKhoHoaDon();
                LoadCmbPhong();
                
                MessageBox.Show("Đổi phòng thành công!");
      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btn_hdthemmoi_Click(object sender, EventArgs e)
        {
            check = 1;
            txt_hdsohoadon.Text = "";
            cmb_hdphong.Enabled = true;
            dtm_hdgiovao.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtm_hdgiora.Text = "";
            btn_hdok.Visible = true;
            btn_hdcancel.Visible = true;
        }

       

        private void btn_hdcancel_Click(object sender, EventArgs e)
        {
            txt_hdsohoadon.Text = "";
            cmb_hdphong.Text = "";
            dtm_hdgiovao.Text = "";
            dtm_hdgiora.Text = "";
            btn_hdok.Visible = false;
            btn_hdcancel.Visible = false;
        }

        private void btn_hdchinhsua_Click(object sender, EventArgs e)
        {
            if (txt_hdsohoadon.Text == "") MessageBox.Show("Chọn Hóa đơn cần đổi phòng!");
            else
            {
                check = 2;
                             
                cmb_hdphong.Enabled = true;
                
                btn_hdok.Visible = true;
                btn_hdcancel.Visible = true;
            }
              
        }


        private void btn_hdok_Click(object sender, EventArgs e)
        {
            switch (check)
            {
                case 1:
                    ThemHoaDon();
                    break;
                case 2:
                    DoiPhong();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            btn_hdok.Visible = false;
            btn_hdcancel.Visible = false;
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            if (txt_hdsohoadon.Text == "") MessageBox.Show("Chọn Hóa đơn cần thêm dịch vụ!");
            else
            {
                var hddv = new frm_hddv();
                hddv.sohd = txt_hdsohoadon.Text;
                hddv.Show();
                
            }
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dgv_dichvu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //for txdid divu lieu co bang tât ca cac phong co dich vu
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void dgv_dichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_dichvu.SelectedRows[0];
                txt_madv.Text = dt.Cells["madichvu"].Value.ToString();
                txt_tendv.Text = dt.Cells["tendichvu"].Value.ToString();
                //cmb_hdphong.Text = dt.Cells["hdhd_phong"].Value.ToString();
                //testRoom = dt.Cells["hdhd_phong"].Value.ToString();
                //dtm_hdgiovao.Text = dt.Cells["hdhd_giovao"].Value.ToString();

                //dtm_hdgiora.Text = dt.Cells["hdhd_giora"].Value.ToString();
                //cmb_hdphong.Enabled = false;
                //ExcuteDichVu();

            }
            catch
            {
            }
        }

        private void dgv_dichvu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
