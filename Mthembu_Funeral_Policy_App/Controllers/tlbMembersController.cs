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
    public class tlbMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbMembers
        public ActionResult Index()
        {
            return View(db.tlbMembers.ToList());
        }

        // GET: tlbMembers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMember tlbMember = db.tlbMembers.Find(id);
            if (tlbMember == null)
            {
                return HttpNotFound();
            }
            return View(tlbMember);
        }

        // GET: tlbMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Member_SA_ID_Number,tlbClient_ID,Member_First_Name,Member_Last_Name,Realtionship")] tlbMember tlbMember)
        {
            if (ModelState.IsValid)
            {
                db.tlbMembers.Add(tlbMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbMember);
        }

        // GET: tlbMembers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMember tlbMember = db.tlbMembers.Find(id);
            if (tlbMember == null)
            {
                return HttpNotFound();
            }
            return View(tlbMember);
        }

        // POST: tlbMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Member_SA_ID_Number,tlbClient_ID,Member_First_Name,Member_Last_Name,Realtionship")] tlbMember tlbMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbMember);
        }

        // GET: tlbMembers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMember tlbMember = db.tlbMembers.Find(id);
            if (tlbMember == null)
            {
                return HttpNotFound();
            }
            return View(tlbMember);
        }

        // POST: tlbMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbMember tlbMember = db.tlbMembers.Find(id);
            db.tlbMembers.Remove(tlbMember);
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
