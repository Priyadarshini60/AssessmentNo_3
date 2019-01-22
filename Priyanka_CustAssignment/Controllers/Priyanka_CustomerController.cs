using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Priyanka_CustAssignment.Models;

namespace Priyanka_CustAssignment.Controllers
{
    public class Priyanka_CustomerController : Controller
    {
        private custEntities db = new custEntities();

        // GET: Priyanka_Customer
        public ActionResult Index()
        {
            return View(db.Priyanka_Customer.ToList());
        }

        // GET: Priyanka_Customer/Details/5

        public ActionResult Details()
        {



            string str = Session["UserID"].ToString();
            if (str == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.FirstOrDefault(x => x.UserName.Equals(str));
            //Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.Find(str);
            if (priyanka_Customer == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_Customer);
        }

        // GET: Priyanka_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Priyanka_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Name,Address,MobileNumber,Status")] Priyanka_Customer priyanka_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Priyanka_Customer.Add(priyanka_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(priyanka_Customer);
        }

        // GET: Priyanka_Customer/Edit/5
        
        public ActionResult Edit()
        {
            string str = Session["UserID"].ToString();
            if (str == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.Find(str);
            Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.FirstOrDefault(x =>x.UserName.Equals(str));
            if (priyanka_Customer == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_Customer);
        }

        // POST: Priyanka_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Name,Address,MobileNumber,Status")] Priyanka_Customer priyanka_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priyanka_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(priyanka_Customer);
        }

        // GET: Priyanka_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.Find(id);
            if (priyanka_Customer == null)
            {
                return HttpNotFound();
            }
            return View(priyanka_Customer);
        }

        // POST: Priyanka_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Priyanka_Customer priyanka_Customer = db.Priyanka_Customer.Find(id);
            db.Priyanka_Customer.Remove(priyanka_Customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
