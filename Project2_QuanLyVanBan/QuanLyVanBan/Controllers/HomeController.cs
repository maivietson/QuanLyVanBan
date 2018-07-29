using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var document = new DocumentDao();
            ViewBag.NewDocument = document.ListDocumentNew(8);
            return View();
        }

        [ChildActionOnly]
        public ActionResult DocumentCategory()
        {
            var model = new DocumentCategoryDao().ListAll();
            return PartialView(model);
        }
    }
}