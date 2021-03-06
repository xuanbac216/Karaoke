﻿using System;
using System.Collections.Generic;
using System.Data;
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
        internal static List<DichVu> GetDichVuDangDung()
        {
            var lst = new List<DichVu>();

            #region 1. Open DbConnection
            OpenConnection();

            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select madv from hoadon_dichvu inner join hoadon on hoadon_dichvu.sohd = hoadon.sohd where trangthai=0";
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
                var dv = new DichVu(maDichVu);
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
        internal static void Update (string soHD, string maDv, int soluong )
        {
            OpenConnection();
            
            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "UPDATE hoadon_dichvu SET soluong ='"+ soluong +"' WHERE sohd ='"+ soHD + "' and madv =' "+ maDv+ "'" ;
            #endregion
            
            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteNonQuery();
                
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
            
            #endregion
        }
        internal static string ThemDichVu(string soHD, string maDv, string soluong)
        {
            string result = null;
            List<DichVu> lst = GetDichVu(soHD);
            foreach (DichVu dv in lst)
            {
                if (dv.maDichVu.ToString().Equals(maDv))
                {
                    int sl = dv.soLuong + Int16.Parse(soluong) ;
                    Update(soHD, maDv,  sl );
                    return result;
                }
            } 
            OpenConnection();
            #region 
            var cmd = dbConnection.CreateCommand();
            
            cmd.CommandText = "insert into hoadon_dichvu(sohd,madv,soluong) value(@sohd,@madv,@soluong)";
            AddParam(cmd, "@sohd", DbType.Int32, soHD);
            AddParam(cmd, "@madv", DbType.Int32, maDv);
            AddParam(cmd, "@soluong", DbType.Int16, soluong);

            #endregion

            #region 3. Thực hiện truy vấn

            try
            {
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception exc)
            {
                
                result = "Thêm hóa đơn thất bại! Lỗi:" + exc;
                
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            CloseConnection();
            return result;
            #endregion
        }
    }
}
