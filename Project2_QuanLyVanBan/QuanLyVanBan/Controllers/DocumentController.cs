using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Controllers
{
    public class DocumentController : Controller
    {
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(long id, int page = 1, int pageSize = 1)
        {
            var category = new DocumentCategoryDao().ViewDetail(id);
            ViewBag.Category = category;
            int total = 0;
            var model = new DocumentDao().ListAllToPage(id, ref total, page, pageSize);

            ViewBag.Total = total;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(total / pageSize));

            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            return View(model);
        }

        public ActionResult ListDocSearch(string searchString, int page = 1, int pageSize = 1)
        {
            int total = 0;
            var model = new DocumentDao().ListDocSearch(searchString, ref total, page, pageSize);

            ViewBag.SearchString = searchString;
            ViewBag.Total = total;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(total / pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }

        public ActionResult Detail(long id)
        {
            var model = new DocumentDao();
            var category = new DocumentCategoryDao();
            var document = model.ViewDetail(id);
            ViewBag.ListDocument = model.ListDocument(document.CategotyID, 4);
            ViewBag.ListCategory = category.ListAll();
            ViewBag.Category = category.ViewDetail(document.CategotyID.Value);
            return View(document);
        }
    }
}