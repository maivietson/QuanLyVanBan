using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class DocumentController : BaseController
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
            return View(document);
        }

        [HttpPost]
        public ActionResult Create(Document model)
        {
            if(ModelState.IsValid)
            {
                var dao = new DocumentDao();
                long id = dao.Insert(model);
                if(id>0)
                {
                    SetAlert("Add Document Successful!!", "success");
                    return RedirectToAction("Index", "Document");
                }
                else
                {
                    ModelState.AddModelError("", "Add document not successfull!!");
                }
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
                var dao = new DocumentDao();
                var result = dao.Update(model);
                if(result)
                {
                    SetAlert("Edit User Successful!!", "success");
                    return RedirectToAction("Index", "Document");
                }
                else
                {
                    ModelState.AddModelError("", "Update document not successfull!!");
                }
            }
            SetViewBag(model.CategotyID);
            return View();
        }

        public ActionResult Detail(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new DocumentDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public void SetViewBag(long? selectedID = null)
        {
            var dao = new DocumentCategoryDao();
            ViewBag.CategotyID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
    }
}