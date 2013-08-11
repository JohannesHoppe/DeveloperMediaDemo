using System.Web.Mvc;

namespace DeveloperMediaDemo.Controllers
{
    public class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}