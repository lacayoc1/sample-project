using System.Web.Mvc;

namespace Sample_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Title = "Products";
            return View();
        }
    }
}