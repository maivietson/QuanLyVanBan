using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class DocumentCategoryController : Controller
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
    }
}