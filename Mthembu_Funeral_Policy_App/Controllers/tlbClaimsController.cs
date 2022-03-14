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
    public class tlbClaimsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbClaims
        public ActionResult Index()
        {
            return View(db.tlbClaims.ToList());
        }

        // GET: tlbClaims/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            if (tlbClaim == null)
            {
                return HttpNotFound();
            }
            return View(tlbClaim);
        }

        // GET: tlbClaims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Policy_Number,SA_ID_Number,Cellphone_Number,Branch_Name,Branch_Code,Card_NO,Account_NO,Deceased_SA_ID,Deceased_First_Name,Deceased_Last_Name,Death_Course,Status,Message")] tlbClaim tlbClaim)
        {
            if (ModelState.IsValid)
            {
                db.tlbClaims.Add(tlbClaim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbClaim);
        }

        // GET: tlbClaims/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            if (tlbClaim == null)
            {
                return HttpNotFound();
            }
            return View(tlbClaim);
        }

        // POST: tlbClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Policy_Number,SA_ID_Number,Cellphone_Number,Branch_Name,Branch_Code,Card_NO,Account_NO,Deceased_SA_ID,Deceased_First_Name,Deceased_Last_Name,Death_Course,Status,Message")] tlbClaim tlbClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbClaim);
        }

        // GET: tlbClaims/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            if (tlbClaim == null)
            {
                return HttpNotFound();
            }
            return View(tlbClaim);
        }

        // POST: tlbClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            db.tlbClaims.Remove(tlbClaim);
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
