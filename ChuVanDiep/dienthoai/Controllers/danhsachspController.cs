using dienthoai.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoai.Controllers
{
    public class danhsachspController : Controller
    {
        dienthoaiEntities db = new dienthoaiEntities();
        // GET: danhsachsp
        int pagesize = 1;
        public ActionResult Index(int id, int? page=1)
        {
            int cpage = page ?? 1;
            List<sanpham> l = db.sanphams.Where(n => n.maloai == id).ToList();
            string strName = db.loaisanphams.SingleOrDefault(m => m.maloai == id).tenloai;
            ViewBag.Tenloai = strName;
            ViewBag.list = l.ToPagedList(cpage, pagesize);
            ViewBag.id = id;
            return View();
        }
    }
}