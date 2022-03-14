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
    public class tlbClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tlbClients

        public ActionResult Index()
        {
            return View(db.tlbClients.ToList());
        }


        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(long? id,PolicyNumberModel policyNumberModel)
        {
            policyNumberModel.PolicyNumber = policyNumberModel.PolicyNumber;
            id = policyNumberModel.PolicyNumber;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClient tlbClient = db.tlbClients.Find(id);
            if (tlbClient == null)
            {
                return HttpNotFound();
            }
            return View("Details",tlbClient);
        }

        public ActionResult Details()
        {

            return View();
        }

       

        // GET: tlbClients/Details/5
        //public ActionResult Details(long? id, PolicyNumberModel policyNumberModel)
        //{


        //    policyNumberModel.PolicyNumber = policyNumberModel.PolicyNumber;

        //    id = policyNumberModel.PolicyNumber;


        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tlbClient tlbClient = db.tlbClients.Find(id);
        //    if (tlbClient == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tlbClient);
        //}

        // GET: tlbClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tlbClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_SA_ID_Number,SA_ID,First_Name,Last_Name,Email_Address,Marital_Status,Gender,Race,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        {
             
          var wow = "";

            if (ModelState.IsValid)
            {
                db.tlbClients.Add(tlbClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tlbClient);
        }
     
        // GET: tlbClients/Edit/5
        public ActionResult Edit(long? id)
        {
            
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClient tlbClient = db.tlbClients.Find(id);
            if (tlbClient == null)
            {
                return HttpNotFound();
            }
            return View(tlbClient);
        }

        // POST: tlbClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_SA_ID_Number,First_Name,Last_Name,Email_Address,Marital_Status,Gender,Race,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbClient);
        }

        // GET: tlbClients/Delete/5
        public ActionResult Delete(long? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClient tlbClient = db.tlbClients.Find(id);
            if (tlbClient == null)
            {
                return HttpNotFound();
            }
            return View(tlbClient);
        }

        // POST: tlbClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbClient tlbClient = db.tlbClients.Find(id);
            db.tlbClients.Remove(tlbClient);
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
