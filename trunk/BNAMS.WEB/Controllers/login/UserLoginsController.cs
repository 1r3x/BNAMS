using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using BNAMS.Entities;
using BNAMS.Manager.Interface;
using BNAMS.Manager.Manager;
using SR.Helpers;

namespace BNAMS.Controllers.login
{
    [SessionState(SessionStateBehavior.Default)]
    public class UserLoginsController : Controller
    {
        private SmartRecordEntities db = new SmartRecordEntities();
        private LoginHelper Helper = new LoginHelper();
        private IPasswordChange _aManager;

        public UserLoginsController()
        {
            _aManager = new PasswordChangeManager();
        }



        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(SR.Models.login.User user)
        {
            //if (DateTime.Now <= Convert.ToDateTime("25-07-2020"))// for vs (date-month-year) and for IIS (month-date-year)
            if (DateTime.Now <= Convert.ToDateTime("07-25-2020"))// for vs (date-month-year) and for IIS (month-date-year)
            {
                SmartRecordEntities usersEntities = new SmartRecordEntities();
                var keyNew = (from s in usersEntities.UserLogins where (s.UserName == user.Username || s.Email == user.Username) select s).FirstOrDefault();
                var password = "";
                if (keyNew != null)
                {
                    password = Helper.EncodePassword(user.Password, keyNew.SessionKey);
                }
                else
                {

                }

                //var validateDate = usersEntities.Validate_User(user.Username, user.Password).FirstOrDefault();
                var validateDate =
                    (from s in usersEntities.UserLogins
                     join dir in usersEntities.O_DirectorateInfo on s.DirectorateId equals dir.DirectorateID
                     where (s.UserName == user.Username || s.Email == user.Username)
                     && s.Password.Equals(password)
                     select new { s, dir.DirectorateName }
                ).FirstOrDefault();



                //ar query = (from s in context.ObjRegisterUser where(s.UserName == userName || s.EmailId == userName) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();
                if (validateDate != null && validateDate.s.Id > 0)
                {
                    var sessionData = (from s in usersEntities.UserLogins where (s.Id == validateDate.s.Id) select s)
                        .FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    Session["userid"] = validateDate.s.Id;
                    Session["username"] = user.Username;
                    Session["directorateId"] = validateDate.s.DirectorateId;
                    Session["roleId"] = validateDate.s.UserRole;
                    Session["empIdNo"] = validateDate.s.EmpIdNumber;
                    Session["empDirName"] = validateDate.DirectorateName;
                    Session["empIdNo"] = validateDate.s.EmpIdNumber;



                    if (sessionData != null) Session["imageUrl"] = sessionData.EmpImage;
                    else
                    {
                        Session["imageUrl"] = "";
                    }
                    //test purpose
                    //Session.Clear();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Setting.    
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    string message = string.Empty;
                    message = "Username and/or password is incorrect.";
                    ViewBag.Message = message;
                    return View(user);
                }
                //this part of code is used for only sesion access
                //end sesion access code
            }
            else
            {
                // Setting.    
                ModelState.AddModelError(string.Empty, "Oops...License Expired");
                string message = string.Empty;
                message = "OOPS...License Expired";
                ViewBag.Message = message;
                return View(user);
            }

        }

        [HttpPost]
        public ActionResult ResetRequest(SR.Models.login.User user)
        {
            var message = "";
            var keyNew = (from s in db.UserLogins where (s.UserName == user.Email || s.Email == user.Email) select s).FirstOrDefault();
            if (keyNew != null && keyNew.Id > 0)
            {
                var passtxt = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(passtxt, keyNew.SessionKey);


                message = "Your new password sent to your email address.";
                TempData["success"] = message;
            }
            else
            {
                message = "Your username or email address did not match";
                TempData["message"] = message;
            }

            return RedirectToAction("Login", "Userlogins");
        }



        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Userlogins");
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
