using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Security.Policy;
using Antlr.Runtime;

using System.Text;
using System.Net.Http;
using System.Configuration;
using Mthembu_Funeral_Policy_App.Services;
using Mthembu_Funeral_Policy_App.Models;
using System.IO;


namespace Mthembu_Funeral_Policy_App.Controllers
{
    public class PolicyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Home_Page()
        {
            return View();
        }

        public ActionResult ClientProfile()
        {
            
                return View();
        }

        public ActionResult Edit_Client_Info(long? id)
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
        public ActionResult Edit_Client_Info([Bind(Include = "Email_Address,Marital_Status,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientProfile", "Policy");
            }
            return View(tlbClient);
        }

        public ActionResult PolicyInfo()
        {

            return View();
        }

        


        public ActionResult Details(long? id)
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


        // GET: tlbClients/Edit/5
        public ActionResult Client_Profile_Edit(long? id)
        {
            id = 2;
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
        public ActionResult Client_Profile_Edit([Bind(Include = "Client_SA_ID_Number,First_Name,Last_Name,Email_Address,Marital_Status,Gender,Race,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientProfile");
            }
            return View(tlbClient);
        }


        public ActionResult ClaimApproval(long? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClaimApproval([Bind(Include = "id,Policy_Number,SA_ID_Number,Cellphone_Number,Branch_Name,Branch_Code,Card_NO,Account_NO,Deceased_SA_ID,Deceased_First_Name,Deceased_Last_Name,Death_Course,Status")] tlbClaim tlbClaim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClaim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClaimsList");
            }
            return View(tlbClaim);
        }

        public ActionResult AddBeneficiarie()
        {
            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBeneficiarie([Bind(Include = "id,Beneficiary_SA_ID_NUmber,tlbClient_ID,Beneficiary_First_Name,Beneficiary_last_Name,Beneficiary_Relationship")] tlbBeneficiary tlbBeneficiary)
        {
            if (ModelState.IsValid)
            {

                db.tlbBeneficiaries.Add(tlbBeneficiary);
                db.SaveChanges();
                return RedirectToAction("AddMembers", "Policy");
            }

            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID", tlbBeneficiary.tlbClient_ID);

            return View(tlbBeneficiary);


        }




        public ActionResult AddMembers()
        {
            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMembers([Bind(Include = "id,Member_SA_ID_Number,tlbClient_ID,Member_First_Name,Member_Last_Name,Realtionship")] tlbMember tlbMember)
        {
            if (ModelState.IsValid)
            {
                db.tlbMembers.Add(tlbMember);
                db.SaveChanges();


                ViewBag.Added = "Member Added";



                return RedirectToAction("AddMembers", "Policy");

            }

            ViewBag.Added = "Member Added";
            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID", tlbMember.tlbClient_ID);
            return View(tlbMember);
        }


        public ActionResult AddSpouse()
        {
            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSpouse([Bind(Include = "id,Spouse_SA_ID_Number,tlbClient_ID,Spouse_First_Name,Spouse_Last_Name")] tlbSpouse tlbSpouse)
        {

            if (ModelState.IsValid)
            {

                db.tlbSpouses.Add(tlbSpouse);
                db.SaveChanges();
                return RedirectToAction("AddBeneficiarie", "Policy");
            }

            ViewBag.tlbClient_ID = new SelectList(db.tlbClients, "Client_SA_ID_Number", "SA_ID", tlbSpouse.tlbClient_ID);




            return View(tlbSpouse);
        }




        //public ActionResult Edit_Client_Info(long? id)
        //{
        //    id = 2;
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

        //// POST: tlbClients/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit_Client_Info([Bind(Include = "Client_SA_ID_Number,First_Name,Last_Name,Email_Address,Marital_Status,Gender,Race,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code")] tlbClient tlbClient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tlbClient).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("AllCliewnts");
        //    }
        //    return View(tlbClient);
        //}

        public ActionResult Delete_Client_Info(long? id)
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
        [HttpPost, ActionName("Delete_Client_Info")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tlbClient tlbClient = db.tlbClients.Find(id);
            db.tlbClients.Remove(tlbClient);
            db.SaveChanges();
            return RedirectToAction("AllCients");
        }





        public ActionResult Aboutus_Page()
        {
            return View();
        }
        public ActionResult SIGN_IN_Page()
        {
            return View();
        }
        public ActionResult Contact_us_page()
        {
            return View();
        }

        public ActionResult AllClients()
        {
            return View(db.tlbClients.ToList());
        }

        public ActionResult AdminRegistration_Page()
        {
            return View();
        }


        public ActionResult More_Client_Info(long? id)
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





        public ActionResult Policy_Info()
        {
            return View();
        }

        public ActionResult Client_Msg_Send()
        {
            return View();
        }
        public ActionResult userprofile_page()
        {
            return View();
        }

        public ActionResult Service_page()
        {
            return View();
        }
        //public ActionResult ViewAllClients()
        //{
        //    return View(db.tlbClients.ToList());
        //}

        public ActionResult ParentCover_C()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ParentCover_C(Qoutation X)
        {

            X.TotalPrice = X.ParentsCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);


        }


        public ActionResult Over80Cover_C()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Over80Cover_C(Qoutation X)
        {

            X.TotalPrice = X.Over80Calc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }

        public ActionResult extendedFamilyCover_C()
        {
            return View();
        }
        [HttpPost]
        public ActionResult extendedFamilyCover_C(Qoutation X)
        {

            X.TotalPrice = X.ExtendedCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }

        public ActionResult FamilyCover_C()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FamilyCover_C(Qoutation X)
        {

            X.TotalPrice = X.FamilyCovCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }

        public ActionResult Member_Page()
        {
            return View();
        }
        public ActionResult NoPeriodCover_C()
        {
            return View();
        }

      [HttpPost]
        public ActionResult NoPeriodCover_C(Qoutation X)
        {

            X.TotalPrice = X.NoPeriodCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);

        }

        
        public ActionResult Admin_Dashboard_Page()
        {
          
            return View();
        }
        public ActionResult DeleteMessage(int? id)
        {

            tlbMessage tlbMessage = db.tlbMessages.Find(id);

            return View(tlbMessage);
        }

        public ActionResult AdminMessageView()
        {

            return View(db.tlbMessages.ToList());
        }


        // POST: tlbMessages/Delete/5
        [HttpPost, ActionName("DeleteMessage")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            tlbMessage tlbMessage = db.tlbMessages.Find(id);
            db.tlbMessages.Remove(tlbMessage);
            db.SaveChanges();
            return RedirectToAction("Admin_Dashboard_Page");
        }
        public ActionResult MessageView()
        {
            return View();
        }
        public ActionResult ServiceToRegister()
        {
            return View();
        }

        public ActionResult ParentCover_CR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ParentCover_CR(Qoutation X)
        {

            X.TotalPrice = X.ParentsCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);


        }
        public ActionResult Over80Cover_CR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Over80Cover_CR(Qoutation X)
        {

            X.TotalPrice = X.Over80Calc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }
        public ActionResult extendedFamilyCover_CR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult extendedFamilyCover_CR(Qoutation X)
        {

            X.TotalPrice = X.ExtendedCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }
        public ActionResult FamilyCover_CR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FamilyCover_CR(Qoutation X)
        {

            X.TotalPrice = X.FamilyCovCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);
        }
        public ActionResult NoPeriodCover_CR()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NoPeriodCover_CR(Qoutation X)
        {

            X.TotalPrice = X.NoPeriodCalc();
            X.NumMembers = X.NumMembers;

            X.CoverType = X.CoverType;
            return View(X);

        }

        public ActionResult Registration_Successful_Page()
        {
            return View();
        }

        
        public ActionResult ClaimsHome()
        {
            return View();
        }
        public ActionResult ClaimForm_Page()
        {
            return View();
        }

        public ActionResult MemberDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbMember TlbMember = db.tlbMembers.Find(id);
            if (TlbMember == null)
            {
                return HttpNotFound();
            }
            return View(TlbMember);
        }

        public ActionResult Benef_Details(long? id)
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



        public ActionResult SpouseDetails()
        {
            var tlbSpouses = db.tlbSpouses.Include(t => t.tlbClient);
            return View(tlbSpouses.ToList());
        }

       

        public ActionResult Calender()
        {
            return View();
        }

        public ActionResult AdminCalender()
        {
            return View();
        }

        public ActionResult Letter()
        {
            return View();
        }

       


       



        


        /*
                [HttpPost]
                [ValidateAntiForgeryToken]

                public ActionResult ClientProfile_Page(tblClaims_Details tblClaims, HttpPostedFileBase myFile)
                {
                    if (ModelState.IsValid)
                    {
                        string path = "";
                        if (myFile.FileName.Length > 0)
                        {
                            path = "~/image/" + Path.GetFileName(myFile.FileName);
                            myFile.SaveAs(Server.MapPath(path));

                        }

                        tblClaims.ID_File = path;
                        tblClaims.Death_Cert = path;
                        db.tblDeceased_Details.Add(tblClaims);
                        db.SaveChanges();
                        return RedirectToAction("Claim_stp1");
                    }

                    return View("Claim_stp1");
                }



                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult ChangePassword_Page( ResetPasswordModel model)
                {
                    Mthembu_Funeral_PolicyEntities db = new Mthembu_Funeral_PolicyEntities();


                    if (ModelState.IsValid)
                    {
                        using (var context = new Mthembu_Funeral_PolicyEntities())
                        {
                            var user = context.tlbAccounts.Where(a => a.Password==model.OldPassword.FirstOrDefault();
                            if (user != null)
                            {
                                //you can encrypt password here, we are not doing it
                                user.Password = model.NewPassword;
                                //make resetpasswordcode empty string now
                                user.ResetPasswordCode = "";
                                //to avoid validation issues, disable it
                                context.Configuration.ValidateOnSaveEnabled = false;
                                context.SaveChanges();
                                ViewBag.message = "New password updated successfully";
                            }
                        }
                    }
                    else
                    {
                       ViewBag.message = "Something invalid";
                    }

                    return View(model);
                }

                */

        // insterting 



        public ActionResult SuccessRegistration_Page()
        {
        


            return View();
        }
        // POST: tlbBeneficiaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        [HttpPost]
        public ActionResult SuccessRegistration_Page(tlbClient tlbClient)
        {
            tlbClient.Last_Name = tlbClient.Last_Name;


            return View(tlbClient);
        }



       



        public ActionResult ClaimsList()
        {
            return View(db.tlbClaims.ToList());
        }

        public ActionResult DeleteClaim(long? id)
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
        [HttpPost, ActionName("DeleteClaim")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClaim(long id)
        {
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            db.tlbClaims.Remove(tlbClaim);
            db.SaveChanges();
            return RedirectToAction("ClaimsList");
        }

        public ActionResult ClaimDetails(long? id)
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



        //SIGN SECTION




        // GET: REGDBs
        public ActionResult Index()
        {
            return View(db.tlbAccounts.ToList());
        }
       

        

        public ActionResult Signin_Page()
        {
            
            return View();
        }

        //This is for the login Authorization
        [HttpPost]
        public ActionResult Authorize(Login loginModel, long? id )
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var Login = db.tlbAccounts.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password && x.Role == true).FirstOrDefault();

                var userDetails = db.tlbAccounts.Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password).FirstOrDefault();
                var clientlogin = db.tlbClients.Where(x => x.Email_Address == loginModel.Email).FirstOrDefault();

                if (userDetails == null)
                {
                    loginModel.LoginErrorMessage = ("Wrong Email or Password");
                    return View("Signin_Page", loginModel);
                }
                
                else if(Login != null)
                {
                    ViewBag.Username =  db.tlbAccounts.Any(Z=>Z.Email==loginModel.Email);
                    return RedirectToAction("Admin_Dashboard_Page");
                }
                else if(clientlogin != null)
                {
                    
                        ViewBag.Username = db.tlbAccounts.Any(Z => Z.Email == loginModel.Email);

                        long user = (from u in db.tlbClients
                                     where u.Email_Address == loginModel.Email
                                     select u.Client_SA_ID_Number).Single();


                    id = user;

                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tlbClient tlbClient = db.tlbClients.Find(id);
                    if (tlbClient == null)
                    {
                        return HttpNotFound();
                    }
                    return View("ClientProfile",tlbClient);

                }
                else
                {
                    Session["Email"] = userDetails.Email;
                    return RedirectToAction("ServiceToRegister");  //in our case we will redirect to 
                                                                         //the services page after a successful login.
                }


            }

        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult GalleryPage()
        {
            return View();
        }


        public ActionResult ForgotPassword_Page()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword_Page(Sent_mail sent, tlbAccount account)
        {
            string resetCode = Guid.NewGuid().ToString();
            // "/NameOfController/NameOfResetPasswordView"
            //this will create the link that will be sent to the user
            var verifyUrl = "/Policy/ResetPassword/" + resetCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var getUser = (from s in db.tlbAccounts where s.Email == account.Email select s).FirstOrDefault();
                if (getUser != null)
                {
                    getUser.ResetPasswordCode = resetCode;

                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 

                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();

                    MailMessage mm = new MailMessage("mthembufuneralpolicy@gmail.com", sent.Email);




                    ViewBag.Message = "Reset password link has been sent to your email address.";



                    mm.Subject = "Password Reset Request";
                    mm.Body = "Hi  <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +

                         " <br/><br/><a href='" + link + "'>" + link + "</a> <br/><br/>" +
                         "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";


                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("mthembufuneralpolicy@gmail.com", "MthembuFP1@");
                    //Add your correct gmail address 
                    smtp.UseDefaultCredentials = true;     //with the password that you used to
                    smtp.Credentials = NetworkCred;                      // Login to your account.
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
                else
                {
                    ViewBag.Message = "User doesn't exists.";
                    return View();
                }
            }

            return View();
        }
        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            //redirect to reset password page
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (var context = new ApplicationDbContext())
            {
                var user = context.tlbAccounts.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        // GET: REGDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbAccount rEGDB = db.tlbAccounts.Find(id);
            if (rEGDB == null)
            {
                return HttpNotFound();
            }
            return View(rEGDB);
        }

        // GET: REGDBs/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Signup_Page()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact_us_page([Bind(Include = "UserID,Name,Email,Subject,Message")] tlbMessage tlbMessage)
        {
            if (ModelState.IsValid)
            {
                db.tlbMessages.Add(tlbMessage);
                db.SaveChanges();
                return RedirectToAction("Contact_us_page");
            }

            return View(tlbMessage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Client_Msg_Send([Bind(Include = "UserID,Name,Email,Subject,Message")] tlbMessage tlbMessage)
        {
            if (ModelState.IsValid)
            {
                db.tlbMessages.Add(tlbMessage);
                db.SaveChanges();
                return RedirectToAction("Client_Msg_Send");
            }

            return View(tlbMessage);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup_Page([Bind(Include = "id,Email,Password,ConfirmPassword,ResetPasswordCode,Role")] tlbAccount tlbAccount)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.tlbAccounts.Any(x => x.Email == tlbAccount.Email))
                {
                    ViewBag.DuplicateMessage = "Email already exist.";
                    return View("Signup_Page", tlbAccount);
                }
                else if(tlbAccount.Password != tlbAccount.ConfirmPassword)
                {
                    ViewBag.Matchmessage = "Password does not match";
                    return View("Signup_Page");
                }

                db.tlbAccounts.Add(tlbAccount);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Successful.";
            return View("Signup_Page", new tlbAccount());

        }

        // GET: REGDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbAccount account = db.tlbAccounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: REGDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Email,Password,ResetPasswordCode,Role")] tlbAccount tlbAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbAccount);
        }

        // GET: REGDBs/Delete/5
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Enter(long? id, PolicyNumberModel policyNumberModel)
        {
            policyNumberModel.PolicyNumber = policyNumberModel.PolicyNumber;
            id = policyNumberModel.PolicyNumber;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tlbClaim tlbClaim = db.tlbClaims.Find(id);
            if (tlbClaim == null)
            {
                return HttpNotFound();
            }
            return View("CheckStatus", tlbClaim);
        }

        public ActionResult CheckStatus()
        {
            return View();
        }

        //public ActionResult CheckStatus(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tlbClaim tlbClaim = db.tlbClaims.Find(id);
        //    if (tlbClaim == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tlbClaim);
        //}


        // POST: REGDBs/Delete/5


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.tlbAccounts.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        //you can encrypt password here, we are not doing it
                        user.Password = model.NewPassword;
                        //make resetpasswordcode empty string now
                        user.ResetPasswordCode = "";
                        //to avoid validation issues, disable it
                        context.Configuration.ValidateOnSaveEnabled = false;
                        context.SaveChanges();
                        
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }



       


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeClaim([Bind(Include = "Policy_Number,SA_ID_Number,Cellphone_Number,Branch_Name,Branch_Code,Card_NO,Account_NO,Deceased_SA_ID,Deceased_First_Name,Deceased_Last_Name,Death_Course,Status")] tlbClaim tlbClaim)
        {
            if (ModelState.IsValid)
            {
               using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var claim = db.tlbClients.Where(x => x.SA_ID == tlbClaim.SA_ID_Number).FirstOrDefault();
                    var Claim = db.tlbMembers.Where(x => x.Member_SA_ID_Number == tlbClaim.Deceased_SA_ID).FirstOrDefault();
                    if (claim == null)
                    {
                      
                        return View("MakeClaim", tlbClaim);
                    }
                    else if (Claim == null)
                    {
                     
                        return View("MakeClaim", tlbClaim);
                    }
                    else
                    {
                        db.tlbClaims.Add(tlbClaim);
                        db.SaveChanges();
                        return RedirectToAction("FileUploads");
                    }
                
                }
            }
            ViewBag.SuccessMessage = "Files Uploaded Successfully.";
            return View(tlbClaim);
        }

        // payment section (paygate)


        private IPayment _payment = new Payment();
      
        // Get Paygate keys from webconfig
        readonly string PayGateID = ConfigurationManager.AppSettings["PAYGATEID"];
        readonly string PayGateKey = ConfigurationManager.AppSettings["PAYGATEKEY"];

      

        public async Task<JsonResult> GetRequest()
        {
            HttpClient http = new HttpClient();
            Dictionary<string, string> request = new Dictionary<string, string>();
            string paymentAmount = (50 * 100).ToString("00"); // amount int cents e.i 50 rands is 5000 cents

            request.Add("PAYGATE_ID", PayGateID);
            request.Add("REFERENCE", "#45846"); // Payment ref e.g ORDER NUMBER
            request.Add("AMOUNT", paymentAmount);
            request.Add("CURRENCY", "ZAR"); // South Africa
            request.Add("RETURN_URL", $"{Request.Url.Scheme}://{Request.Url.Authority}/pay/completepayment");
            request.Add("TRANSACTION_DATE", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            request.Add("LOCALE", "en-za");
            request.Add("COUNTRY", "ZAF");

            // get authenticated user's email
            // use a valid email, paygate will send a transaction confirmation to it
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                request.Add("EMAIL", "mlungisi98@yahoo.com");
            }
            else
            {
                // put your own email address for the payment confirmation (dev only)
                request.Add("EMAIL", "<your email address goes here>");
            }
            request.Add("CHECKSUM", _payment.GetMd5Hash(request, PayGateKey));

            string requestString = _payment.ToUrlEncodedString(request);
            StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpResponseMessage response = await http.PostAsync("https://secure.paygate.co.za/payweb3/initiate.trans", content);
            // if the request did not succeed, this line will make the program crash
            response.EnsureSuccessStatusCode();

            string responseContent = await response.Content.ReadAsStringAsync();

            Dictionary<string, string> results = _payment.ToDictionary(responseContent);

            if (results.Keys.Contains("ERROR"))
            {
                return Json(new
                {
                    success = false,
                    message = "An error occured while initiating your request"
                }, JsonRequestBehavior.AllowGet);
            }

            if (!_payment.VerifyMd5Hash(results, PayGateKey, results["CHECKSUM"]))
            {
                return Json(new
                {
                    success = false,
                    message = "MD5 verification failed"
                }, JsonRequestBehavior.AllowGet);
            }

            bool IsRecorded = _payment.AddTransaction(request, results["PAY_REQUEST_ID"]);
            if (IsRecorded)
            {
                return Json(new
                {
                    success = true,
                    message = "Request completed successfully",
                    results
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = false,
                message = "Failed to record a transaction"
            }, JsonRequestBehavior.AllowGet);
        }

        // This is your return url from Paygate
        // This will run when you complete payment
        [HttpPost]
        public async Task<ActionResult> CompletePayment()
        {
            string responseContent = Request.Params.ToString();
            Dictionary<string, string> results = _payment.ToDictionary(responseContent);

            Transaction transaction = _payment.GetTransaction(results["PAY_REQUEST_ID"]);

            if (transaction == null)
            {
                // Unable to reconsile transaction
                return RedirectToAction("Failed");
            }

            // Reorder attributes for MD5 check
            Dictionary<string, string> validationSet = new Dictionary<string, string>();
            validationSet.Add("PAYGATE_ID", PayGateID);
            validationSet.Add("PAY_REQUEST_ID", results["PAY_REQUEST_ID"]);
            validationSet.Add("TRANSACTION_STATUS", results["TRANSACTION_STATUS"]);
            validationSet.Add("REFERENCE", transaction.REFERENCE);

            if (!_payment.VerifyMd5Hash(validationSet, PayGateKey, results["CHECKSUM"]))
            {
                // checksum error
                return RedirectToAction("Failed");
            }
            /** Payment Status 
             * -2 = Unable to reconsile transaction
             * -1 = Checksum Error
             * 0 = Pending
             * 1 = Approved
             * 2 = Declined
             * 3 = Cancelled
             * 4 = User Cancelled
             */
            int paymentStatus = int.Parse(results["TRANSACTION_STATUS"]);
            if (paymentStatus == 1)
            {
                // Yey, payment approved
                // Do something useful
            }
            // Query paygate transaction details
            // And update user transaction on your database
            await VerifyTransaction(responseContent, transaction.REFERENCE);
            return RedirectToAction("Complete", new { id = results["TRANSACTION_STATUS"] });
        }

        private async Task VerifyTransaction(string responseContent, string Referrence)
        {
            HttpClient client = new HttpClient();
            Dictionary<string, string> response = _payment.ToDictionary(responseContent);
            Dictionary<string, string> request = new Dictionary<string, string>();

            request.Add("PAYGATE_ID", PayGateID);
            request.Add("PAY_REQUEST_ID", response["PAY_REQUEST_ID"]);
            request.Add("REFERENCE", Referrence);
            request.Add("CHECKSUM", _payment.GetMd5Hash(request, PayGateKey));

            string requestString = _payment.ToUrlEncodedString(request);

            StringContent content = new StringContent(requestString, Encoding.UTF8, "application/x-www-form-urlencoded");

            // ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            HttpResponseMessage res = await client.PostAsync("https://secure.paygate.co.za/payweb3/query.trans", content);
            res.EnsureSuccessStatusCode();

            string _responseContent = await res.Content.ReadAsStringAsync();

            Dictionary<string, string> results = _payment.ToDictionary(_responseContent);
            if (!results.Keys.Contains("ERROR"))
            {
                _payment.UpdateTransaction(results, results["PAY_REQUEST_ID"]);
            }

        }

        public ViewResult Complete(int? id)
        {
            string status = "Unknown";
            switch (id.ToString())
            {
                case "-2":
                    status = "Unable to reconsile transaction";
                    break;
                case "-1":
                    status = "Checksum Error. The values have been altered";
                    break;
                case "0":
                    status = "Not Done";
                    break;
                case "1":
                    status = "Approved";
                    break;
                case "2":
                    status = "Declined";
                    break;
                case "3":
                    status = "Cancelled";
                    break;
                case "4":
                    status = "User Cancelled";
                    break;
                default:
                    status = $"Unknown Status({ id })";
                    break;
            }
            TempData["Status"] = status;

            return View();
        }

        // other methods 

       
        public ActionResult MakeClaim()
        {
            //ViewBag.SA_ID_Number = new SelectList(db.tlbClients, "Client_SA_ID_Number", "First_Name");
            return View();
        }

        public ActionResult FileUploads()
        {
            return View();
        }


        public ActionResult ViewFiles()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return View(db.tblFiles.ToList());

        }

        [HttpPost]
        public ActionResult ViewFiles(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            ApplicationDbContext db = new ApplicationDbContext();
            db.tblFiles.Add(new tblFile
            {
                ID_Copy = Path.GetFileName(postedFile.FileName),
                Death_Cert = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            db.SaveChanges();
            return RedirectToAction("ClaimsHome");
        }

        [HttpPost]

        public FileResult DownloadFile(int? fileId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            tblFile file = db.tblFiles.ToList().Find(p => p.Id == fileId.Value);
            return File(file.Data, file.ContentType, file.ID_Copy);
        }



        public ActionResult EditProfile(long? id)
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




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile([Bind(Include = "Client_SA_ID_Number,First_Name,Last_Name,Email_Address,Gender,Race,Marital_Status,Cell_Phone,Tell_Phone,City,Home_Address,Postal_Code,Bank_Name,Account_Number,Card_Number,CCV_Number,Card_Exp_Date")] tlbClient tlbClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tlbClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tlbClient);
        }



        //ending of other methods


        // payment section (paygate)
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //ActionMethod code for the signup page

        public ActionResult ClientDashboard ()
        {
            return View();
        }
    }


}

