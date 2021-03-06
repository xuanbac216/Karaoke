﻿using System;
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
        internal static List<HoaDon> LoadKhoHoaDon()
        {
            var lst = new List<HoaDon>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select * from hoadon where trangthai=1";
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
                var maPhong = dr.GetInt32(1);
                var khachHang = dr.GetString(2);
                var diaChi = dr.GetString(3);
                var gioVao = dr.GetDateTime(4);
                var gioRa = dr.GetDateTime(5);
                var hd = new HoaDon(soHoaDon, maPhong, khachHang, diaChi, gioVao, gioRa);
                lst.Add(hd);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
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
        internal static string ChangeRoom(string maPhong, string maHoaDon)
        {
            var lst = new List<Phong>();
            string error = null;
            #region 1. Open DbConnection
            OpenConnection();
            #endregion
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "update hoadon set maphong = " + maPhong + " where sohd = " + maHoaDon;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Đổi phòng thất bại! Lỗi: " + exc.Message;
            }

            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên
            CloseConnection();
            #endregion
            return error;
        }
        internal static bool CheckHoaDon(string soHoaDon)
        {
            var lst = new List<Phong>();
            #region 1. Xác định DbConnection đến CSDL

            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select sohd from hoadon where sohd = " + soHoaDon + " and trangthai=1";
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
        internal static string XoaHoaDon(string maHoaDon)
        {
            string error = null;
            #region 1. Open DbConnection
            OpenConnection();
            #endregion
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "DELETE FROM hoadon WHERE sohd=" + maHoaDon;
            #endregion
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                error = "Xóa hóa đơn thất bại! Lỗi: " + exc.Message;
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
