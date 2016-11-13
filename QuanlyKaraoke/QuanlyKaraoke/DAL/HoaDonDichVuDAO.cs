using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanlyKaraoke.DAL
{
    class HoaDonDichVuDAO :DAO
    {
        internal static List<DichVu> GetDichVu(string soHD)
        {
            var lst = new List<DichVu>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select hd.madv, dv.tendv, hd.soluong from hoadon_dichvu as hd, dichvu as dv where hd.madv = dv.madv and sohd=" + soHD;
            #endregion

            #region 3. Thực hiện truy vấn
            var dr = cmd.ExecuteReader();
            #endregion

            #region 4. Xử lý kết quả truy vấn
            while (true)
            {
                if (dr.Read() == false)
                    break;
                var maDichVu = dr.GetInt32(0);
                var tenDichVu = dr.GetString(1);
                var soLuong = dr.GetInt32(2);
                var dv = new DichVu(maDichVu, tenDichVu, soLuong);
                lst.Add(dv);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
        internal static bool CheckDichVu(string maDv)
        {
            var lst = new List<DichVu>();

            #region 1. Xác định DbConnection đến CSDL

            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select madv from hoadon_dichvu inner join hoadon on hoadon_dichvu.sohd = hoadon.sohd where madv = " + maDv + " and trangthai=0";
            #endregion
            bool check = false;
            #region 3. Thực hiện truy vấn
            try
            {
                var rd = cmd.ExecuteReader();
                if (rd.Read()) check = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi" + ex.ToString());
            }
            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên
            CloseConnection();
            return check;
            #endregion

        }
    }
}
