using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.DAL
{
    class UserDAO : DAO
    {
        internal static List<User> GetUser()
        {
            var lst = new List<User>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select username, password from taikhoan";
            #endregion

            #region 3. Thực hiện truy vấn
            var dr = cmd.ExecuteReader();
            #endregion

            #region 4. Xử lý kết quả truy vấn
            while (true)
            {
                if (dr.Read() == false)
                    break;
                var userName = dr.GetString(0);
                var pass = dr.GetString(1);
                var p = new User(userName, pass);
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
