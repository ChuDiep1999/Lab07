using dienthoai.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dienthoai.Controllers
{
    public class nguoidungController : Controller
    {
        dienthoaiEntities db = new dienthoaiEntities();
        // GET: nguoidung

        public ActionResult DangNhap(FormCollection collect)
        {
            string username = collect["txtUsername"];
            string pass = collect["txtPass"];
            if (string.IsNullOrEmpty(username))
            {
                ViewData["UserError"] = "Vui Lòng Nhập Tên";
            }
            else if(string.IsNullOrEmpty(pass))
            {
                ViewData["PassError"] = "Vui Lòng Nhập Tên";
            }
            else
            {
                user usr = db.users.SingleOrDefault(u => u.username == username && u.password == pass);
                if (usr != null)
                {
                    Session["ten"] = usr.fullname;
                    Session["username"] = usr.username;
                    Session["makh"] = usr.userid;
                    if (usr.role == true) return RedirectToAction("index", "admin");
                    else
                    {
                        if (Session["thanhtoan"] == null) return RedirectToAction("index", "trangchu");
                        else return RedirectToAction("dathang", "giohang");
                    }
                }
                else ViewBag.Thongbao = "Nguoi dung khong ton tai";
            }
            return View();
        }
    }
}