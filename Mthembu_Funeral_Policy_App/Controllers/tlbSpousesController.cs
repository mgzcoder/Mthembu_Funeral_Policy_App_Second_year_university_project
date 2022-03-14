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
    public class tlbSpousesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbSpouses
        public ActionResult Index()
        {
            return View(db.tlbSpouses.ToList());
        }

        // GET: tlbSpouses/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSpouse tlbSpouse = db.tlbSpouses.Find(id);
            if (tlbSpouse == null)
            {
                return HttpNotFound();
            }
            return View(tlbSpouse);
        }

        // GET: tlbSpouses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbSpouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Spouse_SA_ID_Number,tlbClient_ID,Spouse_First_Name,Spouse_Last_Name")] tlbSpouse tlbSpouse)
        {
            if (ModelState.IsValid)
            {
                db.tlbSpouses.Add(tlbSpouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbSpouse);
        }

        // GET: tlbSpouses/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSpouse tlbSpouse = db.tlbSpouses.Find(id);
            if (tlbSpouse == null)
            {
                return HttpNotFound();
            }
            return View(tlbSpouse);
        }

        // POST: tlbSpouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Spouse_SA_ID_Number,tlbClient_ID,Spouse_First_Name,Spouse_Last_Name")] tlbSpouse tlbSpouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbSpouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbSpouse);
        }

        // GET: tlbSpouses/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbSpouse tlbSpouse = db.tlbSpouses.Find(id);
            if (tlbSpouse == null)
            {
                return HttpNotFound();
            }
            return View(tlbSpouse);
        }

        // POST: tlbSpouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbSpouse tlbSpouse = db.tlbSpouses.Find(id);
            db.tlbSpouses.Remove(tlbSpouse);
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
