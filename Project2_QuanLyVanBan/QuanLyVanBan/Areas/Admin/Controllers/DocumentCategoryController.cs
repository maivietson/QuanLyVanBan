using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class DocumentCategoryController : BaseController
    {
        // GET: Admin/DocumentCategory
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var model = new DocumentCategoryDao().ListAllPaging(page, pageSize);
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = new DocumentCategoryDao().ListAll();
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            new DocumentCategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditDocument(long id)
        {
            var model = new DocumentCategoryDao().ViewDetail(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DocumentCategory docCate)
        {
            if (ModelState.IsValid)
            {
                var dao = new DocumentCategoryDao();
                docCate.CreatedDate = DateTime.Now;
                docCate.ShowOnHome = false;
                docCate.Status = true;

                long id = dao.Insert(docCate);
                if (id > 0)
                {
                    SetAlert("Add User Successful!!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Add user not successfull!!");
                }
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult EditDocument(DocumentCategory docCate)
        {
            if (ModelState.IsValid)
            {
                var dao = new DocumentCategoryDao();

                var result = dao.Update(docCate);
                if (result)
                {
                    SetAlert("Edit User Successful!!", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Update user not successfull!!");
                }
            }

            return View("Index");
        }
    }
}