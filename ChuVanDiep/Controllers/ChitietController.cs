using dienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoai.Controllers
{
    public class ChitietController : Controller
    {
        dienthoaiEntities db = new dienthoaiEntities();
        // GET: Chitiet
        public ActionResult Index(int id)
        {
            sanpham sp = db.sanphams.Find(id);
            return View(sp);
        }
    }
}