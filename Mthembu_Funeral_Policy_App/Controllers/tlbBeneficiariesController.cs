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
    public class tlbBeneficiariesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbBeneficiaries
        public ActionResult Index()
        {
            return View(db.tlbBeneficiaries.ToList());
        }

        // GET: tlbBeneficiaries/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbBeneficiary tlbBeneficiary = db.tlbBeneficiaries.Find(id);
            if (tlbBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(tlbBeneficiary);
        }

        // GET: tlbBeneficiaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbBeneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Beneficiary_SA_ID_NUmber,tlbClient_ID,Beneficiary_First_Name,Beneficiary_last_Name,Beneficiary_Relationship")] tlbBeneficiary tlbBeneficiary)
        {
            if (ModelState.IsValid)
            {
                db.tlbBeneficiaries.Add(tlbBeneficiary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbBeneficiary);
        }

        // GET: tlbBeneficiaries/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbBeneficiary tlbBeneficiary = db.tlbBeneficiaries.Find(id);
            if (tlbBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(tlbBeneficiary);
        }

        // POST: tlbBeneficiaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Beneficiary_SA_ID_NUmber,tlbClient_ID,Beneficiary_First_Name,Beneficiary_last_Name,Beneficiary_Relationship")] tlbBeneficiary tlbBeneficiary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbBeneficiary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbBeneficiary);
        }

        // GET: tlbBeneficiaries/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbBeneficiary tlbBeneficiary = db.tlbBeneficiaries.Find(id);
            if (tlbBeneficiary == null)
            {
                return HttpNotFound();
            }
            return View(tlbBeneficiary);
        }

        // POST: tlbBeneficiaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbBeneficiary tlbBeneficiary = db.tlbBeneficiaries.Find(id);
            db.tlbBeneficiaries.Remove(tlbBeneficiary);
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
