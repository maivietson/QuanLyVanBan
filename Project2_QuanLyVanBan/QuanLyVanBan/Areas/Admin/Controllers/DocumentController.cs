using Models.Dao;
using Models.EF;
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
        public ActionResult Index(string searchString, long id, int page = 1, int pageSize = 5)
        {
            var dao = new DocumentDao();
            var model = dao.ListAllPaging(searchString, id, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new DocumentDao();
            var document = dao.GetById(id);
            SetViewBag(document.CategotyID);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Document model)
        {
            if(ModelState.IsValid)
            {

            }
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Document model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.CategotyID);
            return View();
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new DocumentCategoryDao();
            ViewBag.CategotyID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}