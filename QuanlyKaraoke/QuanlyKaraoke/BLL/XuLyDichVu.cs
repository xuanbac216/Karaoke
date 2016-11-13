using QuanlyKaraoke.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanlyKaraoke.BLL
{
    class XuLyDichVu
    {
        internal static List<DichVu> GetDichVu()
        {

            #region Load du lieu 
            var lst = DichVuDAO.GetDichVu();
            return lst;

            #endregion
        }
        internal static void XoaDichVu(string maDV)
        {

            #region Kiểm tra dịch vụ có đang được sử dụng
            var check = HoaDonDichVuDAO.CheckDichVu(maDV);
            if (check)
            {
                MessageBox.Show("ERROR : Có Phòng Dang Sử Dụng Dịch Vụ này!!!");

            }
            else
            {
                #region Xoa dich vu 
                DichVuDAO.XoaDichVu(maDV);
                #endregion

            }

            #endregion
        }
        internal static void ThemDichVu(string maDV, string tenDV, string loaiDV, string sl, string donGia, string dVT)
        {
            DichVuDAO.ThemDichVu(maDV, tenDV, loaiDV, sl, donGia, dVT);
        }
    }
}
