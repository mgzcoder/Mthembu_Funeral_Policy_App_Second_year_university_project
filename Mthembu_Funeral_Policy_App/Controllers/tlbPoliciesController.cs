using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mthembu_Funeral_Policy_App.Models;

namespace DPO_Paygate_PayWeb3.Controllers
{
    public class tlbPoliciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbPolicies
        public ActionResult Index()
        {
            return View(db.tlbPolicies.ToList());
        }

        // GET: tlbPolicies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbPolicy tlbPolicy = db.tlbPolicies.Find(id);
            if (tlbPolicy == null)
            {
                return HttpNotFound();
            }
            return View(tlbPolicy);
        }

        // GET: tlbPolicies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbPolicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Policy_ID,tlbClient_ID2,Policy_Cost,Available_Amount,Policy_Type,Cover_Type")] tlbPolicy tlbPolicy)
        {
            if (ModelState.IsValid)
            {
                db.tlbPolicies.Add(tlbPolicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbPolicy);
        }

        // GET: tlbPolicies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbPolicy tlbPolicy = db.tlbPolicies.Find(id);
            if (tlbPolicy == null)
            {
                return HttpNotFound();
            }
            return View(tlbPolicy);
        }

        // POST: tlbPolicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Policy_ID,tlbClient_ID2,Policy_Cost,Available_Amount,Policy_Type,Cover_Type")] tlbPolicy tlbPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbPolicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbPolicy);
        }

        // GET: tlbPolicies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbPolicy tlbPolicy = db.tlbPolicies.Find(id);
            if (tlbPolicy == null)
            {
                return HttpNotFound();
            }
            return View(tlbPolicy);
        }

        // POST: tlbPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlbPolicy tlbPolicy = db.tlbPolicies.Find(id);
            db.tlbPolicies.Remove(tlbPolicy);
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
