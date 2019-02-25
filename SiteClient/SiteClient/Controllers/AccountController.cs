using SiteClient.Common;
using SiteClient.Models;
using SiteClient.Models.ViewModels;
using SiteClient.SsoService;
using System.Web.Mvc;

namespace SiteClient.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                var ssoClient = new SsoServiceClient();
                var ret = ssoClient.Login(loginVM.UserName, loginVM.Password);
                if (ret.Status)  // login successfully
                {
                    var userModel = new UserModel { UserId = ret.UserId, UserName = ret.UserName };

                    SessionMng.CurrentAccount = userModel;
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(loginVM);
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            if (SessionMng.CurrentAccount != null)
            {
                SessionMng.CurrentAccount = null;
            }
            return (RedirectToAction("Login"));
        }
    }
}