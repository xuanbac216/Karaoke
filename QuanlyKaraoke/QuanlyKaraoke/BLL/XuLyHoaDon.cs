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
        internal static List<HoaDon> GetHoaDon()
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
        internal static void Update(string soHd, string maDv, string soluong)
        {
            HoaDonDichVuDAO.Update(soHd, maDv, soluong);
        }
        internal static void ThemDichVu(string soHd, string maDv, string soluong)
        {
            HoaDonDichVuDAO.ThemDichVu(soHd, maDv, soluong);
        }
    }
}
