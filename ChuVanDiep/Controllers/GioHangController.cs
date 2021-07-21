using dienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoai.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult chonhang(int id)
        {
            List<GioHang> gh = Session["GioHang"] as List<GioHang>;
            if(gh == null)
            {
                gh = new List<GioHang>();
                Session["GioHang"] = gh;
            }
            GioHang item = gh.Find(n => n.iMaSP == id);
            if(item==null)
            {
                GioHang newitem = new GioHang(id);
                gh.Add(newitem);
            }
            else
            {
                item.iSoLuong += 1;
            }
            return RedirectToAction("XemGioHang");
        }

        public ActionResult XemGioHang()
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            int soluong = 0; double tongtien = 0;
            if(lst != null)
            {
                soluong = lst.Sum(n => n.iSoLuong);
                tongtien = (double)lst.Sum(n => n.dThanhtien);
            }
            ViewBag.soluong = soluong;
            ViewBag.thanhtien = tongtien;
            return View(lst);
        }

        public ActionResult Xoa(int id)
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            GioHang item = lst.Find(n => n.iMaSP == id);
            lst.Remove(item);
            return RedirectToAction("XamGioHang");
        }

        [HttpPost]
        public ActionResult Capnhat(int id, FormCollection frm)
        {
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            GioHang item = lst.Find(n => n.iMaSP == id);
            int soluong = int.Parse(frm["txtSoluong"].ToString());
            item.iSoLuong = soluong;
            return RedirectToAction("XemGioHang");
        }

        public ActionResult dathang()
        {
            if(Session["ten"] == null)
            {
                Session["thanhtoan"] = "1";
                return RedirectToAction("DangNhap", "nguoidung");
            }
            else
            {
                Session.Remove("thanhtoan");
            }
            List<GioHang> lst = Session["GioHang"] as List<GioHang>;
            int soluong = 0; double tongtien = 0;
            if(lst != null)
            {
                soluong = lst.Sum(n => n.iSoLuong);
                tongtien = (double)lst.Sum(n => n.dThanhtien);
            }
            ViewBag.soluong = soluong;
            ViewBag.thanhtien = tongtien;
            return View(lst);
        }
    }
}