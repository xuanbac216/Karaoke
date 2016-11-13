using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.DAL
{
    class PhongDAO :DAO
    {
        internal static List<Phong> GetPhongTrong()
        {
            var lst = new List<Phong>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select maphong,tenphong from phong where trangthai=0";
            #endregion

            #region 3. Thực hiện truy vấn
            var dr = cmd.ExecuteReader();
            #endregion

            #region 4. Xử lý kết quả truy vấn
            while (true)
            {
                if (dr.Read() == false)
                    break;
                var maPhong = dr.GetInt32(0);
                var tenPhong = dr.GetString(1);
                var p = new Phong(maPhong, tenPhong);
                lst.Add(p);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
    }
}
