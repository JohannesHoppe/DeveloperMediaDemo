using System.Web.Mvc;

namespace DeveloperMediaDemo.Controllers
{
    public class JasmineController : Controller
    {
        public ViewResult Run()
        {
            return View("SpecRunner");
        }
    }
}
