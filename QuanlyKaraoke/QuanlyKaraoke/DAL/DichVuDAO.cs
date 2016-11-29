using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuanlyKaraoke.DAL
{
    class DichVuDAO : DAO
    {
        internal static List<DichVu> GetDichVu()
        {
            var lst = new List<DichVu>();

            #region 1. Xác định DbConnection đến CSDL
            
            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "select * from dichvu";
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
                var loaiDichVu = dr.GetString(2);
                var soLuong = dr.GetInt16(3);
                var donGia = dr.GetString(4);
                var dVT = dr.GetString(5);
                var hd = new DichVu(maDichVu, tenDichVu, loaiDichVu, soLuong, donGia, dVT);
                lst.Add(hd);
            }
            #endregion

            #region 5. Giải phóng tài nguyên
            dr.Close();
            CloseConnection();
            #endregion

            return lst;
        }
        internal static void ThemDichVu(string maDV, string tenDV, string loaiDV, string sl, string donGia, string dVT)
        {
            #region 1. Xác định DbConnection đến CSDL
            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "insert into dichvu(madv,tendv,loaidichvu,soluong,dongia,dvt) value(@madv,@tendv,@loaidichvu,@soluong,@dongia,@dvt)";
            AddParam(cmd, "@madv", DbType.Int32, maDV);
            AddParam(cmd, "@tendv", DbType.String, tenDV);
            AddParam(cmd, "@loaidichvu", DbType.String, loaiDV);
            AddParam(cmd, "@soluong", DbType.Int16, sl);
            AddParam(cmd, "@dongia", DbType.String, donGia);
            AddParam(cmd, "@dvt", DbType.String, dVT);

            #endregion

            #region 3. Thực hiện truy vấn

            try
            {
               cmd.ExecuteNonQuery();
               MessageBox.Show("Thêm dịch vụ thành công");
            }
            catch (Exception exc)
            {
                
                MessageBox.Show("Thêm dịch vụ thất bại! Lỗi:" + exc);
                
            }
            #endregion

            #region 4. Xử lý kết quả truy vấn

            #endregion

            #region 5. Giải phóng tài nguyên

            CloseConnection();
            #endregion
        }
        internal static void XoaDichVu(string maDv)
        {
            #region 1. Xác định DbConnection đến CSDL
            OpenConnection();
            #endregion

            #region 2. Xác định đối tượng truy vấn dữ liệu DbCommand
            var cmd = dbConnection.CreateCommand();
            cmd.CommandText = "delete from dichvu where madv=" + maDv;
            #endregion

            #region 3. Thực hiện truy vấn
            try
            {
                cmd.ExecuteReader();
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
    }
}
