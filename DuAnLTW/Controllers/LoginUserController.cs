using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DuAnLTW.Models;


namespace DuAnLTW.Controllers
{
    public class LoginUserController : Controller
    {
        DBGrocery1Entities db = new DBGrocery1Entities();
        // GET: LoginUser
        // Phương thức tạo view cho Login
        // Regíter
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.AdminUsers.Add(_user);
                db.SaveChanges();
            }
            else
            {
                ViewBag.ErrorRegister = "ID này đã có rồi !!!";
            }
            return View();
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("ProductList","Products");
        }
        public ActionResult Index(int chon)
        {
            Session["chon"] = chon;
            return View();
        }
        // Xử lý tìm kiếm ID, password trong AdminUser và thông báo
        [HttpPost]
        public ActionResult LoginAcount(AdminUser _user, string chon)
        {
            var check = db.AdminUsers.Where(s => s.ID == _user.ID && s.PasswordUser ==_user.PasswordUser).FirstOrDefault();
            if (check == null)
            {
                ViewBag.ErrorInfo = "Sai Info";
                return View("Index");
            }
            else
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = _user.ID;
                Session["PasswodUser"] = _user.PasswordUser;
                Session["chon"] = chon;
                if (chon.ToString() == "1")
                    return RedirectToAction("Index", "Products");
                else if (chon.ToString() == "2")
                    return RedirectToAction("Index", "Categories");
                else if (chon.ToString() == "3")
                    return RedirectToAction("Index", "Customers");
                else if (chon.ToString() == "4")
                    return RedirectToAction("Index", "OrderProes");
                else if (chon.ToString() == "5")
                    return RedirectToAction("RegisterUser", "LoginUser");
                else
                    return RedirectToAction("ProductList", "Products");
            }
        }

    }
}