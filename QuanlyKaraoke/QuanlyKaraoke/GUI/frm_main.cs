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
        DataTable table = new DataTable();
        string testRoom;
        public int check;
        public frm_main()
        {
            InitializeComponent();
          
        }
       
        #region XỬ LÝ HÓA ĐƠN
        public void LoadKhoHoaDon()
        {
            #region Đổ dữ liệu cho kho hóa đơn
            dgv_khohoadon.DataSource = null;
            dgv_khohoadon.Rows.Clear();
            var lst = XuLyHoaDon.GetHoaDon();
            foreach (HoaDon h in lst)
            {
                dgv_khohoadon.Rows.Add(h.SoHoaDon, h.MaPhong, h.KhachHang,h.DiaChi, h.GioVao,h.GioRa);
            }
            #endregion
        }

        public void LoadHoaDonHoatDong()
        {
            dgv_hoadonhd.DataSource = null;
            dgv_hoadonhd.Rows.Clear();
            #region Đổ dữ liệu cho hóa đơn đang hoạt động
            var lst = XuLyHoaDon.GetHoaDonHoatDong();

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
                dgv_dichvu.Rows.Add(dv.maDichVu, dv.tenDichVu, dv.loaiDichVu, dv.soLuong, dv.donGia, dv.dVT);
            }
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
        private void ResetHoaDon()
        {
            txt_hdsohoadon.Text = "";
            cmb_hdphong.Text = "";
            dtm_hdgiovao.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            dtm_hdgiora.Text = "";
            txt_hdsohoadon.Enabled = false;
            cmb_hdphong.Enabled = false;
            dtm_hdgiovao.Enabled = false;
            dtm_hdgiora.Visible = false;
            btn_hdok.Visible = false;
            btn_hdcancel.Visible = false;
            
        }
        private void OnHoaDon()
        {
            txt_hdsohoadon.Enabled = true;
            cmb_hdphong.Enabled = true;
            dtm_hdgiovao.Enabled = true;
            btn_hdok.Visible = true;
            btn_hdcancel.Visible = true;
        }
        private void ModeButtonHoaDon(bool on)
        {
            if (on)
            {
                btn_hdthemmoi.Enabled = true;
                btn_hdchinhsua.Enabled = true;
                btn_hdTim.Enabled = true;
                btn_hdXoa.Enabled = true;
                btn_hdThemdv.Enabled = true;
                btn_hdXuat.Enabled = true;
            }
            else
            {
                btn_hdthemmoi.Enabled = false;
                btn_hdchinhsua.Enabled = false;
                btn_hdTim.Enabled = false;
                btn_hdXoa.Enabled = false;
                btn_hdThemdv.Enabled = false;
                btn_hdXuat.Enabled = false;
            }
            
        }
        private void frm_main_Load(object sender, EventArgs e)
        {
            ResetHoaDon();
            LoadKhoHoaDon();
            LoadHoaDonHoatDong();
            LoadCmbPhong();
            LoadDichvu();
        }
        #endregion
        private void dgv_khohoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_khohoadon.SelectedRows[0];
                txt_hdsohoadon.Text = dt.Cells["cl_sohoadon"].Value.ToString();
                cmb_hdphong.Text = dt.Cells["cl_phong"].Value.ToString();
                testRoom = dt.Cells["cl_phong"].Value.ToString();
                dtm_hdgiovao.Text = dt.Cells["cl_giovao"].Value.ToString();
                dtm_hdgiora.Visible = true;
                dtm_hdgiora.Text = dt.Cells["cl_giora"].Value.ToString();
            }
            catch
            {
            }
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
             
                cmb_hdphong.Enabled = false;
                ExcuteHoaDonDichVu(txt_hdsohoadon.Text.ToString());
                
            }
            catch {
            }
        }
        
        private void dgv_hoadondichvu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_hoadondichvu.SelectedRows[0];
                txt_hdmadv.Text = dt.Cells["hddv_madv"].Value.ToString();
                nud_hddv_soluong.Value = Int32.Parse(dt.Cells["hddv_soluong"].Value.ToString());

            }
            catch
            {
            }
        }
        
        public void ThemHoaDon()
        {
            XuLyPhong.OpenRoom(cmb_hdphong.SelectedValue.ToString());
            var check = XuLyHoaDon.ThemHoaDon(cmb_hdphong.SelectedValue.ToString());
            if (check == null) MessageBox.Show("Thêm hóa đơn thành công!");
            else MessageBox.Show(check);
            LoadHoaDonHoatDong();
            LoadKhoHoaDon();
            LoadCmbPhong();            
        }
        public void DoiPhong()
        {
            XuLyPhong.CloseRoom(testRoom);
            XuLyPhong.OpenRoom(cmb_hdphong.SelectedValue.ToString());
            string doiPhong = XuLyHoaDon.ChangeRoom(cmb_hdphong.SelectedValue.ToString(), txt_hdsohoadon.Text);
            if (doiPhong == null)
            {
                MessageBox.Show("Đổi phòng thành công!");
                LoadHoaDonHoatDong();
                LoadKhoHoaDon();
                LoadCmbPhong();
            }
            else MessageBox.Show(doiPhong);
      
            
        }
        private void btn_hdthemmoi_Click(object sender, EventArgs e)
        {
            check = 1;
            ModeButtonHoaDon(false);
            btn_hdthemmoi.Enabled = true;
            ResetHoaDon();
            OnHoaDon();
            txt_hdsohoadon.Enabled = false;

        }
       
        //Xử lý THÊM DỊCH VỤ cho HÓA ĐƠN
        private void btn_hd_save_Click(object sender, EventArgs e)
        {
            XuLyHoaDon.Update(txt_hdsohoadon.Text, txt_hdmadv.Text, Int16.Parse(nud_hddv_soluong.Value.ToString()));
            ExcuteHoaDonDichVu(txt_hdsohoadon.Text);
            LoadDichvu();
        }
        private void btn_hdThemdv_Click(object sender, EventArgs e)
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

        private void btn_hdcancel_Click(object sender, EventArgs e)
        {
            ResetHoaDon();
            ModeButtonHoaDon(true);
        }

        private void btn_hdchinhsua_Click(object sender, EventArgs e)
        {
            if (txt_hdsohoadon.Text == "") MessageBox.Show("Chọn Hóa đơn cần đổi phòng!");
            else
            {
                check = 2;
                ModeButtonHoaDon(false);
                btn_hdchinhsua.Enabled = true;
                cmb_hdphong.Enabled = true;
                btn_hdok.Visible = true;
                btn_hdcancel.Visible = true;
            }
              
        }
        private void btn_hdXoa_Click(object sender, EventArgs e)
        {
            if (txt_hdsohoadon.Text == "") MessageBox.Show("Chọn Hóa đơn Xóa!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa Hóa đơn này", "CHÚ Ý!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (XuLyHoaDon.CheckHoaDon(txt_hdsohoadon.Text)) MessageBox.Show("Bạn không có quyền xóa hóa đơn này!");
                    else
                    {

                        var Close = XuLyPhong.CloseRoom(cmb_hdphong.Text.ToString());
                        if (Close == null)
                        {
                            var resultDelete = XuLyHoaDon.XoaHoaDon(txt_hdsohoadon.Text);
                            if (resultDelete == null) MessageBox.Show("Bạn đã hủy hóa đơn thành công!!!");
                            else MessageBox.Show(resultDelete);
                        }
                        else MessageBox.Show("Lỗi hệ thống không thể mở lại phòng hát\n");
                        LoadCmbPhong();
                        LoadHoaDonHoatDong();
                    }

                }
                else if (dialogResult == DialogResult.No)
                {
                    ResetPhong();
                }

            }
        }

        private void btn_hdok_Click(object sender, EventArgs e)
        {
            switch (check)
            {
                case 1:
                    ThemHoaDon();
                    ModeButtonHoaDon(true);
                    break;
                case 2:
                    DoiPhong();
                    ModeButtonHoaDon(true);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            btn_hdok.Visible = false;
            btn_hdcancel.Visible = false;
        }

     


        #region  XỬ LÝ DỊCH VỤ
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
            txt_madv.Enabled = false;
            txt_tendv.Enabled = false;
            txt_dv_soluong.Enabled = false;
            txt_dv_dongia.Enabled = false;
            txt_dv_dvt.Enabled = false;
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
        #endregion

        #region  XỬ LÝ PHÒNG
        private static int CheckRoom;
        private void ResetPhong()
        {
            txt_phongMaPhong.Text = "";
            txt_phongTenPhong.Text = "";
            txt_phongGiaPhong.Text = "";
            txt_phongMoTa.Text = "";
            txt_phongMaPhong.Enabled = false;
            txt_phongTenPhong.Enabled = false;
            txt_phongGiaPhong.Enabled = false;
            txt_phongMoTa.Enabled = false;
            btn_phongOK.Visible = false;
            btn_phongCancel.Visible = false;
        }
        private void OnPhong()
        {
            txt_phongMaPhong.Enabled = true;
            txt_phongTenPhong.Enabled = true;
            txt_phongGiaPhong.Enabled = true;
            txt_phongMoTa.Enabled = true;
            btn_phongOK.Visible = true;
            btn_phongCancel.Visible = true;

        }
        private void LoadPhong()
        {
            dgv_Phong.DataSource = null;
            dgv_Phong.Rows.Clear();
            #region Đổ dữ liệu bảng dịch vụ
            var lst = XuLyPhong.GetRoom();
            foreach (Phong p in lst)
            {
                dgv_Phong.Rows.Add(p.MaPhong, p.TenPhong,p.GiaPhong, p.TrangThai, p.MoTa);
            }
            #endregion
        }
        private void tabPhong_Click(object sender, EventArgs e)
        {
            ResetPhong();
            LoadPhong();
        }

        #endregion

        private void dgv_Phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow dt = dgv_Phong.SelectedRows[0];
                txt_phongMaPhong.Text = dt.Cells["cl_maphong"].Value.ToString();
                txt_phongTenPhong.Text = dt.Cells["cl_tenphong"].Value.ToString();
                txt_phongGiaPhong.Text = dt.Cells["cl_giaphong"].Value.ToString();
                txt_phongMoTa.Text = dt.Cells["cl_mota"].Value.ToString();

            }
            catch
            {
            }
        }
        private void ModeButtonPhong(bool on)
        {
            if (on)
            {
                btnphong_them.Enabled = true;
                btnphong_chinhsua.Enabled = true;
                btnphong_xoa.Enabled = true;
                btnphong_tim.Enabled = true;
                
            }
            else
            {
                btnphong_them.Enabled = false;
                btnphong_chinhsua.Enabled = false;
                btnphong_xoa.Enabled = false;
                btnphong_tim.Enabled = false;
            }
        }
        private void btnphong_them_Click(object sender, EventArgs e)
        {
            CheckRoom = 1;
            ModeButtonPhong(false);
            btnphong_them.Enabled = true;
            ResetPhong();
            OnPhong();
        }
        private void btnphong_chinhsua_Click(object sender, EventArgs e)
        {
            CheckRoom = 2;
            if (txt_phongMaPhong.Text == "") MessageBox.Show("Chọn phòng cần chỉnh sửa!");
            else
            {
                ModeButtonPhong(false);
                btnphong_chinhsua.Enabled = true;
                OnPhong();
                txt_phongMaPhong.Enabled = false;
            }
            
        }
        private void btnphong_xoa_Click(object sender, EventArgs e)
        {
            CheckRoom = 3;
            if (txt_phongMaPhong.Text == "") MessageBox.Show("Chọn phòng cần Xóa!");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa phòng này", "CHÚ Ý!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if(XuLyPhong.CheckPhong(txt_phongMaPhong.Text)) MessageBox.Show("Phòng này đang được sử dụng, Không thể xóa!");
                    else
                    {
                        var resultDelete = XuLyPhong.DeleteRoom(txt_phongMaPhong.Text);
                        if (resultDelete == null) MessageBox.Show("Xóa phòng thành công!!!");
                        else MessageBox.Show(resultDelete);
                        LoadPhong();
                    }
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    ResetPhong();
                }

            }
        }
        private void btnphong_tim_Click(object sender, EventArgs e)
        {
            CheckRoom = 4;
            ModeButtonPhong(false);
            btnphong_tim.Enabled = true;
            ResetPhong();
            OnPhong();
        }

        private void btn_phongCancel_Click(object sender, EventArgs e)
        {
            ResetPhong();
            ModeButtonPhong(true);
        }

        private void btn_phongOK_Click(object sender, EventArgs e)
        {
            var maPhong = txt_phongMaPhong.Text;
            var tenPhong = txt_phongTenPhong.Text;
            var giaPhong = txt_phongGiaPhong.Text;
            var moTa = txt_phongMoTa.Text;
     
            switch (CheckRoom)
            {
                case 1:
                    var result = XuLyPhong.AddRoom(maPhong, tenPhong, giaPhong, 0, moTa);
                    if (result==null) MessageBox.Show("Thêm Phòng thành công!!!");
                    else MessageBox.Show(result);
                    LoadPhong();
                    break;
                case 2:
                    var resultEdit = XuLyPhong.EditRoom(maPhong, tenPhong, giaPhong, moTa);
                    if (resultEdit == null) MessageBox.Show("Sửa phòng thành công!!!");
                    else MessageBox.Show(resultEdit);
                    LoadPhong();
                    break;
                case 3:
                    
                    break;
                case 4:
                    dgv_Phong.DataSource = null;
                    dgv_Phong.Rows.Clear(); 
                    List<Phong> lst = XuLyPhong.FindRoom(maPhong, tenPhong, giaPhong, moTa);
                    if (lst.Count==0) MessageBox.Show("Không tim thấy phòng theo yêu cầu!!!");
                    else
                    foreach (Phong p in lst)
                    {
                        dgv_Phong.Rows.Add(p.MaPhong, p.TenPhong, p.GiaPhong, p.TrangThai, p.MoTa);
                    }
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            ResetPhong();
            ModeButtonPhong(true);
            btn_phongOK.Visible = false;
            btn_phongCancel.Visible = false;
            
        }

        private void txtphong_Load_Click(object sender, EventArgs e)
        {
            ResetPhong();
            LoadPhong();
            ModeButtonPhong(true);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        
    }
}
