using QuanlyKaraoke.DAL;
using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.BLL
{
    class XuLyHoaDon
    {
        internal static string ChangeRoom(string maPhong, string maHoaDon)
        {
            return HoaDonDAO.ChangeRoom(maPhong,maHoaDon);
        }
        internal static List<HoaDon> GetHoaDon()
        {

            #region Load du lieu 
            var lst = HoaDonDAO.LoadKhoHoaDon();
            return lst;

            #endregion
        }
        internal static List<HoaDon> GetHoaDonHoatDong()
        {
            
            #region Load du lieu 
            var lst = HoaDonDAO.LoadHoaDonHoatDong();
            return lst;
         
            #endregion
        }

        internal static List<DichVu> GetDichVuHoaDon(string soHD)
        {

            #region Load du lieu 
            var lst = HoaDonDichVuDAO.GetDichVu(soHD);
            return lst;

            #endregion
        }
        internal static List<Phong> GetPhongTrong()
        {

            #region Load du lieu 
            var lst = PhongDAO.GetPhongTrong();
            return lst;

            #endregion
        }
        internal static string ThemHoaDon(string maPhong)
        {

            #region Xu ly Them hoa don, goi tang DAO
            return HoaDonDAO.ThemHoaDon(maPhong);
            #endregion
        }
        internal static void Update(string soHd, string maDv, int soluong)
        {
            HoaDonDichVuDAO.Update(soHd, maDv, soluong);
        }
        internal static string ThemDichVu(string soHd, string maDv, string soluong)
        {
            int soLuongCo = XuLyDichVu.GetSoLuong(maDv);
            if (Int16.Parse(soluong) > soLuongCo) return "Kho dịch vụ không đủ số lượng! Vui lòng kiểm tra lại";
            int soLuongConLai = soLuongCo - Int16.Parse(soluong);
            string resultUpdate = XuLyDichVu.UpdateSoLuong(maDv,Convert.ToString(soLuongConLai));
            if (resultUpdate == null)
            {
                return HoaDonDichVuDAO.ThemDichVu(soHd, maDv, soluong);
            }
            else return "Lỗi không thể trừ số lượng dịch vụ trong kho";
        }
        internal static bool CheckHoaDon(string soHoaDon)
        {
            return HoaDonDAO.CheckHoaDon(soHoaDon);
        }
        internal static string XoaHoaDon(string soHoaDon)
        {
            return HoaDonDAO.XoaHoaDon(soHoaDon);
        }
    }
}
