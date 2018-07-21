using Models.Dao;
using QuanLyVanBan.Areas.Admin.Models;
using QuanLyVanBan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyVanBan.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUserName(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Username not exist!!!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Username is locking!!!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is incorrect!!!");
                }
                else
                {
                    ModelState.AddModelError("", "Login not successfull!!!");
                }
            }

            return View("Index");
        }
    }
}