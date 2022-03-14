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
    public class tblFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblFiles
        public ActionResult Index()
        {
            return View(db.tblFiles.ToList());
        }

        // GET: tblFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFile tblFile = db.tblFiles.Find(id);
            if (tblFile == null)
            {
                return HttpNotFound();
            }
            return View(tblFile);
        }

        // GET: tblFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ID_Copy,Death_Cert,ContentType,Data")] tblFile tblFile)
        {
            if (ModelState.IsValid)
            {
                db.tblFiles.Add(tblFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblFile);
        }

        // GET: tblFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFile tblFile = db.tblFiles.Find(id);
            if (tblFile == null)
            {
                return HttpNotFound();
            }
            return View(tblFile);
        }

        // POST: tblFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ID_Copy,Death_Cert,ContentType,Data")] tblFile tblFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblFile);
        }

        // GET: tblFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblFile tblFile = db.tblFiles.Find(id);
            if (tblFile == null)
            {
                return HttpNotFound();
            }
            return View(tblFile);
        }

        // POST: tblFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblFile tblFile = db.tblFiles.Find(id);
            db.tblFiles.Remove(tblFile);
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
