using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DocDesckApp.Models;

namespace DocDesckApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if(Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Document");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин или парроль");
                }
            }
            return View(model);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        private bool ValidateUser(string login, string password)
        {
            bool isValid = false;
            using (DocDeskContext _db = new DocDeskContext())
            {
                try
                {
                    User user = (from u in _db.Users
                                 where u.Login == login && u.Password == password
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        isValid = true;
                    }
                }

                catch
                {
                    isValid = false;
                }
                return isValid;
            }
        }
    }
}