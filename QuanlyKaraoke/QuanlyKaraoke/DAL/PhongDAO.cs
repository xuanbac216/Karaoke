using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        internal static List<Phong> GetPhong()
        {
            var lst = new List<Phong>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select * from phong ";
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
                var giaPhong = dr.GetString(2);
                var trangThai = dr.GetInt16(3);
                var moTa = dr.GetString(4);
                var p = new Phong(maPhong, tenPhong, giaPhong, trangThai, moTa);
                lst.Add(p);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
        internal static List<Phong> FindRoom(string maPhong, string tenPhong, string giaPhong, string moTa)
        {
            var lst = new List<Phong>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            string query = "select * from phong ";
            string stData = "";   
            if(maPhong!="") stData += "where maphong ='" + maPhong + "'";
            if (tenPhong != "") stData += ((stData == "") ? "where " : "and" )+ " tenphong='" + tenPhong +"'";
            if (giaPhong != "") stData += ((stData == "") ? "where " : "and" )+ " giaphong ='" + giaPhong + "'";
            if (moTa != "") stData += ((stData == "") ? "where " : "and") + " mota like N'%" + moTa + "%'";
            query += stData;
            cmd.CommandText = query;
            #endregion

            #region 3. Thực hiện truy vấn
            var dr = cmd.ExecuteReader();
            #endregion

            #region 4. Xử lý kết quả truy vấn
            while (true)
            {
                if (dr.Read() == false)
                    break;
                var sMaPhong = dr.GetInt32(0);
                var sTenPhong = dr.GetString(1);
                var sGiaPhong = dr.GetString(2);
                var sTrangThai = dr.GetInt16(3);
                var sMoTa = dr.GetString(4);
                var p = new Phong(sMaPhong, sTenPhong, sGiaPhong, sTrangThai, sMoTa);
                lst.Add(p);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }

        internal static string OpenRoom(string maPhong)
        {
            var lst = new List<Phong>();
            string error = null;
            #region 1. Open DbConnection
            OpenConnection();
            #endregion
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "update phong set trangthai=1 where maphong=" + maPhong ;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Mở phòng thất bại! Lỗi: " + exc.Message;
            }

            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên
            CloseConnection();
            #endregion
            return error;
        }
        internal static string CloseRoom(string maPhong)
        {
            var lst = new List<Phong>();
            string error = null;
            #region 1. Open DbConnection
            OpenConnection();
            #endregion
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "update phong set trangthai=0 where maphong=" + maPhong;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Đóng phòng thất bại! Lỗi: " + exc.Message;
            }

            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên
            CloseConnection();
            #endregion
            return error;
        }
        internal static String ThemPhong(string maPhong, string tenPhong, string giaPhong, int trangThai, string moTa)
        {
            String error = null;
            //Kiem tra phong đã tồn tại chưa
            List<Phong> lst = FindRoom(maPhong, tenPhong, "", "");
            if (lst.Count != 0)
            {
                return "Đã tồn tại phòng này! Vui lòng kiểm tra lại!";
            }
            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            
           
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "insert into phong(maphong,tenphong,giaphong,trangthai, mota) value(@maphong,@tenphong, @giaphong,@trangthai, @mota)";
            var gioVao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
            AddParam(cmd, "@maphong", DbType.Int32, maPhong);
            AddParam(cmd, "@tenphong", DbType.String, tenPhong);
            AddParam(cmd, "@giaphong", DbType.String, giaPhong);
            AddParam(cmd, "@trangthai", DbType.Int16, trangThai);
            AddParam(cmd, "@mota", DbType.String, moTa);

            #endregion

            #region 3. Thực hiện truy vấn

            try
            {
                cmd.ExecuteNonQuery();
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

        internal static String SuaPhong(string maPhong, string tenPhong, string giaPhong, string moTa)
        {
            String error = null;
            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "update phong set tenphong ='" + tenPhong + "',giaphong='" +giaPhong + "',mota='" + moTa+ "' where maphong =" + maPhong;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Sửa phòng thất bại! Lỗi: " + exc.Message;
            }
            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên

            CloseConnection();
            #endregion

            return error;
        }
        internal static bool CheckPhong(string maPhong)
        {
            var lst = new List<Phong>();
            #region 1. Xác định DbConnection đến CSDL

            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select maphong from phong where maphong = " + maPhong + " and trangthai=1";
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
        internal static string DeleteRoom(string maPhong)
        {
            string error = null;
            #region 1. Open DbConnection
            OpenConnection();
            #endregion
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM phong WHERE maphong=" + maPhong;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Xóa phòng thất bại! Lỗi: " + exc.Message;
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
