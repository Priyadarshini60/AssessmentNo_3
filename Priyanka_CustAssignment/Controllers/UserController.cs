using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Priyanka_CustAssignment.Models;
namespace Priyanka_CustAssignment.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {
            Priyanka_User userModel = new Priyanka_User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Priyanka_User userModel)
        {
            using (Priyanka_UserEntities dbModel = new Priyanka_UserEntities())
            {
                if (dbModel.Priyanka_User.Any(x=>x.UserName==userModel.UserName))
                {
                    ViewBag.Duplicate = "UserName Already Exits";
                    return View("AddOrEdit", userModel);
                }
                dbModel.Priyanka_User.Add(userModel);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMSG = "Registration Successfully";
                return View("AddOrEdit",new Priyanka_User());
        }
    }
}