using dienthoai.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoai.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        dienthoaiEntities db = new dienthoaiEntities();
        int pagesize = 2;
        public ActionResult Index(int? page = 1, int?p2=1)
        {
            int ipage = (page ?? 1);
            int ip2 = (p2 ?? 1);
            List<sanpham> spmoi = db.sanphams.Where(item => item.tinhtrang == 1).Take(4).ToList();
            ViewBag.spmoi = spmoi.ToPagedList(ipage, pagesize);

            List<sanpham> spsapve = db.sanphams.Where(item => item.tinhtrang == 1).ToList();
            ViewBag.spsapve = spsapve.ToPagedList(ip2, pagesize);
            return View();
        }

        [ChildActionOnly]

        public PartialViewResult _leftmenu()
        {
            return PartialView("_leftmenu", db.loaisanphams.ToList());
        }
    }
}