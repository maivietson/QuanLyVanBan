using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            ViewBag.FeedbackCount = new FeedbackDao().GetCountFeedback();
            ViewBag.DocumentCount = new DocumentDao().GetTotalDocument();
            return View();
        }
    }
}