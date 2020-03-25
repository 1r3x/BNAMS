using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BNAMS.Manager.Manager;

namespace BNAMS.Controllers
{
    public class HomeController : Controller
    {

        private HomeManager _bManager;

        public HomeController()
        {
            _bManager = new HomeManager();
        }

        public class Transactions
        {
            public int ID { get; set; }
            public string ExpDate { get; set; }
            public string NoticeDate { get; set; }
            public string EmpName { get; set; }
            public string Projectname { get; set; }
        }

       

        public ActionResult Index()
        {
            

            if (Session["userid"] != null)
            {
               // todo for biometric  authentication 

                return View(ViewBag);
            }
            else
            {
                 return RedirectToAction("Logout", "Userlogins");
            }
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       


    }

    

    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession == true)
                {
                    string sessionCookie = context.Request.Headers["Cookie"];

                    if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId_My") >= 0))
                    {
                        // FormsAuthentication.SignOut();  
                        string redirectTo = "~/Userlogins/Login";
                        if (!string.IsNullOrEmpty(context.Request.RawUrl))
                        {
                            filterContext.HttpContext.Response.Redirect(FormsAuthentication.LoginUrl);

                            //redirectTo = string.Format("~/Home/Login?ReturnUrl={0}", HttpUtility.UrlEncode(context.Request.RawUrl));  
                            // filterContext.Result = new RedirectResult(redirectTo);  
                            return;
                        }

                    }
                }
            }

            // base.OnActionExecuting(filterContext);
        }
    }
}