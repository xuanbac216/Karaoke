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
using QuanlyKaraoke.Entity;

namespace QuanlyKaraoke
{
    public partial class frm_main : Form
    {
        DataSet ds;
        static string connetionString = "server=localhost;database=karaoke;uid=root;pwd=;";
        MySqlConnection conn = new MySqlConnection(connetionString);
        MySqlDataAdapter daKaraoke;
        DataTable table = new DataTable();
        string testRoom;
        public int check;
        public frm_main()
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
            string sSelectHoadon = "select * from hoadon where trangthai=1";
            daKaraoke = new MySqlDataAdapter(sSelectHoadon, conn);
            daKaraoke.Fill(ds, "tbl_KhoHoaDon");
            foreach (DataRow r in ds.Tables["tbl_KhoHoaDon"].Rows)
            {

                dgv_khohoadon.Rows.Add(r[0], r[1], r[2], r[3], r[4], r[5]);
            }
            ds.Tables["tbl_KhoHoaDon"].Clear();
            #endregion
        }
        //public void LoadHoaDonHoatDong()
        //{
        //    dgv_hoadonhd.DataSource = null;
        //    dgv_hoadonhd.Rows.Clear();
        //    #region Đổ dữ liệu cho hóa đơn đang hoạt động
        //    string sSelectHoadonhd = "select * from hoadon where trangthai=0";
        //    daKaraoke = new MySqlDataAdapter(sSelectHoadonhd, conn);
        //    daKaraoke.Fill(ds, "tbl_HoaDonHoatDong");
        //    foreach (DataRow r in ds.Tables["tbl_HoaDonHoatDong"].Rows)
        //    {

        //        dgv_hoadonhd.Rows.Add(r[0], r[1], r[4]);
        //    }
        //    ds.Tables["tbl_HoaDonHoatDong"].Clear();
        //    #endregion
        //}
        public void LoadHoaDonHoatDong()
        {
            dgv_hoadonhd.DataSource = null;
            dgv_hoadonhd.Rows.Clear();
            #region Đổ dữ liệu cho hóa đơn đang hoạt động
            var lst = XuLyHoaDon.GetHoaDon();
            
            foreach (HoaDon h in lst)
            {

                dgv_hoadonhd.Rows.Add(h.SoHoaDon, h.MaPhong, h.GioVao);
            }
            #endregion
        }
        public void LoadCmbPhong()
        {
         
            #region Đổ dữ liệu cho combobox phòng
            DataTable cmb = new DataTable();
            cmb.Columns.Add("maphong");
            cmb.Columns.Add("tenphong");
            var lst = XuLyHoaDon.GetPhongTrong();
            
            foreach (Phong p in lst)
            {

                cmb.Rows.Add(p.MaPhong, p.TenPhong);
                
            }
            cmb_hdphong.DataSource = cmb;
            cmb_hdphong.DisplayMember = "tenphong";
            cmb_hdphong.ValueMember = "maphong";

            #endregion
        }
        public void LoadDichvu()
        {
            dgv_dichvu.DataSource = null;
            dgv_dichvu.Rows.Clear();
            #region Đổ dữ liệu bảng dịch vụ
            var lst = XuLyDichVu.GetDichVu();
            foreach (DichVu dv in lst)
            {
                dgv_dichvu.Rows.Add(dv.maDichVu,dv.tenDichVu, dv.loaiDichVu,dv.soLuong,dv.donGia,dv.dVT);
               
            }
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
       
        public void ExcuteHoaDonDichVu(string soHD)
        {
            var lst = XuLyHoaDon.GetDichVuHoaDon(soHD);
            dgv_hoadondichvu.DataSource = null;
            dgv_hoadondichvu.Rows.Clear();

            foreach (DichVu r in lst)
            {
                dgv_hoadondichvu.Rows.Add(r.maDichVu, r.tenDichVu, r.soLuong);
            }
            
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
                ExcuteHoaDonDichVu(txt_hdsohoadon.Text.ToString());
                
            }
            catch {
            }
        }

        
        public void ThemHoaDon()
        {
            OpenRoom(cmb_hdphong.SelectedValue.ToString());
            var check = XuLyHoaDon.ThemHoaDon(cmb_hdphong.SelectedValue.ToString());
            if (check == null) MessageBox.Show("Thêm hóa đơn thành công!");
            else MessageBox.Show(check);
            LoadHoaDonHoatDong();
            LoadKhoHoaDon();
            LoadCmbPhong();
            
            
            
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
                hddv.ShowDialog();
                ExcuteHoaDonDichVu(hddv.sohd);
            }
        }


        private void dgv_dichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_dichvu.SelectedRows[0];
                txt_madv.Text = dt.Cells["madichvu"].Value.ToString();
                txt_tendv.Text = dt.Cells["tendichvu"].Value.ToString();
                txt_dv_soluong.Text = dt.Cells["soluong"].Value.ToString();
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

        private void btn_dv_xoa_Click(object sender, EventArgs e)
        {
            if (txt_madv.Text.Equals(null) || txt_madv.Text.Equals("")) return;
            //XuLyDichVu.XoaDichVu(txt_madv.Text.ToString());
            XuLyDichVu.DeleteDichVu(txt_madv.Text.ToString());
            LoadDichvu();
        }
        private void ResetDichVu()
        {
            txt_madv.Text = "";
            txt_tendv.Text = "";
            txt_dv_soluong.Text = "";
            txt_dv_dongia.Text = "";
            txt_dv_dvt.Text = "";
            btn_dv_ok.Visible = false;
            btn_dv_cancel.Visible = false;
        }
        private void OnDichVu()
        {
            txt_madv.Enabled = true;
            txt_tendv.Enabled = true;
            txt_dv_soluong.Enabled = true;
            txt_dv_dongia.Enabled = true;
            txt_dv_dvt.Enabled = true;
            btn_dv_ok.Visible = true;
            btn_dv_cancel.Visible = true;
        }
        private void btn_dv_them_Click(object sender, EventArgs e)
        {
            ResetDichVu();
            OnDichVu();
            
        }

        private void btn_dv_ok_Click(object sender, EventArgs e)
        {
            var maDv = txt_madv.Text;
            var tenDv = txt_tendv.Text;
            var loaiDv = "";
            var sl = txt_dv_soluong.Text;
            var dg = txt_dv_dongia.Text;
            var dvt = txt_dv_dvt.Text;
            XuLyDichVu.ThemDichVu(maDv, tenDv, loaiDv, sl, dg, dvt);
            LoadDichvu();
            ResetDichVu();
        }

        private void dgv_hoadondichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dt = dgv_hoadondichvu.SelectedRows[0];
            txt_hdmadv.Text = dt.Cells["hddv_madv"].Value.ToString();
            int soluong = Int16.Parse(dt.Cells["hddv_soluong"].Value.ToString());
            nud_hddv_soluong.Value = soluong;
        }

        private void btn_hd_save_Click(object sender, EventArgs e)
        {
            var soHd = txt_hdsohoadon.Text.ToString();
            var maDv = txt_hdmadv.Text.ToString();
            var soLuong = nud_hddv_soluong.Value.ToString();
            XuLyHoaDon.Update(soHd, maDv, soLuong);
            ExcuteHoaDonDichVu(soHd);
            
        }

        private void btn_dv_cancel_Click(object sender, EventArgs e)
        {
            ResetDichVu();
        }
    }
}
