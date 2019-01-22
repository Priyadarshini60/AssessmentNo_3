using Priyanka_CustAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Priyanka_CustAssignment.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Priyanka_User userModel)
        {
            //if (ModelState.IsValid)
            //{

                //var email = userModel.UserName;
                //var pwd = userModel.Password;

                //if(email==null)
                //{
                //    TempData["msg"] = "Invalid Credencials";
                //    return View();
                //}
                //else if (pwd==null)
                //{
                //    TempData["msg"] = "Invalid Credencials";
                //    return View();
                //}

                using (Priyanka_UserEntities dbModel = new Priyanka_UserEntities())
                {
                    if ((dbModel.Priyanka_User.Any(x => x.UserName == userModel.UserName && x.Password == userModel.Password && x.Role.Equals("Admin"))))
                    {
                        Session["UserID"] = userModel.UserName;
                        return RedirectToAction("Index", "Admin");
                    }
                    else if ((dbModel.Priyanka_User.Any(x => x.UserName == userModel.UserName && x.Password == userModel.Password && x.Role.Equals("Customer"))))
                    {
                    Session["UserID"] = userModel.UserName;
                    return RedirectToAction("Details", "Priyanka_Customer");
                    }
                    else
                    {
                        TempData["msg"]= "Invalid Credentials";
                        return RedirectToAction("Login", "Login");
                    }

                }

            
            // }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Contents.RemoveAll();
                return RedirectToAction("Index", "Home");
        }
    }
}