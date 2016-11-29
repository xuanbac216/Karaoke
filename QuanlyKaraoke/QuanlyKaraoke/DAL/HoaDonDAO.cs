using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanlyKaraoke.Entity;
using System.Data;
using System.Windows;

namespace QuanlyKaraoke.DAL
{
    public class HoaDonDAO : DAO
    {
        List<KeyValuePair<bool, String>> Error;
        internal static List<HoaDon> LoadHoaDonHoatDong()
        {
            var lst = new List<HoaDon>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select * from hoadon where trangthai=0";
            #endregion

            #region 3. Thực hiện truy vấn
            var dr = cmd.ExecuteReader();
            #endregion

            #region 4. Xử lý kết quả truy vấn
            while (true)
            {
                if (dr.Read() == false)
                    break;
                var soHoaDon = dr.GetInt32(0);
                var maPhong = dr.GetInt32(1) ; 
                var gioVao = dr.GetDateTime(4);
                var hd = new HoaDon(soHoaDon, maPhong, gioVao);
                lst.Add(hd);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
        internal static String ThemHoaDon(string maPhong)
        {
            String error = null;
            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "insert into hoadon(maphong,giovao,trangthai) value(@maphong,@giovao,@trangthai)";
            var gioVao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            AddParam(cmd, "@maphong", DbType.Int32, maPhong);
            AddParam(cmd, "@giovao", DbType.DateTime, gioVao);
            AddParam(cmd, "@trangthai", DbType.Int16, 0);

            #endregion

            #region 3. Thực hiện truy vấn
          
            try
            {
                var nEffectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Thêm hóa đơn thất bại! Lỗi: " + exc.Message;
            }
            #endregion

            #region 4. Xử lý kết quả truy vấn
           
            #endregion

            #region 5. Giải phóng tài nguyên

            CloseConnection();
            #endregion

            return error;
        }

        
    }
}
