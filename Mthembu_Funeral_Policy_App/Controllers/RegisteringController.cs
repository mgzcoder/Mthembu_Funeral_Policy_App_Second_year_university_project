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
    public class RegisteringController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        //public ActionResult Client_Registration_Page()
        //{
        //    ViewBag.tlbClient_ID2 = new SelectList(db.tlbClients, "Client_SA_ID_Number", "First_Name");
        //    ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "Client_SA_ID_Number");

        //    ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "Client_SA_ID_Number");
        //    return View();
        //}

        //// POST: tlbBeneficiaries/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Client_Registration_Page([Bind(Include = "Policy_ID,tlbClient_ID2,Policy_Cost,Available_Amount,Policy_Type,Cover_Type")] tlbPolicy tlbPolicy, [Bind(Include = "Client_SA_ID_Number,First_Name,Last_Name,Marital_Status,Gender,Race,Email_Address,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient, [Bind(Include = "Spouse_SA_ID_Number,tlbClient_ID,Spouse_First_Name,Spouse_Last_Name")] tlbSpouse tlbSpouse, [Bind(Include = "Beneficiary_SA_ID_NUmber,tlbClient_ID,Beneficiary_First_Name,Beneficiary_last_Name,Beneficiary_Relationship")] tlbBeneficiary tlbBeneficiary)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tlbPolicies.Add(tlbPolicy);
        //        db.tlbClients.Add(tlbClient);
        //        db.tlbSpouses.Add(tlbSpouse);

        //        db.tlbBeneficiaries.Add(tlbBeneficiary);
        //        db.SaveChanges();
        //        return RedirectToAction("Registration_Successful_Page", "Policy");
        //    }
        //    ViewBag.tlbClient_ID2 = new SelectList(db.tlbClients, "Client_SA_ID_Number", "First_Name", tlbPolicy.tlbClient_ID2);
        //    ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "Client_SA_ID_Number", tlbSpouse.tlbClient_ID);



        //    ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "Client_SA_ID_Number", tlbBeneficiary.tlbClient_ID);

        //    return View(tlbBeneficiary);
        //}


        public ActionResult Client_Registration_Page()
        {
            ViewBag.tlbClient_ID2 = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID");



            return View();
        }

        // POST: tlbBeneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Client_Registration_Page([Bind(Include = "Policy_ID,tlbClient_ID2,Policy_Cost,Available_Amount,Policy_Type,Cover_Type")] tlbPolicy tlbPolicy, [Bind(Include = "Client_SA_ID_Number,SA_ID,First_Name,Last_Name,Email_Address,Marital_Status,Gender,Race,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        {
            if (ModelState.IsValid)
            {
                db.tlbPolicies.Add(tlbPolicy);
                db.tlbClients.Add(tlbClient);



                db.SaveChanges();
                return RedirectToAction("AddSpouse", "Policy");
            }
            ViewBag.tlbClient_ID2 = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID", tlbPolicy.tlbClient_ID2);


            return View(tlbClient);
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
