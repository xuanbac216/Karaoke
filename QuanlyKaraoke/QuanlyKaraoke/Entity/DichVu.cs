using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanlyKaraoke
{
    public class DichVu
    {
        public int maDichVu { get; set;}
        public string tenDichVu { get; set; }
        public string loaiDichVu { get; set; }
        public int soLuong { get; set; }
        public string donGia { get; set; }
        public string dVT { get; set; }

        public DichVu(int maDV, string tenDV, string loaiDV, int sl, string dg, string dvt )
        {
            maDichVu = maDV;
            tenDichVu = tenDV;
            loaiDichVu = loaiDV;
            soLuong = sl;
            donGia = dg;
            dVT = dvt;
        }
        public DichVu(int maDV, string tenDV, int sl)
        {
            maDichVu = maDV;
            tenDichVu = tenDV;
            soLuong = sl;
        }
        public DichVu(int maDV)
        {
            maDichVu = maDV;
            
        }
    }
}
