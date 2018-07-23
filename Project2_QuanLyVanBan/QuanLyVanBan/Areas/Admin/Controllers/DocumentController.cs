using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Admin/Document
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}