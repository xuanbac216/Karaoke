using QuanlyKaraoke.DAL;
using QuanlyKaraoke.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.BLL
{
    class XuLyPhong
    {
        internal static string OpenRoom(string maPhong)
        {
            return PhongDAO.OpenRoom(maPhong);
        }
        internal static string CloseRoom(string maPhong)
        {
            return PhongDAO.CloseRoom(maPhong);
        }
        internal static List<Phong> GetRoom()
        {
            return PhongDAO.GetPhong();
        }
        internal static string AddRoom(string maPhong, string tenPhong, string giaPhong,int trangThai, string moTa)
        {
            return PhongDAO.ThemPhong(maPhong, tenPhong, giaPhong , trangThai, moTa);
        }
        internal static List<Phong> FindRoom(string maPhong, string tenPhong, string giaPhong, string moTa)
        {
            return PhongDAO.FindRoom(maPhong, tenPhong, giaPhong, moTa);
        }
        internal static string EditRoom(string maPhong, string tenPhong, string giaPhong, string moTa)
        {
            return PhongDAO.SuaPhong(maPhong, tenPhong, giaPhong, moTa);
        }
        internal static bool CheckPhong(string maPhong)
        {
            return PhongDAO.CheckPhong(maPhong);
        }
        internal static string DeleteRoom(string maPhong)
        {
            return PhongDAO.DeleteRoom(maPhong);
        }
    }
}
