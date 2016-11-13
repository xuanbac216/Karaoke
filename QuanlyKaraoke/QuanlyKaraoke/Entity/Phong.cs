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
        private string _loaiPhong;

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

        public string LoaiPhong
        {
            get
            {
                return _loaiPhong;
            }

            set
            {
                _loaiPhong = value;
            }
        }
        public Phong(int maPhong, string tenPhong)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
           
        }
        public Phong(int maPhong, string tenPhong, string giaPhong, string loaiPhong)
        {
            this.MaPhong = maPhong;
            this.TenPhong = tenPhong;
            this.GiaPhong = giaPhong;
            this.LoaiPhong = loaiPhong;
        }
        
    }
}
