using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke.Entity
{
    class Phong 
    {
        private int _maPhong;
        private string _tenPhong;
        private string _giaPhong;
        private int _trangThai;
        private string _moTa;
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

        public string TenPhong
        {
            get
            {
                return _tenPhong;
            }

            set
            {
                _tenPhong = value;
            }
        }

        public string GiaPhong
        {
            get
            {
                return _giaPhong;
            }

            set
            {
                _giaPhong = value;
            }
        }

        public int TrangThai
        {
            get
            {
                return _trangThai;
            }

            set
            {
                _trangThai = value;
            }
        }

        public string MoTa
        {
            get
            {
                return _moTa;
            }

            set
            {
                _moTa = value;
            }
        }

        public Phong(int maPhong, string tenPhong)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
           
        }
        public Phong(int maPhong, string tenPhong, string giaPhong, int trangThai, string moTa)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
            this.GiaPhong = giaPhong;
            this.TrangThai = trangThai;
            this.MoTa = moTa;
        }
        
    }
}
