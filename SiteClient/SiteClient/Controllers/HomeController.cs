using SiteClient.Common;
using System.Web.Mvc;

namespace SiteClient.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}