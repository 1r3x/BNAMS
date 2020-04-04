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
        private LoginHelper Helper=new LoginHelper();
        private IPasswordChange _aManager;

        public UserLoginsController()
        {
            _aManager = new PasswordChangeManager();
        }

        // GET: UserLogins
        public ActionResult Index()
        {
            return View(db.UserLogins.ToList());
        }

        // GET: UserLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // GET: UserLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserLogins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailIsConfirmed,Password,PhoneNo,UserRole,IsActive,UserName,CreateDate,CreatedBy,LastLoginDate")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.UserLogins.Add(userLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userLogin);
        }

        
        // GET: UserLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // POST: UserLogins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailIsConfirmed,Password,PhoneNo,UserRole,IsActive,UserName,CreateDate,CreatedBy,LastLoginDate")] UserLogin userLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userLogin);
        }

        // GET: UserLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserLogin userLogin = db.UserLogins.Find(id);
            if (userLogin == null)
            {
                return HttpNotFound();
            }
            return View(userLogin);
        }

        // POST: UserLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserLogin userLogin = db.UserLogins.Find(id);
            db.UserLogins.Remove(userLogin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(SR.Models.login.User user)
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
            var validateDate=(from s in usersEntities.UserLogins where (s.UserName==user.Username || s.Email==user.Username) && s.Password.Equals(password) select  s).FirstOrDefault();
            //ar query = (from s in context.ObjRegisterUser where(s.UserName == userName || s.EmailId == userName) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();
            if (validateDate != null && validateDate.Id > 0)
            {
                var empId = validateDate.EmpId;
                var sessionData = (from s in usersEntities.Emp_BasicInfo where (s.EmpIdNumber==validateDate.EmpId) select s).FirstOrDefault();
                int? userId = validateDate.Id;
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                Session["userid"] = validateDate.Id;
                Session["username"] = user.Username;
               // Session["lastlogindate"] = validateDate.LoginDate;
                Session["roleId"] = validateDate.UserRole;
                Session["empId"] = validateDate.EmpId;

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
