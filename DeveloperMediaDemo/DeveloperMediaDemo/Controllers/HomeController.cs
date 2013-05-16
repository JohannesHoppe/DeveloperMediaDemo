using System.Web.Mvc;

namespace WebNoteSinglePage.Controllers
{
    public partial class HomeController : Controller
    {
        // one view - it's a singe page application
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}