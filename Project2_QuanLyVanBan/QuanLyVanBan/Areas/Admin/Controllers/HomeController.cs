using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
    }
}