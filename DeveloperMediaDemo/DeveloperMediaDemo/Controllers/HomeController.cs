using System.Web.Mvc;

namespace DeveloperMediaDemo.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}