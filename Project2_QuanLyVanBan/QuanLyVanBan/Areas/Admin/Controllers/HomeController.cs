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
            var document = new DocumentDao();
            var feedback = new FeedbackDao();
            ViewBag.FeedbackCount = feedback.GetCountFeedback();
            ViewBag.DocumentCount = document.GetTotalDocument();
            ViewBag.TotalView = document.GetTotalView();
            ViewBag.Feedback = feedback.GetFeedback();
            return View();
        }

        public ActionResult UserView()
        {
            return View();
        }
    }
}