using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.Entity
{
    public class HoaDon
    {
        private int _soHoaDon;
        private int _maPhong;
        private string _khachHang;
        private string _diaChi;
        private DateTime _gioVao;
        private DateTime _gioRa;
        

     

        public DateTime GioVao
        {
            get
            {
                return _gioVao;
            }

            set
            {
                _gioVao = value;
            }
        }

        public DateTime GioRa
        {
            get
            {
                return _gioRa;
            }

            set
            {
                _gioRa = value;
            }
        }

        public int SoHoaDon
        {
            get
            {
                return _soHoaDon;
            }

            set
            {
                _soHoaDon = value;
            }
        }

        public string KhachHang
        {
            get
            {
                return _khachHang;
            }

            set
            {
                _khachHang = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _diaChi;
            }

            set
            {
                _diaChi = value;
            }
        }

        public int MaPhong
        {
            get
            {
                return _maPhong;
            }

            set
            {
                _maPhong = value;
            }
        }

        public HoaDon(int soHoaDon, int maPhong, DateTime gioVao)
        {
            SoHoaDon = soHoaDon;
            MaPhong = maPhong;
            GioVao = gioVao;
        }
        public HoaDon(int soHoaDon, int maPhong, string khachHang, string diaChi, DateTime gioVao, DateTime gioRa)
        {
            SoHoaDon = soHoaDon;
            MaPhong = maPhong;
            KhachHang = khachHang;
            DiaChi = diaChi;
            GioVao = gioVao;
            GioRa = gioRa;

        }

    }
}
