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
    public class tlbMessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbMessages
        public ActionResult Index()
        {
            return View(db.tlbMessages.ToList());
        }

        // GET: tlbMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMessage tlbMessage = db.tlbMessages.Find(id);
            if (tlbMessage == null)
            {
                return HttpNotFound();
            }
            return View(tlbMessage);
        }

        // GET: tlbMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Email,Subject,Message")] tlbMessage tlbMessage)
        {
            if (ModelState.IsValid)
            {
                db.tlbMessages.Add(tlbMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbMessage);
        }

        // GET: tlbMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMessage tlbMessage = db.tlbMessages.Find(id);
            if (tlbMessage == null)
            {
                return HttpNotFound();
            }
            return View(tlbMessage);
        }

        // POST: tlbMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Email,Subject,Message")] tlbMessage tlbMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbMessage);
        }

        // GET: tlbMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMessage tlbMessage = db.tlbMessages.Find(id);
            if (tlbMessage == null)
            {
                return HttpNotFound();
            }
            return View(tlbMessage);
        }

        // POST: tlbMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tlbMessage tlbMessage = db.tlbMessages.Find(id);
            db.tlbMessages.Remove(tlbMessage);
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
