using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dienthoai.Models
{
    public class GioHang
    {
        dienthoaiEntities db = new dienthoaiEntities();
        public int Id { get; set; }
        public int iMaSP { set; get; }
        public string strTenSP { set; get; }
        public string strHinh { set; get; }
        public double dGia { set; get; }
        public int iSoLuong { set; get; }
        public double dThanhtien { get { return dGia * iSoLuong; } }

        public GioHang(int masp)
        {
            iMaSP = masp;
            sanpham sp = db.sanphams.Find(masp);
            strTenSP = sp.tensp;
            sp.gia = sp.gia ?? 0;
            dGia = double.Parse(sp.gia.ToString());
            strHinh = sp.hinhanh;
            iSoLuong = 1;
        }


    }
}