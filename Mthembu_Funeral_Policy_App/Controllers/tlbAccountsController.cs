
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mthembu_Funeral_Policy_App.Models;

namespace Mthembu_Funeral_Policy_App.Controllers
{
    public class tlbAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbAccounts
        public ActionResult Index()
        {
            return View(db.tlbAccounts.ToList());
        }

        // GET: tlbAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbAccount tlbAccount = db.tlbAccounts.Find(id);
            if (tlbAccount == null)
            {
                return HttpNotFound();
            }
            return View(tlbAccount);
        }

        // GET: tlbAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Email,Password,ConfirmPassword,ResetPasswordCode,Role")] tlbAccount tlbAccount)
        {
            if (ModelState.IsValid)
            {
                db.tlbAccounts.Add(tlbAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbAccount);
        }

        // GET: tlbAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbAccount tlbAccount = db.tlbAccounts.Find(id);
            if (tlbAccount == null)
            {
                return HttpNotFound();
            }
            return View(tlbAccount);
        }

        // POST: tlbAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Email,Password,ConfirmPassword,ResetPasswordCode,Role")] tlbAccount tlbAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbAccount);
        }

        // GET: tlbAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbAccount tlbAccount = db.tlbAccounts.Find(id);
            if (tlbAccount == null)
            {
                return HttpNotFound();
            }
            return View(tlbAccount);
        }

        // POST: tlbAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlbAccount tlbAccount = db.tlbAccounts.Find(id);
            db.tlbAccounts.Remove(tlbAccount);
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
